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
        Me.tbParams = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbPorts = New System.Windows.Forms.ComboBox()
        Me.btnPorts = New System.Windows.Forms.Button()
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
        Me.btnSendCommand.Location = New System.Drawing.Point(399, 6)
        Me.btnSendCommand.Name = "btnSendCommand"
        Me.btnSendCommand.Size = New System.Drawing.Size(262, 26)
        Me.btnSendCommand.TabIndex = 6
        Me.btnSendCommand.Text = "Send Command"
        Me.btnSendCommand.UseVisualStyleBackColor = True
        '
        'tbCMD
        '
        Me.tbCMD.Location = New System.Drawing.Point(399, 37)
        Me.tbCMD.Name = "tbCMD"
        Me.tbCMD.Size = New System.Drawing.Size(262, 20)
        Me.tbCMD.TabIndex = 7
        '
        'tbRSP
        '
        Me.tbRSP.Location = New System.Drawing.Point(399, 64)
        Me.tbRSP.Name = "tbRSP"
        Me.tbRSP.ReadOnly = True
        Me.tbRSP.Size = New System.Drawing.Size(262, 20)
        Me.tbRSP.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(336, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Command:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(335, 67)
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
        Me.cbCommands.Location = New System.Drawing.Point(154, 64)
        Me.cbCommands.Name = "cbCommands"
        Me.cbCommands.Size = New System.Drawing.Size(176, 21)
        Me.cbCommands.TabIndex = 13
        '
        'btnExecute
        '
        Me.btnExecute.Enabled = False
        Me.btnExecute.Location = New System.Drawing.Point(10, 63)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(142, 21)
        Me.btnExecute.TabIndex = 14
        Me.btnExecute.Text = "Execute Command"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'tbParams
        '
        Me.tbParams.Location = New System.Drawing.Point(79, 89)
        Me.tbParams.Name = "tbParams"
        Me.tbParams.Size = New System.Drawing.Size(254, 20)
        Me.tbParams.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Parameters:"
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
        'FrmCommandTester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 293)
        Me.Controls.Add(Me.btnPorts)
        Me.Controls.Add(Me.cbPorts)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbParams)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.cbCommands)
        Me.Controls.Add(Me.cbAddresses)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbRSP)
        Me.Controls.Add(Me.tbCMD)
        Me.Controls.Add(Me.btnSendCommand)
        Me.Controls.Add(Me.btnGetAddresses)
        Me.Name = "FrmCommandTester"
        Me.Text = "Command Testing Form"
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
    Friend WithEvents tbParams As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbPorts As ComboBox
    Friend WithEvents btnPorts As Button
End Class
