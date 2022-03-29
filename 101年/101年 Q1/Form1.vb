Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim num As String = NumericUpDown1.Value.ToString.PadLeft(2, "0") & NumericUpDown2.Value.ToString.PadLeft(2, "0")
        Dim b As New Bitmap(300, 300)
        Dim g As Graphics = Graphics.FromImage(b)
        Dim pen As New Pen(Color.Red)

        For i = 1 To num.Count
            If i > 2 Then pen.Color = Color.Blue
            Dim p = point(i)
            If Mid(num, i, 1) = 0 Then
                pen.DashStyle = Drawing2D.DashStyle.Dash
                g.DrawLine(pen, p, getpoint(p, If(i <= 2, 45, 135), 500))
            Else
                pen.DashStyle = Drawing2D.DashStyle.Solid
                For j = 1 To Val(Mid(num, i, 1))
                    g.DrawLine(pen, p, getpoint(p, If(i <= 2, 45, 135), 500))
                    p.Offset(0, 10)
                Next
            End If
        Next

        PictureBox1.Image = b
    End Sub
    Function getpoint(p As Point, angle%, length%) As Point
        Return New Point(p.X + Math.Cos(angle * Math.PI / 180) * length, p.Y - Math.Sin(angle * Math.PI / 180) * length)
    End Function

    Function point(num%) As Point
        Select Case num
            Case 1
                Return New Point(0, 175)
            Case 2
                Return New Point(125, 300)
            Case 3
                Return New Point(175, 300)
            Case 4
                Return New Point(300, 175)
            Case Else
                End
        End Select
    End Function
End Class
