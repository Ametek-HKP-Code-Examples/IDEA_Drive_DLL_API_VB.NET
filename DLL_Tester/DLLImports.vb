Imports System.Runtime.InteropServices
Imports System.Text

Public Module DLLImports
    'For x64
    Public Const DLLPath As String = "..\IDEADriveCommandx64.dll" '------ENTER DLL PATH HERE-------
    'For x86, uncomment next line and comment out the line above.
    'Public Const DLLPath As String = "..\IDEADriveCommandx86.dll" '------ENTER DLL PATH HERE-------

    'Serial Port & Addressing
    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function OpenSerial(ByVal input As String) As Integer
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CloseSerial() As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function IsSerialOpen() As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub SetCurrentAddress(ByVal input As String, ByVal inputSize As Integer)
    End Sub

    'IDEA DRIVE Command Functions
    'Generic
    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub SendCommand(ByVal input As String, ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    'ReadOnly Functions
    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetMotorType(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetAddresses(ByVal ba As Integer())
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetFWVersion(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetHallSensorConfiguration(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetEncoderConfiguration(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetMotorParameters(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetControlReference(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetDriveAddress(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetMaxDriveCurrent(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetFactoryConfiguration(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetVelocityProfile(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetControlGain(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub IsMoveExecuting(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetPositionVelocity(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub IsInputOverride(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetIOReading(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetFaultParameters(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetFaultReading(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetStartupProgramName(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub IsProgramExecuting(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetListProgramNames(ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    'No R/W Functions
    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub Noop()
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub ReturnFromSub()
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub SingleStep()
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub WaitForMove()
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub Reset()
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub Abort()
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub EnableDataLogging()
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub DisableDataLogging()
    End Sub

    'WriteOnly Functions
    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetEncoderConfiguration(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetHallSensorConfiguration(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetMotorParameters(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetMotorType(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetControlReferenceConfiguration(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetDriveAddress(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetPassword(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function RemovePassword(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function MoveToPosition(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function IndexDistance(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GoAtSpeed(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GoAtVoltage(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GoAtTorque(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ImmediateStop(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function StopMovement(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetVelocityProfileWaveshape(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetControlGains(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetPositionOrigin(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetOutputState(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetInputInterrupts(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetPositionLimitFault(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetCurrentLimitDurationFault(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetPositionErrorFault(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function RunProgram(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ExecuteProgram(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetStartupProgram(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function DeleteProgram(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetDebugMode(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function RunToLabel(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GotoAddress(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function JumpNTimes(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GotoIf(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GotoSub(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ReturnTo(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function WaitTime(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function Label(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function Comment(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetInputs(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetInputOverride(ByVal input As StringBuilder, ByVal inputSize As Integer) As Boolean
    End Function

    'Misc Functions
    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GetNVParameter(ByVal input As String, ByVal output As StringBuilder, ByVal outputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function DownloadProgram(ByVal input As String, ByVal output As StringBuilder, ByVal outputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function IsValidPassword(ByVal input As String, ByVal output As StringBuilder, ByVal outputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function RecallProgram(ByVal input As String, ByVal output As StringBuilder, ByVal outputSize As Integer) As Boolean
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function UpdateFirmware(ByVal doubleCheck As Boolean) As Boolean
    End Function

    'Information & Data Functions
    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub InitializeCommandSet()
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetCommandName(ByVal input As String, ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetDescriptiveName(ByVal input As String, ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GetNumberOfParametersS(ByVal input As String) As Integer
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GetNumberOfParametersC(ByVal input As String) As Integer
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GetNumberOfOutputsS(ByVal input As String) As Integer
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GetNumberOfOutputsC(ByVal input As String) As Integer
    End Function

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetCommandLetterFromCommand(ByVal input As String, ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetCommandLetterFromDescriptive(ByVal input As String, ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetParameterList(ByVal input As String, ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetOutputFieldList(ByVal input As String, ByVal output As StringBuilder, ByVal outputSize As Integer)
    End Sub

    <DllImport(DLLPath, CallingConvention:=CallingConvention.Cdecl)>
    Public Sub GetCommandList(ByVal output As StringBuilder)
    End Sub

End Module
