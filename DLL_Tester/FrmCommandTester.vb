Imports DLLImports 'See API documentation for details
Imports System.Text

Public Class FrmCommandTester
    Private comPortString As String
    Public SOFTWARE_VERSION = My.Application.Info.Version.ToString 'Software Version change this in Project Properties/Application/Assembly Information
    Private comboboxBindings As New Dictionary(Of String, Action(Of StringBuilder, Integer))()
    Private selectedCommand As String
    Private IDEADrivefunctionToInvoke As Action(Of StringBuilder, Integer)
    Private portChecker As IO.Ports.SerialPort = Nothing
    Dim numberOfOut As Integer = 0
    Dim numberOfIn As Integer = 0

#Region "Initialization & Closing"
    Private Sub FrmCommandTester_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Label name and version
        Me.Text = "IDEA Drive DLL Command Software" & " - Version:" & SOFTWARE_VERSION
        BuildPropertyDictionary()
        InitializeCommandSet()
        'Find available serial ports
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cbPorts.Items.Add(sp)
        Next
        'Set GUI controls accordingly
        If cbPorts.Items.Count = 0 Then
            cbPorts.Enabled = False
            btnSendCommand.Enabled = False
            btnGetAddresses.Enabled = False
            btnExecute.Enabled = False
        Else
            cbPorts.SelectedIndex = 0
            btnExecute.Enabled = True
            cbCommands.Enabled = True
        End If
        cbCommands.Items.AddRange(comboboxBindings.Keys.ToArray())
        cbCommands.SelectedIndex = 0
    End Sub

#End Region

    'Buttons
    Private Sub btnPorts_Click(sender As Object, e As EventArgs) Handles btnPorts.Click
        'Clear current items
        cbPorts.Items.Clear()
        cbAddresses.Items.Clear()
        tbRSP.Text = ""
        'Find available serial ports
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cbPorts.Items.Add(sp)
        Next
        'Set GUI controls accordingly
        If cbPorts.Items.Count = 0 Then
            cbPorts.Enabled = False
            btnSendCommand.Enabled = False
            btnGetAddresses.Enabled = False
            btnExecute.Enabled = False
            cbCommands.Enabled = False
            cbAddresses.Enabled = False
        Else
            cbPorts.SelectedIndex = 0
            cbPorts.Enabled = True
            btnSendCommand.Enabled = True
            btnGetAddresses.Enabled = True
            btnExecute.Enabled = True
            cbCommands.Enabled = True
        End If
    End Sub

    'This function will allow the user to execute the downdown menu command with the entered parameters.
    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        Dim resultString As String
        Dim outputFieldList() As String
        Dim Size As Integer = 1024 'Largest size (bytes) that DLL can fill
        Dim parameterOut As String = ""
        Dim Buffer As New StringBuilder(Size)
        Dim portHandleAddress As Integer
        Try
            tbRSP.Text = "" 'Clear response textboxes

            For i As Integer = 0 To 11
                Dim tbNameO As String = "tbOutput" & i.ToString()
                Dim textBoxControlO As TextBox = TryCast(gbOutput.Controls(tbNameO), TextBox)
                textBoxControlO.Text = ""
            Next

            If cbCommands.SelectedIndex > 26 Then 'Index higher than 26 requires parameter(s).
                'Concantinate parameters
                For i As Integer = 0 To (numberOfIn - 1)
                    Dim tbParameter As String = "tbParams" & i.ToString()
                    Dim textBoxControlP As TextBox = TryCast(gbParameters.Controls(tbParameter), TextBox)
                    parameterOut = parameterOut & textBoxControlP.Text & ","
                Next
                'Remove the last comma
                If parameterOut.Substring(parameterOut.Length - 1, 1) = "," Then
                    parameterOut = parameterOut.Substring(0, parameterOut.Length - 1)
                End If
                Buffer.Append(parameterOut)
                If Buffer.Length < 1 Then 'No parameters given for a command that requires them
                        tbRSP.Text = "Parameters are missing for this command!"
                        Exit Sub
                    End If
                End If

                portHandleAddress = OpenSerial(comPortString)
            If IsSerialOpen() Then
                IDEADrivefunctionToInvoke(Buffer, Size) 'Invoke selected DLL function
            Else
                CloseSerial()
                Exit Sub
            End If
            CloseSerial()
            If (cbCommands.SelectedIndex > 18) Then 'Every command above 18 in the dictorary has no data return.
                resultString = "Command Sent."
            Else
                resultString = Buffer.ToString()
            End If
        Catch ex As InvalidCastException
            MsgBox("Could Not convert result to Integer for processing!")
            Exit Sub
        End Try
        'Parse results into textboxes
        tbRSP.Text = resultString
        outputFieldList = resultString.ToString.Split(","c)
        For i As Integer = 0 To (outputFieldList.Length - 1)
            Dim tbNameO As String = "tbOutput" & i.ToString()
            Dim textBoxControlO As TextBox = TryCast(gbOutput.Controls(tbNameO), TextBox)
            If outputFieldList IsNot Nothing And textBoxControlO IsNot Nothing Then
                If outputFieldList(i) IsNot Nothing Then
                    textBoxControlO.Text = outputFieldList(i)
                End If
            End If
        Next
    End Sub

    'This function will scan the selected port for IDEA Drives by sending a command and waiting for a response. 
    'NOTE: address, command character And return characters ARE accounted for in the DLL.
    Private Sub btnGetAddresses_Click(sender As Object, e As EventArgs) Handles btnGetAddresses.Click
        Dim portHandleAddress As Integer = OpenSerial(comPortString)
        Dim addressList As List(Of Integer)


        tbRSP.Text = ""
        cbAddresses.Items.Clear()
        cbAddresses.Enabled = False
        btnExecute.Enabled = False
        cbCommands.Enabled = False
        btnGetAddresses.Enabled = False
        cbCommands.Enabled = False
        Me.Refresh()
        addressList = GetAddressList()

        'Close serial port if it is open
        If IsSerialOpen() Then
            CloseSerial()
        End If

        If addressList.Count = 1 Then
            cbAddresses.Items.Add(addressList.First)
            cbAddresses.SelectedIndex = 0
            btnExecute.Enabled = True
            cbCommands.Enabled = True
        ElseIf addressList.Count > 1 Then
            cbAddresses.Enabled = True
            For Each item In addressList
                cbAddresses.Items.Add(item)
            Next
            cbAddresses.Items.Add("Broadcast")
            cbAddresses.SelectedIndex = 0
            btnExecute.Enabled = True
            cbCommands.Enabled = True

        End If
        btnGetAddresses.Enabled = True

    End Sub

    'This function will send the command entered in the command box. 
    'NOTE: Return character and address ARE accounted for. Command character Is NOT.
    'Example inputs:
    'Go At Speed:       Q426666,0,0,426666,426666,1000,1000,1000,1000,50,64
    'Stop Immediate:    E5000,5000,50

    Private Sub btnSendCommand_Click(sender As Object, e As EventArgs) Handles btnSendCommand.Click
        'Clear previous text in the result textbox.
        tbRSP.Text = ""

        Dim inputBuffer As String = tbCMD.Text

        If inputBuffer.Length < 1 Then 'Validate Input
            Exit Sub
        End If
        Dim portHandleAddress As Integer = OpenSerial(comPortString)
        'Dim inputBufferSize As Integer = inputBuffer.Length
        ' Determine the maximum size of the output string (DLL max is currently 1024).
        Dim outputSize As Integer = 1024
        Dim outputBuffer As New StringBuilder(outputSize)

        ' Call the DLL method
        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)

        ' Extract the result from the StringBuilder and put it in the response textbox.
        tbRSP.Text = outputBuffer.ToString()
        CloseSerial()
    End Sub

    'Combobox Selection
    Private Sub cbAddresses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAddresses.SelectedIndexChanged
        Dim inputBuffer As String = cbAddresses.Items(cbAddresses.SelectedIndex).ToString
        Dim inputBufferSize As Integer = inputBuffer.Length
        If (cbAddresses.ToString = "Broadcast") Then
            inputBuffer = ""
            inputBufferSize = 1
        Else
            inputBuffer = inputBuffer.PadLeft(3, "0")
        End If
        Dim portHandleAddress As Integer = OpenSerial(comPortString)
        Dim outputSize As Integer = 100
        Dim outputBuffer As New StringBuilder(outputSize)
        'Logic for broadcast mode
        If (inputBuffer = "Broadcast") Then
            inputBuffer = ""
            inputBufferSize = 1
        End If
        ' Call the DLL method
        SetCurrentAddress(inputBuffer, inputBufferSize)
        CloseSerial()
    End Sub

    Private Sub cbCommands_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCommands.SelectedIndexChanged
        If Not IsSerialOpen() Then
            Dim portHandleAddress As Integer = OpenSerial(comPortString) 'Open port
        End If

        selectedCommand = DirectCast(cbCommands.SelectedItem, String) 'Get command name
        IDEADrivefunctionToInvoke = comboboxBindings(selectedCommand) 'Get command binding for invoke

        'Get number of parameters and outputs and the names of the parameters and outputs names
        Dim outputSize As Integer = 1024
        Dim commandCharBuffer As New StringBuilder(outputSize)
        Dim inputBuffer As String = selectedCommand
        Dim parameterIn As New StringBuilder(outputSize)
        Dim parameterList() As String = Nothing
        Dim outputFieldIn As New StringBuilder(outputSize)
        Dim outputFieldList() As String = Nothing
        Dim commandChar As String = ""

        GetCommandLetterFromDescriptive(inputBuffer.ToString, commandCharBuffer, outputSize) 'Get command char
        commandChar = commandCharBuffer.ToString
        numberOfIn = GetNumberOfParametersC(commandChar) 'Get number of parameter
        numberOfOut = GetNumberOfOutputsC(commandChar) 'Get number of output fields
        If numberOfIn > 0 Then
            GetParameterList(commandChar, parameterIn, outputSize) 'Get parameters
            parameterList = parameterIn.ToString.Split(","c) 'Convert stringbuilder to string and parse it into a list
        End If
        If numberOfOut > 0 Then
            GetOutputFieldList(commandChar, outputFieldIn, outputSize) 'Get output fields
            outputFieldList = outputFieldIn.ToString.Split(","c) 'Convert stringbuilder to string and parse it into a list
        End If

        CloseSerial() 'Close port

        'Iterate through each control to set visiblilty and text.
        For i As Integer = 0 To 11
            Dim lblNameP As String = "lblParams" & i.ToString()
            Dim tbNameP As String = "tbParams" & i.ToString()
            Dim lblNameO As String = "lblOutput" & i.ToString()
            Dim tbNameO As String = "tbOutput" & i.ToString()
            Dim lblControlP As Label = TryCast(gbParameters.Controls(lblNameP), Label)
            Dim textBoxControlP As TextBox = TryCast(gbParameters.Controls(tbNameP), TextBox)
            Dim lblControlO As Label = TryCast(gbOutput.Controls(lblNameO), Label)
            Dim textBoxControlO As TextBox = TryCast(gbOutput.Controls(tbNameO), TextBox)

            'Clear Textboxes
            textBoxControlP.Text = ""
            textBoxControlO.Text = ""

            'Set controls based on the number of parameters returned

            If parameterList IsNot Nothing And i < numberOfIn Then
                lblControlP.Visible = True
                lblControlP.Text = parameterList(i)
            Else
                lblControlP.Visible = False
            End If
            If i < numberOfIn Then
                textBoxControlP.Visible = True
            Else
                textBoxControlP.Visible = False
            End If

            'Set controls based on the number of output fields returned
            If outputFieldList IsNot Nothing And i < numberOfOut Then
                lblControlO.Visible = True
                lblControlO.Text = outputFieldList(i)
            Else
                lblControlO.Visible = False
            End If
            If i < numberOfOut Then
                textBoxControlO.Visible = True
            Else
                textBoxControlO.Visible = False
            End If
        Next
    End Sub

    Private Sub cbPorts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPorts.SelectedIndexChanged
        comPortString = cbPorts.SelectedItem.ToString
        Me.btnGetAddresses.PerformClick() 'Change this
    End Sub

#Region "Utilities"

    Private Function TranslateMotorTypeToString(ByVal motorTypeNumber As Integer) As String
        Select Case motorTypeNumber
            Case 0
                Return "PMAC No Encoder Or Hall Sensor Open loop"
            Case 1
                Return "Reserved"
            Case 2
                Return "BLDC Hall Sensor Servo"
            Case 3
                Return "PMAC Encoder Servo"
            Case 4
                Return "Brush No Encoder Open Loop"
            Case 5
                Return "Brush Encoder Servo"
            Case 6
                Return "Stepper No Encoder Open loop"
            Case 7
                Return "Stepper Encoder Open Loop / Monitoring"
            Case 8
                Return "Stepper Encoder Servo"
            Case 9
                Return "BLDC Hall Sensor Open Loop"
            Case Else
                Return ""
        End Select
    End Function

    Private Function GetAddressList() As List(Of Integer)
        Dim addressArray(255) As Integer
        GetAddresses(addressArray)
        Dim addressList As New List(Of Integer)
        For i = 0 To 255
            If addressArray(i) Then
                addressList.Add(i)
            End If
        Next
        Return addressList
    End Function

#End Region

#Region "Dictionary"
    'This dictionary links command names (for GUI) to DLL functions.
    Private Sub BuildPropertyDictionary()
        comboboxBindings.Add("Read Firmware Version", AddressOf GetFWVersion)
        comboboxBindings.Add("Read Encoder Configuration", AddressOf GetEncoderConfiguration)
        comboboxBindings.Add("Read Hall Sensor Configuration", AddressOf GetHallSensorConfiguration)
        comboboxBindings.Add("Read Motor Parameters", AddressOf GetMotorParameters)
        comboboxBindings.Add("Read Motor Type", AddressOf GetMotorType)
        comboboxBindings.Add("Read Control Reference", AddressOf GetControlReference)
        comboboxBindings.Add("Read Drive Address", AddressOf GetDriveAddress)
        comboboxBindings.Add("Read Max Drive Current", AddressOf GetMaxDriveCurrent)
        comboboxBindings.Add("Read Velocity Profile Waveshape", AddressOf GetVelocityProfile)
        comboboxBindings.Add("Read Control Gains", AddressOf GetControlGain)
        comboboxBindings.Add("Is Move Executing", AddressOf IsMoveExecuting)
        comboboxBindings.Add("Read Position Velocity", AddressOf GetPositionVelocity)
        comboboxBindings.Add("Is Input Override", AddressOf IsInputOverride)
        comboboxBindings.Add("Read I/O", AddressOf GetIOReading)
        comboboxBindings.Add("Read Fault Parameters", AddressOf GetFaultParameters)
        comboboxBindings.Add("Read Faults", AddressOf GetFaultReading)
        comboboxBindings.Add("Read Startup Program Name", AddressOf GetStartupProgramName)
        comboboxBindings.Add("Is Program Executing", AddressOf IsProgramExecuting)
        comboboxBindings.Add("Read List Of Program Names", AddressOf GetListProgramNames)
        comboboxBindings.Add("No Operation", AddressOf Noop)
        comboboxBindings.Add("Return From Sub", AddressOf ReturnFromSub)
        comboboxBindings.Add("Single Step", AddressOf SingleStep)
        comboboxBindings.Add("Wait For Move", AddressOf WaitForMove)
        comboboxBindings.Add("Reset Drive", AddressOf Reset)
        comboboxBindings.Add("Abort", AddressOf Abort)
        comboboxBindings.Add("Enable Data Logging", AddressOf EnableDataLogging)
        comboboxBindings.Add("Disable Data Logging", AddressOf DisableDataLogging)
        'Higher index than 26 require parameters.
        comboboxBindings.Add("Configure Encoder", AddressOf SetEncoderConfiguration)
        comboboxBindings.Add("Set Motor Parameters", AddressOf SetMotorParameters)
        comboboxBindings.Add("Set Motor Type", AddressOf SetMotorType)
        comboboxBindings.Add("Set Control Reference", AddressOf SetControlReferenceConfiguration)
        comboboxBindings.Add("Set Drive Address", AddressOf SetDriveAddress)
        comboboxBindings.Add("Set Password", AddressOf SetPassword)
        comboboxBindings.Add("Remove Password", AddressOf RemovePassword)
        comboboxBindings.Add("Move To Position", AddressOf MoveToPosition)
        comboboxBindings.Add("Index Distance", AddressOf IndexDistance)
        comboboxBindings.Add("Go At Speed", AddressOf GoAtSpeed)
        comboboxBindings.Add("Go At Voltage", AddressOf GoAtVoltage)
        comboboxBindings.Add("Go At Torque", AddressOf GoAtTorque)
        comboboxBindings.Add("Immediate Stop", AddressOf ImmediateStop)
        comboboxBindings.Add("Stop", AddressOf StopMovement)
        comboboxBindings.Add("Set Velocity Profile Waveshape", AddressOf SetVelocityProfileWaveshape)
        comboboxBindings.Add("Set Control Gains", AddressOf SetControlGains)
        comboboxBindings.Add("Set Position Origin", AddressOf SetPositionOrigin)
        comboboxBindings.Add("Set Output State", AddressOf SetOutputState)
        comboboxBindings.Add("Set Input Interrupts", AddressOf SetInputInterrupts)
        comboboxBindings.Add("Set Position Limit Fault", AddressOf SetPositionLimitFault)
        comboboxBindings.Add("Set Current Limit Duration Fault", AddressOf SetCurrentLimitDurationFault)
        comboboxBindings.Add("Set Position Error Fault", AddressOf SetPositionErrorFault)
        comboboxBindings.Add("Run Program", AddressOf RunProgram)
        comboboxBindings.Add("Execute Program", AddressOf ExecuteProgram)
        comboboxBindings.Add("Set Startup Program", AddressOf SetStartupProgram)
        comboboxBindings.Add("Delete Program", AddressOf DeleteProgram)
        comboboxBindings.Add("Set Debug Mode", AddressOf SetDebugMode)
        comboboxBindings.Add("Run To Label", AddressOf RunToLabel)
        comboboxBindings.Add("Goto", AddressOf GotoAddress)
        comboboxBindings.Add("Jump N Times", AddressOf JumpNTimes)
        comboboxBindings.Add("Goto If", AddressOf GotoIf)
        comboboxBindings.Add("Goto Sub", AddressOf GotoSub)
        comboboxBindings.Add("Return To", AddressOf ReturnTo)
        comboboxBindings.Add("Wait Command", AddressOf WaitTime)
        comboboxBindings.Add("Label", AddressOf Label)
        comboboxBindings.Add("Comment", AddressOf Comment)
        comboboxBindings.Add("Set Inputs", AddressOf SetInputs)
        comboboxBindings.Add("Enable Input Override", AddressOf SetInputOverride)
        'comboboxBindings.Add("Get Non-Volitile Parameter", AddressOf GetNVParameter)
        'comboboxBindings.Add("Download Program", AddressOf DownloadProgram)
        'comboboxBindings.Add("Is Password Valid", AddressOf IsValidPassword)
        'comboboxBindings.Add("Recall Program", AddressOf RecallProgram)
        'comboboxBindings.Add("Update Firmware", AddressOf UpdateFirmware)
        'comboboxBindings.Add("Restore Factory Defaults", AddressOf RestoreFactoryDefaults)
        'comboboxBindings.Add("Read Factroy Configuration", AddressOf GetFactoryConfiguration)
    End Sub

#End Region

End Class
