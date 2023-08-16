<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCommandTester
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnGetAddresses = New System.Windows.Forms.Button()
        Me.btnSendCommand = New System.Windows.Forms.Button()
        Me.tbCMD = New System.Windows.Forms.TextBox()
        Me.tbRSP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbAddresses = New System.Windows.Forms.ComboBox()
        Me.cbCommands = New System.Windows.Forms.ComboBox()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.tbParams0 = New System.Windows.Forms.TextBox()
        Me.lblParams0 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbPorts = New System.Windows.Forms.ComboBox()
        Me.btnPorts = New System.Windows.Forms.Button()
        Me.lblParams1 = New System.Windows.Forms.Label()
        Me.tbParams1 = New System.Windows.Forms.TextBox()
        Me.lblParams2 = New System.Windows.Forms.Label()
        Me.tbParams2 = New System.Windows.Forms.TextBox()
        Me.lblParams3 = New System.Windows.Forms.Label()
        Me.tbParams3 = New System.Windows.Forms.TextBox()
        Me.lblParams4 = New System.Windows.Forms.Label()
        Me.tbParams4 = New System.Windows.Forms.TextBox()
        Me.lblParams9 = New System.Windows.Forms.Label()
        Me.tbParams9 = New System.Windows.Forms.TextBox()
        Me.lblParams8 = New System.Windows.Forms.Label()
        Me.tbParams8 = New System.Windows.Forms.TextBox()
        Me.lblParams7 = New System.Windows.Forms.Label()
        Me.tbParams7 = New System.Windows.Forms.TextBox()
        Me.lblParams6 = New System.Windows.Forms.Label()
        Me.tbParams6 = New System.Windows.Forms.TextBox()
        Me.lblParams5 = New System.Windows.Forms.Label()
        Me.tbParams5 = New System.Windows.Forms.TextBox()
        Me.lblParams11 = New System.Windows.Forms.Label()
        Me.tbParams11 = New System.Windows.Forms.TextBox()
        Me.lblParams10 = New System.Windows.Forms.Label()
        Me.tbParams10 = New System.Windows.Forms.TextBox()
        Me.gbParameters = New System.Windows.Forms.GroupBox()
        Me.tbOutput0 = New System.Windows.Forms.TextBox()
        Me.lblOutput0 = New System.Windows.Forms.Label()
        Me.tbOutput1 = New System.Windows.Forms.TextBox()
        Me.lblOutput1 = New System.Windows.Forms.Label()
        Me.tbOutput2 = New System.Windows.Forms.TextBox()
        Me.lblOutput2 = New System.Windows.Forms.Label()
        Me.tbOutput3 = New System.Windows.Forms.TextBox()
        Me.lblOutput3 = New System.Windows.Forms.Label()
        Me.tbOutput4 = New System.Windows.Forms.TextBox()
        Me.lblOutput4 = New System.Windows.Forms.Label()
        Me.tbOutput5 = New System.Windows.Forms.TextBox()
        Me.lblOutput5 = New System.Windows.Forms.Label()
        Me.tbOutput6 = New System.Windows.Forms.TextBox()
        Me.lblOutput6 = New System.Windows.Forms.Label()
        Me.tbOutput7 = New System.Windows.Forms.TextBox()
        Me.lblOutput7 = New System.Windows.Forms.Label()
        Me.tbOutput8 = New System.Windows.Forms.TextBox()
        Me.lblOutput8 = New System.Windows.Forms.Label()
        Me.tbOutput9 = New System.Windows.Forms.TextBox()
        Me.lblOutput9 = New System.Windows.Forms.Label()
        Me.tbOutput10 = New System.Windows.Forms.TextBox()
        Me.lblOutput10 = New System.Windows.Forms.Label()
        Me.tbOutput11 = New System.Windows.Forms.TextBox()
        Me.lblOutput11 = New System.Windows.Forms.Label()
        Me.gbOutput = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbParameters.SuspendLayout()
        Me.gbOutput.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGetAddresses
        '
        Me.btnGetAddresses.Location = New System.Drawing.Point(10, 37)
        Me.btnGetAddresses.Name = "btnGetAddresses"
        Me.btnGetAddresses.Size = New System.Drawing.Size(142, 21)
        Me.btnGetAddresses.TabIndex = 4
        Me.btnGetAddresses.Text = "Get Address List"
        Me.btnGetAddresses.UseVisualStyleBackColor = True
        '
        'btnSendCommand
        '
        Me.btnSendCommand.Location = New System.Drawing.Point(94, 11)
        Me.btnSendCommand.Name = "btnSendCommand"
        Me.btnSendCommand.Size = New System.Drawing.Size(262, 26)
        Me.btnSendCommand.TabIndex = 6
        Me.btnSendCommand.Text = "Send Command"
        Me.btnSendCommand.UseVisualStyleBackColor = True
        '
        'tbCMD
        '
        Me.tbCMD.Location = New System.Drawing.Point(94, 42)
        Me.tbCMD.Name = "tbCMD"
        Me.tbCMD.Size = New System.Drawing.Size(262, 20)
        Me.tbCMD.TabIndex = 7
        '
        'tbRSP
        '
        Me.tbRSP.Location = New System.Drawing.Point(94, 69)
        Me.tbRSP.Name = "tbRSP"
        Me.tbRSP.ReadOnly = True
        Me.tbRSP.Size = New System.Drawing.Size(262, 20)
        Me.tbRSP.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Command:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Response:"
        '
        'cbAddresses
        '
        Me.cbAddresses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAddresses.Enabled = False
        Me.cbAddresses.FormattingEnabled = True
        Me.cbAddresses.Location = New System.Drawing.Point(154, 38)
        Me.cbAddresses.Name = "cbAddresses"
        Me.cbAddresses.Size = New System.Drawing.Size(72, 21)
        Me.cbAddresses.TabIndex = 11
        '
        'cbCommands
        '
        Me.cbCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCommands.Enabled = False
        Me.cbCommands.FormattingEnabled = True
        Me.cbCommands.Location = New System.Drawing.Point(154, 80)
        Me.cbCommands.Name = "cbCommands"
        Me.cbCommands.Size = New System.Drawing.Size(176, 21)
        Me.cbCommands.TabIndex = 13
        '
        'btnExecute
        '
        Me.btnExecute.Enabled = False
        Me.btnExecute.Location = New System.Drawing.Point(10, 79)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(142, 21)
        Me.btnExecute.TabIndex = 14
        Me.btnExecute.Text = "Execute Command"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'tbParams0
        '
        Me.tbParams0.Location = New System.Drawing.Point(142, 19)
        Me.tbParams0.Name = "tbParams0"
        Me.tbParams0.Size = New System.Drawing.Size(186, 20)
        Me.tbParams0.TabIndex = 15
        Me.tbParams0.Visible = False
        '
        'lblParams0
        '
        Me.lblParams0.AutoSize = True
        Me.lblParams0.Location = New System.Drawing.Point(6, 22)
        Me.lblParams0.Name = "lblParams0"
        Me.lblParams0.Size = New System.Drawing.Size(63, 13)
        Me.lblParams0.TabIndex = 16
        Me.lblParams0.Text = "Parameters:"
        Me.lblParams0.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(157, 13)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Port Number:"
        '
        'cbPorts
        '
        Me.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPorts.FormattingEnabled = True
        Me.cbPorts.Location = New System.Drawing.Point(230, 10)
        Me.cbPorts.Margin = New System.Windows.Forms.Padding(2)
        Me.cbPorts.Name = "cbPorts"
        Me.cbPorts.Size = New System.Drawing.Size(92, 21)
        Me.cbPorts.TabIndex = 18
        '
        'btnPorts
        '
        Me.btnPorts.Location = New System.Drawing.Point(10, 9)
        Me.btnPorts.Name = "btnPorts"
        Me.btnPorts.Size = New System.Drawing.Size(142, 21)
        Me.btnPorts.TabIndex = 19
        Me.btnPorts.Text = "Scan Serial Ports"
        Me.btnPorts.UseVisualStyleBackColor = True
        '
        'lblParams1
        '
        Me.lblParams1.AutoSize = True
        Me.lblParams1.Location = New System.Drawing.Point(6, 48)
        Me.lblParams1.Name = "lblParams1"
        Me.lblParams1.Size = New System.Drawing.Size(63, 13)
        Me.lblParams1.TabIndex = 21
        Me.lblParams1.Text = "Parameters:"
        Me.lblParams1.Visible = False
        '
        'tbParams1
        '
        Me.tbParams1.Location = New System.Drawing.Point(142, 45)
        Me.tbParams1.Name = "tbParams1"
        Me.tbParams1.Size = New System.Drawing.Size(186, 20)
        Me.tbParams1.TabIndex = 20
        Me.tbParams1.Visible = False
        '
        'lblParams2
        '
        Me.lblParams2.AutoSize = True
        Me.lblParams2.Location = New System.Drawing.Point(6, 74)
        Me.lblParams2.Name = "lblParams2"
        Me.lblParams2.Size = New System.Drawing.Size(63, 13)
        Me.lblParams2.TabIndex = 23
        Me.lblParams2.Text = "Parameters:"
        Me.lblParams2.Visible = False
        '
        'tbParams2
        '
        Me.tbParams2.Location = New System.Drawing.Point(142, 71)
        Me.tbParams2.Name = "tbParams2"
        Me.tbParams2.Size = New System.Drawing.Size(186, 20)
        Me.tbParams2.TabIndex = 22
        Me.tbParams2.Visible = False
        '
        'lblParams3
        '
        Me.lblParams3.AutoSize = True
        Me.lblParams3.Location = New System.Drawing.Point(6, 100)
        Me.lblParams3.Name = "lblParams3"
        Me.lblParams3.Size = New System.Drawing.Size(63, 13)
        Me.lblParams3.TabIndex = 25
        Me.lblParams3.Text = "Parameters:"
        Me.lblParams3.Visible = False
        '
        'tbParams3
        '
        Me.tbParams3.Location = New System.Drawing.Point(142, 97)
        Me.tbParams3.Name = "tbParams3"
        Me.tbParams3.Size = New System.Drawing.Size(186, 20)
        Me.tbParams3.TabIndex = 24
        Me.tbParams3.Visible = False
        '
        'lblParams4
        '
        Me.lblParams4.AutoSize = True
        Me.lblParams4.Location = New System.Drawing.Point(6, 126)
        Me.lblParams4.Name = "lblParams4"
        Me.lblParams4.Size = New System.Drawing.Size(63, 13)
        Me.lblParams4.TabIndex = 27
        Me.lblParams4.Text = "Parameters:"
        Me.lblParams4.Visible = False
        '
        'tbParams4
        '
        Me.tbParams4.Location = New System.Drawing.Point(142, 123)
        Me.tbParams4.Name = "tbParams4"
        Me.tbParams4.Size = New System.Drawing.Size(186, 20)
        Me.tbParams4.TabIndex = 26
        Me.tbParams4.Visible = False
        '
        'lblParams9
        '
        Me.lblParams9.AutoSize = True
        Me.lblParams9.Location = New System.Drawing.Point(6, 256)
        Me.lblParams9.Name = "lblParams9"
        Me.lblParams9.Size = New System.Drawing.Size(63, 13)
        Me.lblParams9.TabIndex = 37
        Me.lblParams9.Text = "Parameters:"
        Me.lblParams9.Visible = False
        '
        'tbParams9
        '
        Me.tbParams9.Location = New System.Drawing.Point(142, 253)
        Me.tbParams9.Name = "tbParams9"
        Me.tbParams9.Size = New System.Drawing.Size(186, 20)
        Me.tbParams9.TabIndex = 36
        Me.tbParams9.Visible = False
        '
        'lblParams8
        '
        Me.lblParams8.AutoSize = True
        Me.lblParams8.Location = New System.Drawing.Point(6, 230)
        Me.lblParams8.Name = "lblParams8"
        Me.lblParams8.Size = New System.Drawing.Size(63, 13)
        Me.lblParams8.TabIndex = 35
        Me.lblParams8.Text = "Parameters:"
        Me.lblParams8.Visible = False
        '
        'tbParams8
        '
        Me.tbParams8.Location = New System.Drawing.Point(142, 227)
        Me.tbParams8.Name = "tbParams8"
        Me.tbParams8.Size = New System.Drawing.Size(186, 20)
        Me.tbParams8.TabIndex = 34
        Me.tbParams8.Visible = False
        '
        'lblParams7
        '
        Me.lblParams7.AutoSize = True
        Me.lblParams7.Location = New System.Drawing.Point(6, 204)
        Me.lblParams7.Name = "lblParams7"
        Me.lblParams7.Size = New System.Drawing.Size(63, 13)
        Me.lblParams7.TabIndex = 33
        Me.lblParams7.Text = "Parameters:"
        Me.lblParams7.Visible = False
        '
        'tbParams7
        '
        Me.tbParams7.Location = New System.Drawing.Point(142, 201)
        Me.tbParams7.Name = "tbParams7"
        Me.tbParams7.Size = New System.Drawing.Size(186, 20)
        Me.tbParams7.TabIndex = 32
        Me.tbParams7.Visible = False
        '
        'lblParams6
        '
        Me.lblParams6.AutoSize = True
        Me.lblParams6.Location = New System.Drawing.Point(6, 178)
        Me.lblParams6.Name = "lblParams6"
        Me.lblParams6.Size = New System.Drawing.Size(63, 13)
        Me.lblParams6.TabIndex = 31
        Me.lblParams6.Text = "Parameters:"
        Me.lblParams6.Visible = False
        '
        'tbParams6
        '
        Me.tbParams6.Location = New System.Drawing.Point(142, 175)
        Me.tbParams6.Name = "tbParams6"
        Me.tbParams6.Size = New System.Drawing.Size(186, 20)
        Me.tbParams6.TabIndex = 30
        Me.tbParams6.Visible = False
        '
        'lblParams5
        '
        Me.lblParams5.AutoSize = True
        Me.lblParams5.Location = New System.Drawing.Point(6, 152)
        Me.lblParams5.Name = "lblParams5"
        Me.lblParams5.Size = New System.Drawing.Size(63, 13)
        Me.lblParams5.TabIndex = 29
        Me.lblParams5.Text = "Parameters:"
        Me.lblParams5.Visible = False
        '
        'tbParams5
        '
        Me.tbParams5.Location = New System.Drawing.Point(142, 149)
        Me.tbParams5.Name = "tbParams5"
        Me.tbParams5.Size = New System.Drawing.Size(186, 20)
        Me.tbParams5.TabIndex = 28
        Me.tbParams5.Visible = False
        '
        'lblParams11
        '
        Me.lblParams11.AutoSize = True
        Me.lblParams11.Location = New System.Drawing.Point(6, 308)
        Me.lblParams11.Name = "lblParams11"
        Me.lblParams11.Size = New System.Drawing.Size(63, 13)
        Me.lblParams11.TabIndex = 41
        Me.lblParams11.Text = "Parameters:"
        Me.lblParams11.Visible = False
        '
        'tbParams11
        '
        Me.tbParams11.Location = New System.Drawing.Point(142, 305)
        Me.tbParams11.Name = "tbParams11"
        Me.tbParams11.Size = New System.Drawing.Size(186, 20)
        Me.tbParams11.TabIndex = 40
        Me.tbParams11.Visible = False
        '
        'lblParams10
        '
        Me.lblParams10.AutoSize = True
        Me.lblParams10.Location = New System.Drawing.Point(6, 282)
        Me.lblParams10.Name = "lblParams10"
        Me.lblParams10.Size = New System.Drawing.Size(63, 13)
        Me.lblParams10.TabIndex = 39
        Me.lblParams10.Text = "Parameters:"
        Me.lblParams10.Visible = False
        '
        'tbParams10
        '
        Me.tbParams10.Location = New System.Drawing.Point(142, 279)
        Me.tbParams10.Name = "tbParams10"
        Me.tbParams10.Size = New System.Drawing.Size(186, 20)
        Me.tbParams10.TabIndex = 38
        Me.tbParams10.Visible = False
        '
        'gbParameters
        '
        Me.gbParameters.Controls.Add(Me.lblParams0)
        Me.gbParameters.Controls.Add(Me.tbParams0)
        Me.gbParameters.Controls.Add(Me.tbParams1)
        Me.gbParameters.Controls.Add(Me.lblParams1)
        Me.gbParameters.Controls.Add(Me.tbParams2)
        Me.gbParameters.Controls.Add(Me.lblParams2)
        Me.gbParameters.Controls.Add(Me.tbParams3)
        Me.gbParameters.Controls.Add(Me.lblParams3)
        Me.gbParameters.Controls.Add(Me.tbParams4)
        Me.gbParameters.Controls.Add(Me.lblParams4)
        Me.gbParameters.Controls.Add(Me.tbParams5)
        Me.gbParameters.Controls.Add(Me.lblParams5)
        Me.gbParameters.Controls.Add(Me.tbParams6)
        Me.gbParameters.Controls.Add(Me.lblParams6)
        Me.gbParameters.Controls.Add(Me.tbParams7)
        Me.gbParameters.Controls.Add(Me.lblParams7)
        Me.gbParameters.Controls.Add(Me.tbParams8)
        Me.gbParameters.Controls.Add(Me.lblParams8)
        Me.gbParameters.Controls.Add(Me.tbParams9)
        Me.gbParameters.Controls.Add(Me.lblParams9)
        Me.gbParameters.Controls.Add(Me.tbParams10)
        Me.gbParameters.Controls.Add(Me.lblParams10)
        Me.gbParameters.Controls.Add(Me.tbParams11)
        Me.gbParameters.Controls.Add(Me.lblParams11)
        Me.gbParameters.Location = New System.Drawing.Point(12, 106)
        Me.gbParameters.Name = "gbParameters"
        Me.gbParameters.Size = New System.Drawing.Size(339, 342)
        Me.gbParameters.TabIndex = 66
        Me.gbParameters.TabStop = False
        Me.gbParameters.Text = "Parameters"
        '
        'tbOutput0
        '
        Me.tbOutput0.Enabled = False
        Me.tbOutput0.Location = New System.Drawing.Point(179, 19)
        Me.tbOutput0.Name = "tbOutput0"
        Me.tbOutput0.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput0.TabIndex = 42
        Me.tbOutput0.Visible = False
        '
        'lblOutput0
        '
        Me.lblOutput0.AutoSize = True
        Me.lblOutput0.Location = New System.Drawing.Point(6, 22)
        Me.lblOutput0.Name = "lblOutput0"
        Me.lblOutput0.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput0.TabIndex = 43
        Me.lblOutput0.Text = "Output:"
        Me.lblOutput0.Visible = False
        '
        'tbOutput1
        '
        Me.tbOutput1.Enabled = False
        Me.tbOutput1.Location = New System.Drawing.Point(179, 45)
        Me.tbOutput1.Name = "tbOutput1"
        Me.tbOutput1.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput1.TabIndex = 44
        Me.tbOutput1.Visible = False
        '
        'lblOutput1
        '
        Me.lblOutput1.AutoSize = True
        Me.lblOutput1.Location = New System.Drawing.Point(6, 48)
        Me.lblOutput1.Name = "lblOutput1"
        Me.lblOutput1.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput1.TabIndex = 45
        Me.lblOutput1.Text = "Output:"
        Me.lblOutput1.Visible = False
        '
        'tbOutput2
        '
        Me.tbOutput2.Enabled = False
        Me.tbOutput2.Location = New System.Drawing.Point(179, 71)
        Me.tbOutput2.Name = "tbOutput2"
        Me.tbOutput2.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput2.TabIndex = 46
        Me.tbOutput2.Visible = False
        '
        'lblOutput2
        '
        Me.lblOutput2.AutoSize = True
        Me.lblOutput2.Location = New System.Drawing.Point(6, 74)
        Me.lblOutput2.Name = "lblOutput2"
        Me.lblOutput2.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput2.TabIndex = 47
        Me.lblOutput2.Text = "Output:"
        Me.lblOutput2.Visible = False
        '
        'tbOutput3
        '
        Me.tbOutput3.Enabled = False
        Me.tbOutput3.Location = New System.Drawing.Point(179, 97)
        Me.tbOutput3.Name = "tbOutput3"
        Me.tbOutput3.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput3.TabIndex = 48
        Me.tbOutput3.Visible = False
        '
        'lblOutput3
        '
        Me.lblOutput3.AutoSize = True
        Me.lblOutput3.Location = New System.Drawing.Point(6, 100)
        Me.lblOutput3.Name = "lblOutput3"
        Me.lblOutput3.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput3.TabIndex = 49
        Me.lblOutput3.Text = "Output:"
        Me.lblOutput3.Visible = False
        '
        'tbOutput4
        '
        Me.tbOutput4.Enabled = False
        Me.tbOutput4.Location = New System.Drawing.Point(179, 123)
        Me.tbOutput4.Name = "tbOutput4"
        Me.tbOutput4.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput4.TabIndex = 50
        Me.tbOutput4.Visible = False
        '
        'lblOutput4
        '
        Me.lblOutput4.AutoSize = True
        Me.lblOutput4.Location = New System.Drawing.Point(6, 126)
        Me.lblOutput4.Name = "lblOutput4"
        Me.lblOutput4.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput4.TabIndex = 51
        Me.lblOutput4.Text = "Output:"
        Me.lblOutput4.Visible = False
        '
        'tbOutput5
        '
        Me.tbOutput5.Enabled = False
        Me.tbOutput5.Location = New System.Drawing.Point(179, 149)
        Me.tbOutput5.Name = "tbOutput5"
        Me.tbOutput5.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput5.TabIndex = 52
        Me.tbOutput5.Visible = False
        '
        'lblOutput5
        '
        Me.lblOutput5.AutoSize = True
        Me.lblOutput5.Location = New System.Drawing.Point(6, 152)
        Me.lblOutput5.Name = "lblOutput5"
        Me.lblOutput5.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput5.TabIndex = 53
        Me.lblOutput5.Text = "Output:"
        Me.lblOutput5.Visible = False
        '
        'tbOutput6
        '
        Me.tbOutput6.Enabled = False
        Me.tbOutput6.Location = New System.Drawing.Point(179, 175)
        Me.tbOutput6.Name = "tbOutput6"
        Me.tbOutput6.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput6.TabIndex = 54
        Me.tbOutput6.Visible = False
        '
        'lblOutput6
        '
        Me.lblOutput6.AutoSize = True
        Me.lblOutput6.Location = New System.Drawing.Point(6, 178)
        Me.lblOutput6.Name = "lblOutput6"
        Me.lblOutput6.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput6.TabIndex = 55
        Me.lblOutput6.Text = "Output:"
        Me.lblOutput6.Visible = False
        '
        'tbOutput7
        '
        Me.tbOutput7.Enabled = False
        Me.tbOutput7.Location = New System.Drawing.Point(179, 201)
        Me.tbOutput7.Name = "tbOutput7"
        Me.tbOutput7.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput7.TabIndex = 56
        Me.tbOutput7.Visible = False
        '
        'lblOutput7
        '
        Me.lblOutput7.AutoSize = True
        Me.lblOutput7.Location = New System.Drawing.Point(6, 204)
        Me.lblOutput7.Name = "lblOutput7"
        Me.lblOutput7.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput7.TabIndex = 57
        Me.lblOutput7.Text = "Output:"
        Me.lblOutput7.Visible = False
        '
        'tbOutput8
        '
        Me.tbOutput8.Enabled = False
        Me.tbOutput8.Location = New System.Drawing.Point(179, 227)
        Me.tbOutput8.Name = "tbOutput8"
        Me.tbOutput8.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput8.TabIndex = 58
        Me.tbOutput8.Visible = False
        '
        'lblOutput8
        '
        Me.lblOutput8.AutoSize = True
        Me.lblOutput8.Location = New System.Drawing.Point(6, 230)
        Me.lblOutput8.Name = "lblOutput8"
        Me.lblOutput8.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput8.TabIndex = 59
        Me.lblOutput8.Text = "Output:"
        Me.lblOutput8.Visible = False
        '
        'tbOutput9
        '
        Me.tbOutput9.Enabled = False
        Me.tbOutput9.Location = New System.Drawing.Point(179, 253)
        Me.tbOutput9.Name = "tbOutput9"
        Me.tbOutput9.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput9.TabIndex = 60
        Me.tbOutput9.Visible = False
        '
        'lblOutput9
        '
        Me.lblOutput9.AutoSize = True
        Me.lblOutput9.Location = New System.Drawing.Point(6, 256)
        Me.lblOutput9.Name = "lblOutput9"
        Me.lblOutput9.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput9.TabIndex = 61
        Me.lblOutput9.Text = "Output:"
        Me.lblOutput9.Visible = False
        '
        'tbOutput10
        '
        Me.tbOutput10.Enabled = False
        Me.tbOutput10.Location = New System.Drawing.Point(179, 279)
        Me.tbOutput10.Name = "tbOutput10"
        Me.tbOutput10.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput10.TabIndex = 62
        Me.tbOutput10.Visible = False
        '
        'lblOutput10
        '
        Me.lblOutput10.AutoSize = True
        Me.lblOutput10.Location = New System.Drawing.Point(6, 282)
        Me.lblOutput10.Name = "lblOutput10"
        Me.lblOutput10.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput10.TabIndex = 63
        Me.lblOutput10.Text = "Output:"
        Me.lblOutput10.Visible = False
        '
        'tbOutput11
        '
        Me.tbOutput11.Enabled = False
        Me.tbOutput11.Location = New System.Drawing.Point(179, 305)
        Me.tbOutput11.Name = "tbOutput11"
        Me.tbOutput11.Size = New System.Drawing.Size(205, 20)
        Me.tbOutput11.TabIndex = 64
        Me.tbOutput11.Visible = False
        '
        'lblOutput11
        '
        Me.lblOutput11.AutoSize = True
        Me.lblOutput11.Location = New System.Drawing.Point(6, 308)
        Me.lblOutput11.Name = "lblOutput11"
        Me.lblOutput11.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput11.TabIndex = 65
        Me.lblOutput11.Text = "Output:"
        Me.lblOutput11.Visible = False
        '
        'gbOutput
        '
        Me.gbOutput.Controls.Add(Me.tbOutput0)
        Me.gbOutput.Controls.Add(Me.lblOutput5)
        Me.gbOutput.Controls.Add(Me.lblOutput11)
        Me.gbOutput.Controls.Add(Me.tbOutput5)
        Me.gbOutput.Controls.Add(Me.tbOutput6)
        Me.gbOutput.Controls.Add(Me.lblOutput4)
        Me.gbOutput.Controls.Add(Me.tbOutput11)
        Me.gbOutput.Controls.Add(Me.tbOutput4)
        Me.gbOutput.Controls.Add(Me.lblOutput6)
        Me.gbOutput.Controls.Add(Me.lblOutput3)
        Me.gbOutput.Controls.Add(Me.lblOutput10)
        Me.gbOutput.Controls.Add(Me.tbOutput3)
        Me.gbOutput.Controls.Add(Me.tbOutput7)
        Me.gbOutput.Controls.Add(Me.lblOutput2)
        Me.gbOutput.Controls.Add(Me.tbOutput10)
        Me.gbOutput.Controls.Add(Me.tbOutput2)
        Me.gbOutput.Controls.Add(Me.lblOutput7)
        Me.gbOutput.Controls.Add(Me.lblOutput1)
        Me.gbOutput.Controls.Add(Me.lblOutput9)
        Me.gbOutput.Controls.Add(Me.tbOutput1)
        Me.gbOutput.Controls.Add(Me.tbOutput8)
        Me.gbOutput.Controls.Add(Me.lblOutput0)
        Me.gbOutput.Controls.Add(Me.tbOutput9)
        Me.gbOutput.Controls.Add(Me.lblOutput8)
        Me.gbOutput.Location = New System.Drawing.Point(357, 106)
        Me.gbOutput.Name = "gbOutput"
        Me.gbOutput.Size = New System.Drawing.Size(400, 342)
        Me.gbOutput.TabIndex = 67
        Me.gbOutput.TabStop = False
        Me.gbOutput.Text = "Output"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSendCommand)
        Me.GroupBox1.Controls.Add(Me.tbCMD)
        Me.GroupBox1.Controls.Add(Me.tbRSP)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(360, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(396, 98)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Direct Commands"
        '
        'FrmCommandTester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 454)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbOutput)
        Me.Controls.Add(Me.gbParameters)
        Me.Controls.Add(Me.btnPorts)
        Me.Controls.Add(Me.cbPorts)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.cbCommands)
        Me.Controls.Add(Me.cbAddresses)
        Me.Controls.Add(Me.btnGetAddresses)
        Me.Name = "FrmCommandTester"
        Me.Text = "Command Testing Form"
        Me.gbParameters.ResumeLayout(False)
        Me.gbParameters.PerformLayout()
        Me.gbOutput.ResumeLayout(False)
        Me.gbOutput.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGetAddresses As Button
    Friend WithEvents btnSendCommand As Button
    Friend WithEvents tbCMD As TextBox
    Friend WithEvents tbRSP As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbAddresses As ComboBox
    Friend WithEvents cbCommands As ComboBox
    Friend WithEvents btnExecute As Button
    Friend WithEvents tbParams0 As TextBox
    Friend WithEvents lblParams0 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbPorts As ComboBox
    Friend WithEvents btnPorts As Button
    Friend WithEvents lblParams1 As Label
    Friend WithEvents tbParams1 As TextBox
    Friend WithEvents lblParams2 As Label
    Friend WithEvents tbParams2 As TextBox
    Friend WithEvents lblParams3 As Label
    Friend WithEvents tbParams3 As TextBox
    Friend WithEvents lblParams4 As Label
    Friend WithEvents tbParams4 As TextBox
    Friend WithEvents lblParams9 As Label
    Friend WithEvents tbParams9 As TextBox
    Friend WithEvents lblParams8 As Label
    Friend WithEvents tbParams8 As TextBox
    Friend WithEvents lblParams7 As Label
    Friend WithEvents tbParams7 As TextBox
    Friend WithEvents lblParams6 As Label
    Friend WithEvents tbParams6 As TextBox
    Friend WithEvents lblParams5 As Label
    Friend WithEvents tbParams5 As TextBox
    Friend WithEvents lblParams11 As Label
    Friend WithEvents tbParams11 As TextBox
    Friend WithEvents lblParams10 As Label
    Friend WithEvents tbParams10 As TextBox
    Friend WithEvents gbParameters As GroupBox
    Friend WithEvents tbOutput0 As TextBox
    Friend WithEvents lblOutput0 As Label
    Friend WithEvents tbOutput1 As TextBox
    Friend WithEvents lblOutput1 As Label
    Friend WithEvents tbOutput2 As TextBox
    Friend WithEvents lblOutput2 As Label
    Friend WithEvents tbOutput3 As TextBox
    Friend WithEvents lblOutput3 As Label
    Friend WithEvents tbOutput4 As TextBox
    Friend WithEvents lblOutput4 As Label
    Friend WithEvents tbOutput5 As TextBox
    Friend WithEvents lblOutput5 As Label
    Friend WithEvents tbOutput6 As TextBox
    Friend WithEvents lblOutput6 As Label
    Friend WithEvents tbOutput7 As TextBox
    Friend WithEvents lblOutput7 As Label
    Friend WithEvents tbOutput8 As TextBox
    Friend WithEvents lblOutput8 As Label
    Friend WithEvents tbOutput9 As TextBox
    Friend WithEvents lblOutput9 As Label
    Friend WithEvents tbOutput10 As TextBox
    Friend WithEvents lblOutput10 As Label
    Friend WithEvents tbOutput11 As TextBox
    Friend WithEvents lblOutput11 As Label
    Friend WithEvents gbOutput As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
