Public Class Form1
    Dim pic As String() = "元氣牛肉湯(50 元).jpg,原燒冰淇淋(40 元).jpg,吟釀味噌湯(40 元).jpg,大蒜蛤蜊湯(45 元).jpg,奶油燻雞義大利麵(65 元).jpg,桂花紅豆湯(45 元).jpg,水果優格沙拉(45 元).jpg,牛蕃茄沙拉(40 元).jpg,生春捲沙拉(40 元).jpg,白玉紫米(40 元).jpg,白酒蛤蠣義大利麵(80 元).jpg,筊白筍青蔬沙拉(50 元).jpg,羅勒海鮮義大利麵(70 元).jpg,蕃茄海鮮湯(40 元).jpg,蕃茄雞肉義大利麵(75 元).jpg,黑糖奶酪(35 元).jpg".Split(",")
    Dim mon As String() = "50,40,40,45,65,45,45,40,40,40,80,50,70,40,75,35".Split(",")
    Dim str As String() = "元氣牛肉湯,原燒冰淇淋,吟釀味噌湯,大蒜蛤蜊湯,奶油燻雞義大利麵,桂花紅豆湯,水果優格沙拉,牛蕃茄沙拉,生春捲沙拉,白玉紫米,白酒蛤蠣義大利麵,筊白筍青蔬沙拉,羅勒海鮮義大利麵,蕃茄海鮮湯,蕃茄雞肉義大利麵,黑糖奶酪".Split(",")
    Sub eat(sender As Object, e As EventArgs) Handles 番茄雞肉義大利麵ToolStripMenuItem.Click, 羅勒海鮮義大利麵ToolStripMenuItem.Click, 奶油燻雞義大利麵ToolStripMenuItem.Click, 白酒蛤蠣麵ToolStripMenuItem.Click
        If RadioButton1.Checked = True Then
            PictureBox1.ImageLocation = pic(Array.IndexOf(str, sender.Text))
            Label1.Text = pic(Array.IndexOf(str, sender.text)).Split(".")(0)
        ElseIf RadioButton2.Checked = True Then
            PictureBox5.ImageLocation = pic(Array.IndexOf(str, sender.Text))
            Label5.Text = pic(Array.IndexOf(str, sender.text)).Split(".")(0)
        End If
        totol()
    End Sub
    Sub salad(sender As Object, e As EventArgs) Handles 水果優格沙拉ToolStripMenuItem.Click, 生春捲沙拉ToolStripMenuItem.Click, 茭白筍青蔬沙拉ToolStripMenuItem.Click, 牛番茄沙拉ToolStripMenuItem.Click
        If RadioButton1.Checked = True Then
            PictureBox2.ImageLocation = pic(Array.IndexOf(str, sender.Text))
            Label2.Text = pic(Array.IndexOf(str, sender.text)).Split(".")(0)
        ElseIf RadioButton2.Checked = True Then
            PictureBox6.ImageLocation = pic(Array.IndexOf(str, sender.Text))
            Label6.Text = pic(Array.IndexOf(str, sender.text)).Split(".")(0)
        End If
        totol()
    End Sub
    Sub soup(sender As Object, e As EventArgs) Handles 大蒜蛤蠣湯ToolStripMenuItem.Click, 番茄海鮮湯ToolStripMenuItem.Click, 吟釀味噌湯ToolStripMenuItem.Click, 元氣牛肉ToolStripMenuItem.Click
        If RadioButton1.Checked = True Then
            PictureBox3.ImageLocation = pic(Array.IndexOf(str, sender.Text))
            Label3.Text = pic(Array.IndexOf(str, sender.text)).Split(".")(0)
        ElseIf RadioButton2.Checked = True Then
            PictureBox7.ImageLocation = pic(Array.IndexOf(str, sender.Text))
            Label7.Text = pic(Array.IndexOf(str, sender.text)).Split(".")(0)
        End If
        totol()
    End Sub
    Sub dessert(sender As Object, e As EventArgs) Handles 原燒冰淇淋ToolStripMenuItem.Click, 桂圓紅豆湯ToolStripMenuItem.Click, 白玉紫米ToolStripMenuItem.Click, 黑糖奶酪ToolStripMenuItem.Click
        If RadioButton1.Checked = True Then
            PictureBox4.ImageLocation = pic(Array.IndexOf(str, sender.Text))
            Label4.Text = pic(Array.IndexOf(str, sender.text)).Split(".")(0)
        ElseIf RadioButton2.Checked = True Then
            PictureBox8.ImageLocation = pic(Array.IndexOf(str, sender.Text))
            Label8.Text = pic(Array.IndexOf(str, sender.text)).Split(".")(0)
        End If
        totol()
    End Sub
    Sub totol()
        Dim c = 0
        If RadioButton1.Checked = True Then
            Dim s As String
            Dim money As New List(Of Integer)
            For i = 1 To 4
                s = ""
                For Each j In GroupBox1.Controls("label" & i).Text
                    If IsNumeric(j) Then
                        s &= j
                    End If
                Next
                money.Add(Val(s))
            Next
            c = money.Sum
            totol1.Text = "總價：" & c & "元"
        ElseIf RadioButton2.Checked = True Then
            Dim s As String
            Dim money As New List(Of Integer)
            For i = 5 To 8
                s = ""
                For Each j In GroupBox3.Controls("label" & i).Text
                    If IsNumeric(j) Then
                        s &= j
                    End If
                Next
                money.Add(Val(s))
            Next
            c = money.Sum
            totol2.Text = "總價：" & c & "元"
        End If
    End Sub

End Class
