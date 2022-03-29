Public Class Form1
    Dim num As Integer
    Dim pf As New List(Of PointF)
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        num = NumericUpDown1.Value
        GroupBox1.Visible = True
        GroupBox1.Text = String.Format("請輸入{0}個點座標：x和y值", num)
        For i = 1 To 8
            GroupBox1.Controls("Label" & i).Visible = If(i <= num, True, False)
            GroupBox1.Controls("Label" & i).Text = String.Format("第x{0}點座標", i)
            GroupBox1.Controls("TextBox" & i * 2).Visible = If(i <= num, True, False)
            GroupBox1.Controls("TextBox" & i * 2 - 1).Visible = If(i <= num, True, False)
        Next
    End Sub

    Private Sub Button1_Click(sender As Button, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click
        If cheek() Then MsgBox("集合C中數入點數錯誤，先用預設的8個點，來畫出點的分佈。請再輸入一次") : Exit Sub
        Controls("answers" & sender.Name.Replace("Button", "")).Text = answers(New PointF(TextBox17.Text, TextBox18.Text), sender.Name.Replace("Button", ""))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If cheek() Then MsgBox("集合C中數入點數錯誤，先用預設的8個點，來畫出點的分佈。請再輸入一次") : Exit Sub
        draw_pic()
    End Sub

    Function answers(test_point As PointF, sel As Integer)
        Dim ar As New List(Of Decimal)
        For Each i In pf
            ar.Add(c(test_point, i))
        Next
        Select Case sel
            Case 1 : Return ar.Max
            Case 2 : Return ar.Min
            Case 3 : Return ar.Sum / 8
        End Select
    End Function

    Function c(p1 As PointF, p2 As PointF)
        Return ((p1.X - p2.X) ^ 2 + (p1.Y - p2.Y) ^ 2) ^ 0.5
    End Function

    Sub draw_pic()
        Dim bm As New Bitmap(265, 265)
        Dim g As Graphics = Graphics.FromImage(bm)
        Dim n As Integer = 1

        For i = 0 To 12
            g.DrawLine(If(i = 0 Or i = 12, Pens.Black, Pens.Blue), i * 20 + 10, 10, i * 20 + 10, 250)
            g.DrawLine(If(i = 0 Or i = 12, Pens.Black, Pens.Blue), 10, i * 20 + 10, 250, i * 20 + 10)
            If i <= 6 Then g.DrawString(i, Font, Brushes.Blue, 0, 250 - (i * 40) - 8) : g.DrawString(i, Font, Brushes.Blue, i * 40 + 4.5, 250)
        Next

        For Each i In pf
            Dim x As Single = i.X * 40 + 10 - 2.5, y As Single = 250 - (i.Y * 40) - 2.5
            g.FillEllipse(Brushes.Red, x, y, 5, 5)
            g.DrawString(String.Format("x{0}", n), Font, Brushes.Black, New PointF(x + 3, y - 15))
            n += 1
        Next
        PictureBox1.Image = bm
    End Sub

    Function cheek() As Boolean
        If TextBox17.Text = "" Or TextBox18.Text = "" Then Return True
        pf.Clear()
        For i = 1 To num
            If GroupBox1.Controls("TextBox" & i * 2).Text = "" Or GroupBox1.Controls("TextBox" & i * 2 - 1).Text = "" Then Return True
            pf.Add(New PointF(GroupBox1.Controls("TextBox" & i * 2 - 1).Text, GroupBox1.Controls("TextBox" & i * 2).Text))
        Next
        Return False
    End Function
End Class
