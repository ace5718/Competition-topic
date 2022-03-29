Public Class Form1
    Dim r As New List(Of Rectangle)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(DefaultBackColor) : r.Clear()
        Dim ran As New Random
        TextBox1.Text = ran.Next(20, 201)
        For i = 1 To Val(TextBox1.Text)
            r.Add(New Rectangle(ran.Next(10, 600), ran.Next(10, 450), ran.Next(10, 26), ran.Next(10, 26)))
        Next
        g.DrawRectangles(Pens.Black, r.ToArray)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim c As New List(Of Rectangle)
        Dim g As Graphics = PictureBox1.CreateGraphics
        Dim dt As DateTime = Now
        For i = 0 To r.Count - 2
            For j = i + 1 To r.Count - 1
                Dim temp As Rectangle = Rectangle.Intersect(r(i), r(j))
                If temp.Width > 0 Or temp.Height > 0 Then
                    g.FillEllipse(Brushes.Black, temp)
                    c.Add(r(i)) : c.Add(r(j))
                End If
            Next
        Next

        For i = c.Count - 1 To 0 Step -1
            If c.IndexOf(c(i)) <> i Then c.RemoveAt(i)
        Next
        Label2.Text = "Overlapping blocks：" & c.Count
        Dim t As TimeSpan = Now.Subtract(dt)
        Label3.Text = "Running time：" & t.TotalMilliseconds & "ms"
    End Sub
End Class
