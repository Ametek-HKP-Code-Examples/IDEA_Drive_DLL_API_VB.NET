﻿Imports DLLImports 'See API documentation for details
Imports System.Text

Public Class FrmCommandTester
    Private comPortString As String
    Public SOFTWARE_VERSION = My.Application.Info.Version.ToString 'Software Version change this in Project Properties/Application/Assembly Information
    Private comboboxBindings As New Dictionary(Of String, Action(Of StringBuilder, Integer))()
    Private selectedCommand As String
    Private IDEADrivefunctionToInvoke As Action(Of StringBuilder, Integer)
    Private portChecker As IO.Ports.SerialPort = Nothing

#Region "Initialization & Closing"
    Private Sub FrmCommandTester_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Label name and version
        Me.Text = "IDEA Drive DLL Command Software" & " - Version:" & SOFTWARE_VERSION
        BuildPropertyDictionary()
        InitializeCommandSet()
        cbCommands.Items.AddRange(comboboxBindings.Keys.ToArray())
        cbCommands.SelectedIndex = 0
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
    End Sub

    Private Sub FrmCommandTester_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CleanUp()
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
        Try
            tbRSP.Text = "" 'Clear response textbox 
            Dim Size As Integer = 1024 'Largest size (bytes) that DLL can fill
            Dim Buffer As New StringBuilder(Size)
            Dim portHandleAddress As Integer

            If cbCommands.SelectedIndex > 26 Then 'Index higher than 26 requires parameter(s).
                Buffer.Append(tbParams.Text)
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
        tbRSP.Text = resultString
    End Sub

    'This function will scan the selected port for IDEA Drives by sending a command and waiting for a response. 
    'NOTE: address, command character And return characters ARE accounted for.
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
    'Go At Speed:   Q426666,0,0,426666,426666,1000,1000,1000,1000,50,64
    'Stop:          E5000,5000,50

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
        ' Determine the maximum size of the output string
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

    'Private Sub btnDemo_Click(sender As Object, e As EventArgs) Handles btnDemo.Click
    '    Dim portHandleAddress As Integer = OpenSerial(comPortString)
    '    Dim defaultAddr As String = cbAddresses.Items(cbAddresses.SelectedIndex).ToString
    '    defaultAddr = defaultAddr.PadLeft(3, "0")
    '    Dim inputBufferSize As Integer = defaultAddr.Length
    '    'Dim inputBufferSize As Integer = inputBuffer.Length
    '    ' Determine the maximum size of the output string (DLL max is currently 1024).
    '    Dim outputSize As Integer = 1024
    '    Dim outputBuffer As New StringBuilder(outputSize)
    '    tbRSP.Text = "Index Demo"
    '    tbRSP.Refresh()
    '    Dim inputBuffer As String
    '    'Call the DLL method
    '    For i = 0 To 200
    '        inputBuffer = "Q-6400,0,0,200000,100000,2000,500,2000,2000,50,8"
    '        SetCurrentAddress("001", inputBufferSize)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        System.Threading.Thread.Sleep(250)
    '        SetCurrentAddress("002", inputBufferSize)
    '        inputBuffer = "Q12800,0,0,200000,100000,2000,500,2000,2000,50,8"
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        System.Threading.Thread.Sleep(250)
    '        SetCurrentAddress("003", inputBufferSize)
    '        inputBuffer = "Q-25600,0,0,200000,100000,2000,500,2000,2000,50,8"
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        System.Threading.Thread.Sleep(250)
    '        SetCurrentAddress("004", inputBufferSize)
    '        inputBuffer = "Q51200,0,0,200000,100000,2000,500,2000,2000,50,8"
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        System.Threading.Thread.Sleep(250)
    '        SetCurrentAddress("005", inputBufferSize)
    '        inputBuffer = "Q-102400,0,0,200000,100000,2000,500,2000,2000,50,8"
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        System.Threading.Thread.Sleep(5000)
    '        SetCurrentAddress("", inputBufferSize)
    '        inputBuffer = "E1500,500,50"
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        tbRSP.Text = "Staggered Demo"
    '        tbRSP.Refresh()
    '        For j = 0 To 3
    '            inputBuffer = "I12800,60000,2000,2000,100000,100000,1000,1000,1500,1500,50,16"
    '            StaggeredMovement(inputBuffer, inputBufferSize, outputBuffer, outputSize, 100)
    '            inputBuffer = "I-12800,60000,2000,2000,100000,100000,1000,1000,1500,1500,50,16"
    '            StaggeredMovementRev(inputBuffer, inputBufferSize, outputBuffer, outputSize, 100)
    '        Next
    '        tbRSP.Text = "Speed Demo"
    '        tbRSP.Refresh()
    '        inputBuffer = "Q500000,0,0,300000,300000,2000,500,2000,2000,50,8"
    '        SetCurrentAddress("1", inputBufferSize)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        inputBuffer = "Q600000,0,0,300000,300000,2000,500,2000,2000,50,8"
    '        SetCurrentAddress("2", inputBufferSize)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        inputBuffer = "Q600000,0,0,300000,300000,2000,500,2000,2000,50,8"
    '        SetCurrentAddress("3", inputBufferSize)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        inputBuffer = "Q600000,0,0,300000,300000,2000,500,2000,2000,50,8"
    '        SetCurrentAddress("4", inputBufferSize)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        inputBuffer = "Q600000,0,0,300000,300000,2000,500,2000,2000,50,8"
    '        SetCurrentAddress("5", inputBufferSize)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)

    '        inputBuffer = "I-64000,500000,2000,2000,100000,100000,2000,2000,2000,2000,50,16"
    '        SetCurrentAddress("20", inputBufferSize)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        inputBuffer = "I64000,500000,2000,2000,100000,100000,2000,2000,2000,2000,50,16"
    '        System.Threading.Thread.Sleep(1750)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        inputBuffer = "I-64000,500000,2000,2000,100000,100000,2000,2000,2000,2000,50,16"
    '        System.Threading.Thread.Sleep(1750)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        inputBuffer = "I64000,500000,2000,2000,100000,100000,2000,2000,2000,2000,50,16"
    '        System.Threading.Thread.Sleep(1750)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        inputBuffer = "I-64000,500000,2000,2000,100000,100000,2000,2000,2000,2000,50,16"
    '        System.Threading.Thread.Sleep(1750)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        inputBuffer = "I64000,500000,2000,2000,100000,100000,2000,2000,2000,2000,50,16"
    '        System.Threading.Thread.Sleep(1750)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        inputBuffer = "I-64000,500000,2000,2000,100000,100000,2000,2000,2000,2000,50,16"
    '        System.Threading.Thread.Sleep(1750)
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        SetCurrentAddress("", inputBufferSize)
    '        System.Threading.Thread.Sleep(1750)
    '        inputBuffer = "E1500,500,100"
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        System.Threading.Thread.Sleep(3000)
    '        inputBuffer = "A"
    '        SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '        System.Threading.Thread.Sleep(3000)
    '    Next
    '    CloseSerial()
    'End Sub

    'Sub StaggeredMovement(inputBuffer As String, inputBufferSize As Integer, outputBuffer As StringBuilder, outputSize As Integer, delayTime As Integer)
    '    SetCurrentAddress("001", inputBufferSize)
    '    SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '    System.Threading.Thread.Sleep(delayTime)
    '    SetCurrentAddress("002", inputBufferSize)
    '    SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '    System.Threading.Thread.Sleep(delayTime)
    '    SetCurrentAddress("003", inputBufferSize)
    '    SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '    System.Threading.Thread.Sleep(delayTime)
    '    SetCurrentAddress("004", inputBufferSize)
    '    SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '    System.Threading.Thread.Sleep(delayTime)
    '    SetCurrentAddress("005", inputBufferSize)
    '    SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '    System.Threading.Thread.Sleep(500)
    'End Sub

    'Sub StaggeredMovementRev(inputBuffer As String, inputBufferSize As Integer, outputBuffer As StringBuilder, outputSize As Integer, delayTime As Integer)
    '    SetCurrentAddress("005", inputBufferSize)
    '    SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '    System.Threading.Thread.Sleep(delayTime)
    '    SetCurrentAddress("004", inputBufferSize)
    '    SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '    System.Threading.Thread.Sleep(delayTime)
    '    SetCurrentAddress("003", inputBufferSize)
    '    SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '    System.Threading.Thread.Sleep(delayTime)
    '    SetCurrentAddress("002", inputBufferSize)
    '    SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '    System.Threading.Thread.Sleep(delayTime)
    '    SetCurrentAddress("001", inputBufferSize)
    '    SendCommand(inputBuffer.ToString, outputBuffer, outputSize)
    '    System.Threading.Thread.Sleep(500)
    'End Sub

    Private Sub cbCommands_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCommands.SelectedIndexChanged
        selectedCommand = DirectCast(cbCommands.SelectedItem, String)
        IDEADrivefunctionToInvoke = comboboxBindings(selectedCommand)
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
        comboboxBindings.Add("Read Control Gain", AddressOf GetControlGain)
        comboboxBindings.Add("Is Move Executing", AddressOf IsMoveExecuting)
        comboboxBindings.Add("Read Position Velocity", AddressOf GetPositionVelocity)
        comboboxBindings.Add("Is Input Override", AddressOf IsInputOverride)
        comboboxBindings.Add("Read I/O", AddressOf GetIOReading)
        comboboxBindings.Add("Read Fault Parameters", AddressOf GetFaultParameters)
        comboboxBindings.Add("Read Fault", AddressOf GetFaultReading)
        comboboxBindings.Add("Read Startup Program Name", AddressOf GetStartupProgramName)
        comboboxBindings.Add("Is Program Executing", AddressOf IsProgramExecuting)
        comboboxBindings.Add("Read List Of Program Names", AddressOf GetListProgramNames)
        comboboxBindings.Add("No Operation", AddressOf Noop)
        comboboxBindings.Add("Return From Sub", AddressOf ReturnFromSub)
        comboboxBindings.Add("Single Step", AddressOf SingleStep)
        comboboxBindings.Add("Wait For Move", AddressOf WaitForMove)
        comboboxBindings.Add("Reset", AddressOf Reset)
        comboboxBindings.Add("Abort", AddressOf Abort)
        comboboxBindings.Add("Enable Data Logging", AddressOf EnableDataLogging)
        comboboxBindings.Add("Disable Data Logging", AddressOf DisableDataLogging)
        'Higher index than 26 require parameters.
        comboboxBindings.Add("Configure Encoder", AddressOf SetEncoderConfiguration)
        comboboxBindings.Add("Set Hall Sensor Configuration", AddressOf SetHallSensorConfiguration)
        comboboxBindings.Add("Set Motor Parameters", AddressOf SetMotorParameters)
        comboboxBindings.Add("Set Motor Type", AddressOf SetMotorType)
        comboboxBindings.Add("Set Control Reference Configuration", AddressOf SetControlReferenceConfiguration)
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
        comboboxBindings.Add("Wait", AddressOf WaitTime)
        comboboxBindings.Add("Label", AddressOf Label)
        comboboxBindings.Add("Comment", AddressOf Comment)
        comboboxBindings.Add("Set Inputs", AddressOf SetInputs)
        comboboxBindings.Add("Set Input Override", AddressOf SetInputOverride)
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
