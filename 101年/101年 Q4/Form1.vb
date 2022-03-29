Public Class Form1
    Dim g As Graphics
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim p As New List(Of Point)
        For i = 1 To 4
            Dim s = Controls("TextBox" & i).Text.Split(",")
            p.Add(New Point(s(0), s(1)))
        Next
        Dim str = NO(p).Split("!")
        ans1.Text = str(0)
        ans2.Text = str(1)
        draw(p, ans2.Text)
    End Sub

    Sub draw(p As List(Of Point), s As String)
        g = PictureBox1.CreateGraphics
        map(g)
        For i = 0 To 2 Step 2
            Dim x1, y1, x2, y2 As Single
            x1 = 250 + p(i).X * 6.25
            y1 = 200 - p(i).Y * 6
            x2 = 250 + p(i + 1).X * 6.25
            y2 = 200 - p(i + 1).Y * 6
            g.DrawLine(Pens.Black, x1, y1, x2, y2)
        Next
    End Sub

    Sub map(g As Graphics)
        g.Clear(Form.DefaultBackColor)
        g.DrawLine(Pens.Black, 250, 0, 250, 400)
        g.DrawLine(Pens.Black, 0, 200, 500, 200)
        For i = 0 To 6
            If i = 0 Or i = 6 Then g.DrawString(If(i = 0, "(0,30)", "(0,-30)"), Font, Brushes.Black, CSng(253), CSng(i * 65.2))
            If i = 3 Then g.DrawString("(0,0)", Font, Brushes.Black, CSng(252), CSng(i * 67))
            g.FillEllipse(Brushes.Black, CSng(246), CSng(i * 65.2), 8, 8)
        Next
        For i = 1 To 12 Step 2
            g.DrawLine(Pens.Black, 245, CSng(((i) * 65.75) / 2), 255, CSng(((i) * 65.75) / 2))
        Next
        For i = 0 To 8
            If i = 0 Or i = 8 Then g.DrawString(If(i = 0, "(0,-40)", "(0,40)"), Font, Brushes.Black, CSng(i * 61.45), 202)
            g.FillEllipse(Brushes.Black, CSng(i * 61.45), 196, 8, 8)
        Next
        For i = 1 To 16 Step 2
            g.DrawLine(Pens.Black, CSng((i * 62) / 2), 195, CSng((i * 62) / 2), 205)
        Next
    End Sub
    Function NO(p As List(Of Point)) As String
        Dim left, right, up, down As Decimal
        left = If(p(0).X > p(1).X, p(1).X, p(0).X)
        right = If(p(0).X < p(1).X, p(1).X, p(0).X)
        up = If(p(0).Y > p(1).Y, p(0).Y, p(1).Y)
        down = If(p(0).Y < p(1).Y, p(0).Y, p(1).Y)

        If p(0).X = p(2).X Or p(0).X = p(3).X Then
            If p(2).Y > up And p(2).Y < down Or p(3).Y > up And p(3).Y < down Then
                Return "沒相交" & "! "
            End If
        End If
        '解一
        Dim a, b, c, d, e, f, N, O As Decimal
        a = p(1).Y - p(0).Y '左-右
        b = p(0).X - p(1).X '右-左
        c = a * p(0).X + b * p(0).Y

        d = p(3).Y - p(2).Y '左-右
        e = p(2).X - p(3).X '右-左
        f = d * p(2).X + e * p(2).Y

        N = (c * e - b * f) / (a * e - b * d)
        O = (c * d - a * f) / (b * d - a * e)

        If (N < left Or N > right) And (O > up Or O < down) Then Return "沒相交" & "! " Else Return "有相交" & "!" & Format(N, "0.00") & "," & Format(O, "0.00")

        '解2
        'Dim m1 = (p(0).Y - p(1).Y) / (p(0).X - p(1).X), m2 = (p(2).Y - p(3).Y) / (p(2).X - p(3).X)
        'Dim x = (m1 * p(0).X - p(0).Y - m2 * p(2).X + p(2).Y) / (m1 - m2), y = m1 * (x - p(0).X) + p(0).Y

        'If (x < left Or x > right) And (y > up Or y < down) Then  Return "沒相交" & "! " Else Return "有相交" & "!" & Format(x, "0.00") & "," & Format(y, "0.00")
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        g = PictureBox1.CreateGraphics
        g.Clear(Form.DefaultBackColor)
        ans1.Text = ""
        ans2.Text = ""
    End Sub
End Class
