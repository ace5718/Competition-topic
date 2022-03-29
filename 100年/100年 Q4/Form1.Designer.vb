<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.檔案FillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.開啟彩色影像檔案OpenColorimageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.結束離開ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.功能要求ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.彩色影像轉灰階影像ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.劃出灰階影像直方圖ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.求最小灰階和最大灰階ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.求出現最大之灰階和此機率ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.檔案FillToolStripMenuItem, Me.功能要求ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1222, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "檔案(Fill)"
        '
        '檔案FillToolStripMenuItem
        '
        Me.檔案FillToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.開啟彩色影像檔案OpenColorimageToolStripMenuItem, Me.結束離開ExitToolStripMenuItem})
        Me.檔案FillToolStripMenuItem.Name = "檔案FillToolStripMenuItem"
        Me.檔案FillToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.檔案FillToolStripMenuItem.Text = "檔案(Fill)"
        '
        '開啟彩色影像檔案OpenColorimageToolStripMenuItem
        '
        Me.開啟彩色影像檔案OpenColorimageToolStripMenuItem.Name = "開啟彩色影像檔案OpenColorimageToolStripMenuItem"
        Me.開啟彩色影像檔案OpenColorimageToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.開啟彩色影像檔案OpenColorimageToolStripMenuItem.Text = "開啟彩色影像檔案(OpenColorimage)"
        '
        '結束離開ExitToolStripMenuItem
        '
        Me.結束離開ExitToolStripMenuItem.Name = "結束離開ExitToolStripMenuItem"
        Me.結束離開ExitToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.結束離開ExitToolStripMenuItem.Text = "結束離開(Exit)"
        '
        '功能要求ToolStripMenuItem
        '
        Me.功能要求ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.彩色影像轉灰階影像ToolStripMenuItem, Me.劃出灰階影像直方圖ToolStripMenuItem, Me.求最小灰階和最大灰階ToolStripMenuItem, Me.求出現最大之灰階和此機率ToolStripMenuItem})
        Me.功能要求ToolStripMenuItem.Name = "功能要求ToolStripMenuItem"
        Me.功能要求ToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.功能要求ToolStripMenuItem.Text = "功能要求"
        '
        '彩色影像轉灰階影像ToolStripMenuItem
        '
        Me.彩色影像轉灰階影像ToolStripMenuItem.Name = "彩色影像轉灰階影像ToolStripMenuItem"
        Me.彩色影像轉灰階影像ToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.彩色影像轉灰階影像ToolStripMenuItem.Text = "彩色影像轉灰階影像"
        '
        '劃出灰階影像直方圖ToolStripMenuItem
        '
        Me.劃出灰階影像直方圖ToolStripMenuItem.Name = "劃出灰階影像直方圖ToolStripMenuItem"
        Me.劃出灰階影像直方圖ToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.劃出灰階影像直方圖ToolStripMenuItem.Text = "劃出灰階影像直方圖"
        '
        '求最小灰階和最大灰階ToolStripMenuItem
        '
        Me.求最小灰階和最大灰階ToolStripMenuItem.Name = "求最小灰階和最大灰階ToolStripMenuItem"
        Me.求最小灰階和最大灰階ToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.求最小灰階和最大灰階ToolStripMenuItem.Text = "求最小灰階和最大灰階"
        '
        '求出現最大之灰階和此機率ToolStripMenuItem
        '
        Me.求出現最大之灰階和此機率ToolStripMenuItem.Name = "求出現最大之灰階和此機率ToolStripMenuItem"
        Me.求出現最大之灰階和此機率ToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.求出現最大之灰階和此機率ToolStripMenuItem.Text = "求出現最多之灰階和此機率"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(358, 417)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "彩色影像(Color Image)"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(6, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(346, 389)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(380, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(349, 417)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "灰階影像(Gray Level Image)"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(0, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(346, 389)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Chart1)
        Me.GroupBox3.Location = New System.Drawing.Point(735, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(469, 417)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "灰階影像(Gray Level Image)"
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(7, 22)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(448, 389)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 459)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "最小灰階(亮度)為："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(270, 459)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 19)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "最大灰階(亮度)為："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(541, 459)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(243, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "出現最多之灰階(亮度)為："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(863, 459)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(243, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "最多灰階(亮度)之機率為："
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(48, 490)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(123, 23)
        Me.TextBox1.TabIndex = 8
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(300, 490)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(123, 23)
        Me.TextBox2.TabIndex = 9
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(601, 490)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(123, 23)
        Me.TextBox3.TabIndex = 10
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(923, 490)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(123, 23)
        Me.TextBox4.TabIndex = 11
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1222, 534)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 檔案FillToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 開啟彩色影像檔案OpenColorimageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 功能要求ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 結束離開ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 彩色影像轉灰階影像ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 劃出灰階影像直方圖ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 求最小灰階和最大灰階ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 求出現最大之灰階和此機率ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
End Class
