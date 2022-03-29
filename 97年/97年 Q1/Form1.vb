Public Class Form1
    Dim sf As New StringFormat
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sf.Alignment = StringAlignment.Center
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.TranslateTransform(0, 230)
        g.Clear(Form1.DefaultBackColor)
        Dim a As Integer = TextBox1.Text, b As Integer = TextBox2.Text
        draw_x(a, b)
        Dim n As Decimal = 400 / (b - a)
        For i As Decimal = a To b Step 0.01
            g.FillEllipse(Brushes.Red, 50 + n * (i - a), -sinc(i) * 210, 2, 2)
        Next
    End Sub
    Function sinc(x)
        If x = 0 Then Return 1
        Return Math.Sin(x) / x
    End Function
    Sub draw_x(a%, b%)
        Dim g As Graphics = PictureBox1.CreateGraphics()
        g.TranslateTransform(0, 230)
        g.DrawString("X", Font, Brushes.Black, 490, -5, sf)
        Dim n As Single = 400 / (b - a)
        g.DrawLine(Pens.Black, 20, 0, 480, 0)
        For i As Decimal = a To b
            If i = 0 Then draw_y(50 + (i - a) * n) : Continue For
            If i Mod 5 = 0 Then
                g.DrawLine(Pens.Black, 50 + (i - a) * n, 0, 50 + (i - a) * n, -5)
                g.DrawString(i, Font, Brushes.Black, 50 + (i - a) * n, 2, sf)
            Else
                g.DrawLine(Pens.Black, 50 + (i - a) * n, 0, 50 + (i - a) * n, -2)
            End If
        Next
    End Sub

    Sub draw_y(x As Decimal)
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.TranslateTransform(x, 0)
        g.DrawString("sinc(x)", Font, Brushes.Black, 0, 3, sf)
        g.DrawLine(Pens.Black, 0, 15, 0, 285)
        Dim n As Single = 260 / 1.2
        For i As Decimal = 1 To -0.2 Step -0.05
            If i = 0 Then Continue For
            Dim a As New StringFormat
            a.Alignment = StringAlignment.Far
            If i * 10 Mod 2 = 0 Then g.DrawString(Math.Round(i, 1), Font, Brushes.Black, -10, 20 + n * (1 - i) - 5, sf)
            g.DrawLine(Pens.Black, 0, 20 + n * (1 - i), 2, 20 + n * (1 - i))
        Next
    End Sub
End Class
