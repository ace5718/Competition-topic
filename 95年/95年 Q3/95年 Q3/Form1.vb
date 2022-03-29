Public Class Form1
    Dim g As Graphics
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        g = PictureBox1.CreateGraphics
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim p(360) As PointF
        g.Clear(Color.White)
        g.DrawLine(Pens.Black, 0, 150, 600, 150)
        If RadioButton1.Checked = True Then
            For i = 0 To 360
                Dim s As Single = Math.Sin(i * Math.PI / 180)
                p(i) = New PointF(i * 600 / 360, 150 + (149 * -s))
            Next
        ElseIf RadioButton2.Checked = True Then
            For i = 0 To 360
                Dim s As Single = Math.Cos(i * Math.PI / 180)
                p(i) = New PointF(i * 600 / 360, 150 + (149 * -s))
            Next
        End If
        g.DrawLines(Pens.Red, p)
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        g.Clear(Color.White)
        g.DrawLine(Pens.Black, 0, 150, 600, 150)
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
End Class
