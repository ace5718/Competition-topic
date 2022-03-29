Public Class Form1
    '初始步驟
    Class node
        Public type As Integer = 3
        Public point As Point
        Public path As Point?
        Public Sub New(a As Point)
            point = a
        End Sub
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        For i = 5 To 7
            CType(Controls("Label" & i), Label).Image = New Bitmap(60, 60)
            Draw_Objet(i - 5, Controls("Label" & i), New Point(5, 5))
        Next
        Get_SC() : Draw_Main()
    End Sub

    Sub Draw_Objet(num As Integer, ByRef o As Object, p As Point)
        Dim bm As Bitmap = o.image
        Dim g As Graphics = Graphics.FromImage(bm)
        Select Case num
            Case 0
                g.FillEllipse(Brushes.Black, p.X, p.Y, 50, 50)
            Case 1
                Dim pe As New Pen(Color.Blue, 2)
                g.FillEllipse(Brushes.White, p.X, p.Y, 50, 50)
                g.DrawEllipse(pe, p.X, p.Y, 50, 50)
            Case 2
                Dim pe As New Pen(Color.Red, 2)
                g.FillRectangle(Brushes.White, p.X, p.Y, 50, 50)
                g.DrawRectangle(pe, p.X, p.Y, 50, 50)
        End Select
        o.image = bm
    End Sub '畫物件

    Sub Draw_Main()
        PictureBox1.Image = New Bitmap(700, 700)
        Dim bm As Bitmap = PictureBox1.Image
        Dim g As Graphics = Graphics.FromImage(bm)
        g.Clear(DefaultBackColor)
        For i = 1 To 11
            g.DrawLine(Pens.Black, i * 60, 60, i * 60, 660)
            g.DrawLine(Pens.Black, 60, i * 60, 660, i * 60)
        Next

        My.Application.DoEvents()
        Threading.Thread.Sleep(10)

        For Each i In sc : Draw_Objet(i.type, PictureBox1, i.point - New Point(25, 25)) : Next
        PictureBox1.Image = bm
    End Sub '畫主畫面

    Dim sc(10, 10) As node
    Sub Get_SC()
        Dim temp As Integer = 60
        For i = 0 To 10
            Dim num As Integer = 1
            For j = 0 To 10 : sc(i, j) = New node(New Point(num * 60, temp)) : num += 1 : Next
            temp += 60
        Next
    End Sub '建構資料
    '初始步驟

    '第一項功能
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Random_Objet() : Seach_ed()
    End Sub

    Dim st As Point?, ed As Point?
    Sub Random_Objet()
        Dim cost, x, y As New Integer
        Dim ran As New Random
        Clear_type()

        Do
            x = ran.Next(0, 11) : y = ran.Next(0, 11)
            If sc(x, y).type = 3 Then sc(x, y).type = 0 : cost += 1
        Loop Until cost = 32

        Do
            x = ran.Next(0, 11) : y = ran.Next(0, 11)
            If sc(x, y).type = 3 Then st = New Point(x, y) : sc(x, y).type = 1 : Exit Do
        Loop

        Do
            x = ran.Next(0, 11) : y = ran.Next(0, 11)
            If sc(x, y).type = 3 Then ed = New Point(x, y) : sc(x, y).type = 2 : Exit Do
        Loop
        Draw_Main()
    End Sub '隨機產生物件
    '第一項功能

    '第二項功能
    Dim type As Integer? = Nothing
    Private Sub PictureBox1_Click(sender As Object, e As MouseEventArgs) Handles PictureBox1.Click
        Dim p As Point = Get_point(New Point(e.X, e.Y))
        If Not IsNothing(type) Then
            If sc(p.X, p.Y).type = 3 Then
                sc(p.X, p.Y).type = type
                type = Nothing
            End If
        Else
            If sc(p.X, p.Y).type <> 3 Then
                type = sc(p.X, p.Y).type
                sc(p.X, p.Y).type = 3
            End If
        End If

        Get_se() : Draw_Main()
        If IsNothing(type) AndAlso (Not IsNothing(st) And Not IsNothing(ed)) Then Seach_ed()
    End Sub '移動物件

    Sub Get_se()
        st = Nothing : ed = Nothing
        For i = 0 To 10
            For j = 0 To 10
                Select Case sc(i, j).type
                    Case 1 : st = New Point(i, j)
                    Case 2 : ed = New Point(i, j)
                End Select
            Next
        Next
    End Sub '取的起點,終點

    Function Get_point(p As Point)
        Dim temp As Array = {Integer.MaxValue, New Point}
        For i = 0 To 10
            For j = 0 To 10
                Dim t As Point = sc(i, j).point
                Dim num As Integer = Math.Abs(p.X - t.X) + Math.Abs(p.Y - t.Y)
                If num < temp(0) Then temp = {num, New Point(i, j)}
            Next
        Next
        Return temp(1)
    End Function '取得離滑鼠點擊座標最近的點
    '第二項功能

    Dim temp As Point() = {New Point(-1, 0), New Point(0, 1), New Point(1, 0), New Point(0, -1)}
    Sub Seach_ed()
        Dim s As Point = CType(st, Point), e As Point = CType(ed, Point)

        Dim q As New Queue(Of Point)
        q.Enqueue(st)

        Dim tf As Boolean = False : Clear_path()
        sc(s.X, s.Y).path = New Point(99, 99)
        Do
            Dim qm As Point = q.Dequeue
            For Each i In temp
                Dim qt As Point = qm + i
                If chk(qt) Then
                    sc(qt.X, qt.Y).path = qm
                    If qt = ed Then
                        Draw_Line(qt, PictureBox1)

                        Draw_Objet(1, PictureBox1, sc(s.X, s.Y).point - New Point(25, 25))
                        Draw_Objet(2, PictureBox1, sc(e.X, e.Y).point - New Point(25, 25))
                        tf = True : Exit Do
                    End If
                    q.Enqueue(qt)
                End If
            Next
        Loop Until q.Count = 0
        TextBox1.Text = If(tf, "規劃路線成功", "規劃路線失敗")
    End Sub '搜尋

    Sub Draw_Line(p1 As Point, ByRef o As Object)
        Dim bm As Bitmap = o.image
        Dim g As Graphics = Graphics.FromImage(bm)

        If sc(p1.X, p1.Y).path <> New Point(99, 99) Then
            Dim p2 As Point = sc(p1.X, p1.Y).path
            Dim pe As New Pen(Color.Blue, 4)
            g.DrawLine(pe, sc(p1.X, p1.Y).point, sc(p2.X, p2.Y).point)
            PictureBox1.Image = bm
            Draw_Line(p2, PictureBox1)
        End If
    End Sub '畫線

    Function chk(p As Point)
        Return ((p.X >= 0 And p.X <= 10) And (p.Y >= 0 And p.Y <= 10)) AndAlso (IsNothing(sc(p.X, p.Y).path) And sc(p.X, p.Y).type <> 0)
    End Function

    Sub Clear_type()
        For Each i In sc : i.type = 3 : Next
    End Sub

    Sub Clear_path()
        For Each i In sc : i.path = Nothing : Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class
