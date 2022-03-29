Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Timer1.Enabled = True Then
            Button1.Text = "Start" : Timer1.Enabled = False
        Else
            Button1.Text = "Stop" : Timer1.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.TranslateTransform(PictureBox1.Width / 2, PictureBox1.Height / 2)
        Dim num As Integer = ComboBox1.SelectedIndex
        If num = 0 Then draw() : Exit Sub
        Dim chk As New HashSet(Of Integer)
        Dim r As New Random
        Dim sel = {-1, 1}
        For i = 1 To num
            Dim line As New List(Of Point)
            Dim ck = chk.Count
            line.Add(New Point(0, 0))
            Dim a% : Do Until chk.Count > ck : a = r.Next(0, 12) : chk.Add(a) : Loop
            Dim b% = sel(r.Next(0, 2)), c% = sel(r.Next(0, 2))
            Dim at = get_angle(a * 30, 100), bt = get_angle(a * 30 + 15 * b, 65), ct = get_angle(a * 30 + 15 * b + c * 10, 45)
            line.Add(at) : line.Add(at + bt) : line.Add(at + bt + ct)
            g.DrawLines(Pens.Red, line.ToArray)
        Next
        System.Threading.Thread.Sleep(100)
        Refresh()
    End Sub

    Sub draw()
        Dim a, b, c As Point
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.TranslateTransform(PictureBox1.Width / 2, PictureBox1.Height / 2)
        g.DrawEllipse(Pens.Black, -100, -100, 200, 200)
        g.DrawEllipse(Pens.Black, -165, -165, 330, 330)
        g.DrawEllipse(Pens.Black, -210, -210, 420, 420)
        For i = 0 To 11
            a = get_angle(i * 30, 100)
            g.DrawLine(Pens.LightGreen, New Point(0, 0), a)
            For j = -1 To 1 Step 2
                b = get_angle(i * 30 + 15 * j, 65)
                g.DrawLine(Pens.LightGreen, a, a + b)
                For k = -1 To 1 Step 2
                    c = get_angle(i * 30 + j * 15 + k * 7.5, 45)
                    g.DrawLine(Pens.LightGreen, a + b, a + b + c)
                Next
            Next
        Next
        System.Threading.Thread.Sleep(100)
        Refresh()
    End Sub

    Function get_angle(n As Integer, l As Integer) As Point
        Return New Point(l * Math.Cos(n * Math.PI / 180), l * Math.Sin(n * Math.PI / 180))
    End Function

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Dim g As Graphics = e.Graphics
        g.TranslateTransform(PictureBox1.Width / 2, PictureBox1.Height / 2)
        g.DrawEllipse(Pens.Black, -100, -100, 200, 200)
        g.DrawEllipse(Pens.Black, -165, -165, 330, 330)
        g.DrawEllipse(Pens.Black, -210, -210, 420, 420)
        Dim a, b, c As Point
        For i = 0 To 11
            a = get_angle(i * 30, 100)
            g.DrawLine(Pens.LightGreen, New Point(0, 0), a)
            For j = -1 To 1 Step 2
                b = get_angle(i * 30 + 15 * j, 65)
                g.DrawLine(Pens.LightGreen, a, a + b)
                For k = -1 To 1 Step 2
                    c = get_angle(i * 30 + j * 15 + k * 10, 45)
                    g.DrawLine(Pens.LightGreen, a + b, a + b + c)
                Next
            Next
        Next
    End Sub
End Class
