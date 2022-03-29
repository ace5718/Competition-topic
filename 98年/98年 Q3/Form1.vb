Public Class Form1
    Dim data As Byte()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        data = My.Computer.FileSystem.ReadAllBytes(TextBox1.Text)
        If riff() And wave() And pcm() And noc() And bps() And da() Then Else MsgBox("輸入的檔案名稱不是RIFF WAVEfat、PCM格式、八位元及單聲道",, "輸入的檔案名稱：" & TextBox1.Text) : Exit Sub
        PictureBox1.Size = New Point(nos(), 255)
        PictureBox1.Image = draw()
        HScrollBar1.Maximum = nos() - Size.Width
        HScrollBar1.Value = 0
        TextBox3.Text = Format(nos() / sr(), "0.00000")
        TextBox2.Text = 0.00000
    End Sub

    Function riff() As Boolean
        Dim ar As New ArrayList
        For i = &H0 To &H3
            ar.Add(System.Text.Encoding.UTF8.GetString(data, i, 1))
        Next
        Return Join(ar.ToArray, "") = "RIFF"
    End Function

    Function wave() As Boolean
        Dim ar As New ArrayList
        For i = &H8 To &HE
            ar.Add(System.Text.Encoding.UTF8.GetString(data, i, 1))
        Next
        Return Join(ar.ToArray, "") = "WAVEfmt"
    End Function

    Function pcm() As Boolean
        Return data(&H14) = 1 And data(&H15) = 0
    End Function

    Function noc() As Boolean
        Return data(&H16) = 1 And data(&H17) = 0
    End Function

    Function bps() As Boolean
        Return data(&H22) = 8 And data(&H23) = 0
    End Function

    Function da() As Boolean
        Dim ar As New ArrayList
        For i = &H24 To &H27
            ar.Add(System.Text.Encoding.UTF8.GetString(data, i, 1))
        Next
        Return Join(ar.ToArray, "") = "data"
    End Function
    Function sr()
        Dim ar As New ArrayList
        For i = &H18 To &H1B
            ar.Add(Convert.ToString(data(i), 16))
        Next
        ar.Reverse()
        Return Convert.ToInt16(Join(ar.ToArray, ""), 16)
    End Function

    Function nos()
        Dim ar As New ArrayList
        For i = &H28 To &H2B
            ar.Add(Convert.ToString(data(i), 16))
        Next
        ar.Reverse()
        Return Convert.ToInt16(Join(ar.ToArray, ""), 16)
    End Function

    Function draw()
        Dim b As Bitmap = New Bitmap(nos, 255)
        Dim g As Graphics = Graphics.FromImage(b)
        g.TranslateTransform(0, PictureBox1.Height / 2)
        g.DrawLine(Pens.Green, 0, 0, nos, 0)
        For i = &H2C To &H2C + nos() - 1
            Dim x As Single = i - &H2C
            Dim y As Single = data(i) - &H80
            g.DrawLine(Pens.DarkGreen, x, y, x, -y)
        Next
        Return b
    End Function

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Dim y As Integer = PictureBox1.Location.Y
        PictureBox1.Location = New Point(-HScrollBar1.Value, y)
        TextBox2.Text = Format(nos() / sr() ^ 2 * (HScrollBar1.Value + Size.Width), "0.00000")
    End Sub
End Class
