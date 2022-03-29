<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 行動電話月租費計算
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.output1 = New System.Windows.Forms.TextBox()
        Me.input1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'output1
        '
        Me.output1.Font = New System.Drawing.Font("新細明體", 20.0!)
        Me.output1.Location = New System.Drawing.Point(237, 52)
        Me.output1.Name = "output1"
        Me.output1.Size = New System.Drawing.Size(139, 39)
        Me.output1.TabIndex = 3
        '
        'input1
        '
        Me.input1.Font = New System.Drawing.Font("新細明體", 20.0!)
        Me.input1.Location = New System.Drawing.Point(27, 52)
        Me.input1.Name = "input1"
        Me.input1.Size = New System.Drawing.Size(210, 39)
        Me.input1.TabIndex = 2
        Me.input1.Text = "1 70"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(27, 107)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 38)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "計算"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(134, 107)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 38)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "清空"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 20.0!)
        Me.Label1.Location = New System.Drawing.Point(26, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 27)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "輸入"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 20.0!)
        Me.Label2.Location = New System.Drawing.Point(232, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 27)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "輸出"
        '
        '行動電話月租費計算
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 174)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.output1)
        Me.Controls.Add(Me.input1)
        Me.Name = "行動電話月租費計算"
        Me.Text = "行動電話月租費計算"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents output1 As TextBox
    Friend WithEvents input1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
