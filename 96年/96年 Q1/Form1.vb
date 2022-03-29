Public Class Form1
    Dim g As Graphics
    Dim r As New Random
    Dim p(2) As Point
    Dim lt, rt, center As Point
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        g = PictureBox1.CreateGraphics
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i = 1 To 3 : Controls("TextBox" & i).Text = "" : Next
        g.Clear(PictureBox1.BackColor)
        p(0) = get_point() : p(1) = get_point() : p(2) = get_point()
        draw_point(p(0)) : draw_point(p(1)) : draw_point(p(2))
        Dim tmp = (From i In p Order By i.Y, i.X).ToArray()
        lt = tmp(0) : center = tmp(1) : rt = tmp(2)
        draw_line(New Point(lt.X, center.Y), lt)
        draw_line(New Point(lt.X, center.Y), center)
        draw_line(New Point(rt.X, center.Y), rt)
        draw_line(New Point(rt.X, center.Y), center)
        TextBox1.Text = get_len(New Point(lt.X, center.Y), lt) + get_len(New Point(lt.X, center.Y), center) +
            get_len(New Point(rt.X, center.Y), rt) + get_len(New Point(rt.X, center.Y), center)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim le As Integer
        g.Clear(PictureBox1.BackColor)
        draw_point(p(0)) : draw_point(p(1)) : draw_point(p(2))
        Dim a = ON_45(lt), b = ON_45(rt)
        draw_line(lt, a) : draw_line(rt, b)
        Dim tmp = {a.x, b.x, center.X}
        le += get_len(a, lt) + get_len(b, rt) + tmp.Max - tmp.Min
        g.DrawLine(Pens.Black, tmp.Min, center.Y, tmp.Max, center.Y)
        TextBox2.Text = le
        TextBox3.Text = Format(100 - (le / Val(TextBox1.Text)) * 100, "0.0") & "%"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Function ON_45(a As Point)
        Dim range = Math.Abs(center.Y - a.Y)
        Dim ar As New ArrayList
        For i = -range To range Step range
            Dim tmp = New Point(a.X + i, center.Y)
            ar.Add({get_len(a, tmp) + get_len(center, tmp), tmp})
        Next
        Return (From i In ar.ToArray Order By i(0) Select i(1)).ToArray()(0)
    End Function

    Function get_point()
        Return New Point(r.Next(0, PictureBox1.Width), r.Next(0, PictureBox1.Height))
    End Function
    Sub draw_point(p As Point)
        g.FillEllipse(Brushes.Black, p.X - 3, p.Y - 3, 7, 7)
    End Sub
    Sub draw_line(a As Point, b As Point)
        g.DrawLine(Pens.Black, a, b)
    End Sub
    Function get_len(a As Point, b As Point)
        Return ((a.X - b.X) ^ 2 + (a.Y - b.Y) ^ 2) ^ 0.5
    End Function
End Class
