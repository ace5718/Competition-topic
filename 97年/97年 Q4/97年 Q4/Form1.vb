Public Class Form1
    Dim num As Integer
    Dim pf As New List(Of PointF)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        num = NumericUpDown1.Value
        For i = 1 To 10
            GroupBox1.Controls("TextBox" & i * 2).Visible = If(i <= num, True, False)
            GroupBox1.Controls("TextBox" & i * 2 - 1).Visible = If(i <= num, True, False)
            GroupBox1.Controls("Label" & i + 2).Visible = If(i <= num, True, False)
        Next
        Button2.Enabled = True
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If get_pf() Then MsgBox("輸入錯誤") : Exit Sub
        ans1.Text = Format(m(), "0.000")
        ans2.Text = Format(b(m()), "0.000")
        ans3.Text = num
        draw()
    End Sub
    Sub draw()
        Dim bm As New Bitmap(281, 281)
        Dim g As Graphics = Graphics.FromImage(bm)
        Dim pe As Pen = New Pen(Color.Black) : pe.DashStyle = Drawing2D.DashStyle.Dash
        For i = 0 To num
            g.DrawLine(If(i = 0 Or i = num, Pens.Black, pe), New PointF(i * (280 / num), 0), New PointF(i * (280 / num), 280))
            g.DrawLine(If(i = 0 Or i = num, Pens.Black, pe), New PointF(0, i * (280 / num)), New PointF(280, i * (280 / num)))
        Next
        g.DrawLine(Pens.Red, 0, 280, 280, 0)
        For Each i In pf
            Dim x As Decimal = i.X * (280 / num) - 43, y As Decimal = 280 - i.Y * (280 / num) + 38
            g.DrawEllipse(Pens.Blue, x, y, 5, 5)
        Next
        PictureBox1.Image = bm
    End Sub
    Function m()
        Dim x, y, a, b As New List(Of Decimal)
        For Each i In pf
            a.Add(i.X * i.Y) : b.Add(i.X ^ 2)
            x.Add(i.X) : y.Add(i.Y)
        Next
        Return (a.Sum - x.Sum * (y.Sum / y.Count)) / (b.Sum - x.Sum * (x.Sum / x.Count))
    End Function
    Function b(m As Decimal) As Decimal
        Dim x, y As New List(Of Decimal)
        For Each i In pf
            x.Add(i.X) : y.Add(i.Y)
        Next
        Return (y.Sum / y.Count) - m * (x.Sum / x.Count)
    End Function
    Function get_pf() As Boolean
        pf.Clear()
        For i = 1 To num
            If GroupBox1.Controls("TextBox" & i * 2).Text = "" And GroupBox1.Controls("TextBox" & i * 2 - 1).Text = "" Then Return True
            pf.Add(New PointF(GroupBox1.Controls("TextBox" & i * 2).Text, GroupBox1.Controls("TextBox" & i * 2 - 1).Text))
        Next
        Return False
    End Function
End Class
