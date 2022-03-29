Public Class Form1
    Class node
        Public p As Point
        Public n As Integer
        Public Sub New(point As Point, num As Integer)
            p = point : n = num
        End Sub
    End Class
    Dim map(9, 9) As Point
    Dim ar, now, before As New List(Of Point)
    Dim obstacle As New HashSet(Of Point)
    Dim g As Graphics
    Dim r As New Random
    Dim t_point, s_point As Point
    Dim num As New Integer
    Dim get_map(9, 9) As node
    Dim s, t As Point
    Dim gp As Point
    Dim ans As New List(Of node)
    Dim ans_num As Integer = 1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        g = PictureBox1.CreateGraphics
        draw_map()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = False
        g.Clear(Color.White)
        draw_map()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = False
        t_point = New Point : s_point = New Point
        Dim n As Integer = r.Next(20, 26)
        g.Clear(Color.White)
        obstacle.Clear()
        draw_map()
        Do
            obstacle.Add(map(r.Next(1, 10), r.Next(1, 10)))
        Loop Until obstacle.Count > n

        For Each i In obstacle
            g.FillRectangle(Brushes.Black, i.X, i.Y, 33, 33)
            g.DrawRectangle(Pens.Gray, i.X, i.Y, 33, 33)
        Next
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer1.Enabled = False
        If obstacle.Count = 0 Or obstacle.Count > 0 AndAlso Array.IndexOf(obstacle.ToArray, t_point) = -1 And Array.IndexOf(obstacle.ToArray, s_point) Then
            g.FillRectangle(Brushes.White, t_point.X, t_point.Y, 33, 33)
            g.FillRectangle(Brushes.White, s_point.X, s_point.Y, 33, 33)
            g.DrawRectangle(Pens.Black, t_point.X, t_point.Y, 33, 33)
            g.DrawRectangle(Pens.Black, s_point.X, s_point.Y, 33, 33)
        End If
        Do
            t_point = map(r.Next(1, 10), r.Next(1, 10))
            s_point = map(r.Next(1, 10), r.Next(1, 10))
        Loop Until Array.IndexOf(obstacle.ToArray, t_point) = -1 AndAlso Array.IndexOf(obstacle.ToArray, s_point) = -1
        g.DrawString("T", Label1.Font, Brushes.Black, t_point)
        g.DrawString("S", Label1.Font, Brushes.Black, s_point)
        draw_map()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        draw_map()
        now.Clear() : before.Clear()
        ar_()
        aaa()
        num = 0
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        End
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If gp = s Then Timer2.Enabled = False
        If map(gp.Y, gp.X) <> s_point Then g.FillRectangle(Brushes.Gray, map(gp.Y, gp.X).X, map(gp.Y, gp.X).Y, 33, 33)
        gp = get_map_point(get_map(gp.Y, gp.X).p)
    End Sub

    Function cheek(dp As Point) As Boolean
        Return Array.IndexOf(ar.ToArray, dp) <> -1 AndAlso Array.IndexOf(obstacle.ToArray, dp) = -1
    End Function
    Function get_map_point(dp As Point)
        For y = 1 To 9
            For x = 1 To 9
                If map(y, x) = dp Then Return New Point(x, y)
            Next
        Next
    End Function
    Sub aaa()
        s = get_map_point(s_point)
        t = get_map_point(t_point)
        Dim tf As Boolean
        get_map(s.Y, s.X) = New node(Nothing, 0)
        Dim direction() As Point = {New Point(0, -33), New Point(0, 33), New Point(33, 0), New Point(-33, 0)}
        Dim q_point, q_xy As New Queue
        q_point.Enqueue(New Point(s_point.X, s_point.Y))
        q_xy.Enqueue(New Point(s.X, s.Y))
        While q_point.Count <> 0
            For Each i In q_point
                before.Add(i)
            Next
            Dim po As Point = q_point.Dequeue
            Dim po_xy As Point = q_xy.Dequeue
            For Each i In direction
                Dim dp As Point = po + i
                Dim mp As Point
                If cheek(dp) AndAlso Array.IndexOf(before.ToArray, dp) = -1 Then
                    mp = get_map_point(dp)
                    get_map(mp.Y, mp.X) = New node(po, get_map(po_xy.Y, po_xy.X).n + 1)
                    ans.Add(get_map(mp.Y, mp.X))
                    If dp = t_point Then tf = True : Exit While
                    q_point.Enqueue(dp)
                    q_xy.Enqueue(mp)
                End If
            Next
        End While
        If tf = True Then
            ac()
            Label13.Text = get_map(t.Y, t.X).n - 1
            gp = get_map_point(get_map(t.Y, t.X).p)
            Timer2.Enabled = True
        Else
            Label13.Text = "無解"
        End If
    End Sub
    Sub ac()
        Dim gg() As Point = {New Point(t_point.X, t_point.Y - 33),
        New Point(t_point.X + 33, t_point.Y),
        New Point(t_point.X, t_point.Y + 33),
        New Point(t_point.X - 33, t_point.Y)
        }
        Dim num As New Integer
        before.Clear()
        Do
            Dim ans As New HashSet(Of Point)
            num += 1
            Dim ab As New List(Of Point)
            Dim chk As Point
            For Each j In now
                For i = -33 To 33 Step 66
                    chk.X = j.X : chk.Y = j.Y + i
                    If cheek(chk) = True AndAlso Array.IndexOf(before.ToArray, chk) = -1 Then ab.Add(chk)
                    chk.X = j.X + i : chk.Y = j.Y
                    If cheek(chk) = True AndAlso Array.IndexOf(before.ToArray, chk) = -1 Then ab.Add(chk)
                Next
            Next
            before = now
            now = ab
            For Each i In now
                ans.Add(i)
            Next
            For Each i In ans
                If i <> t_point Then g.DrawString(num, Label1.Font, Brushes.Black, i)
                If Array.IndexOf(gg, i) <> -1 Then Exit Do
                My.Application.DoEvents()
                Threading.Thread.Sleep(100)
            Next
        Loop
    End Sub
    Sub draw_map()
        Dim x, y As New Integer
        Dim p As Point
        For i = 1 To 9
            x = 0
            For j = 1 To 9
                g.DrawRectangle(Pens.Gray, x, y, 33, 33)
                p.X = x : p.Y = y
                map(i, j) = p
                x += 33
            Next
            y += 33
        Next
    End Sub
    Sub ar_()
        For Each i In map
            ar.Add(i)
        Next
        now.Add(s_point)
    End Sub
End Class
