Public Class Form1
    Dim r As New Random
    Dim g As Graphics
    Dim chk As Boolean
    Dim j As Integer = 100
    Dim dx, dy As New List(Of Integer) 'Label移動方向X,Y
    Dim ans As New List(Of Integer) '抓出來的數字
    Dim la As New List(Of Label) 'Label
    Dim s(41) As Point '起始點
    Dim x As Integer() = {-2, 2, -2, -2} '移動方向X
    Dim y As Integer() = {2, 2, 2, -2} '移動方向Y
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ans.Clear()
        Timer1.Enabled = False
        For i = 1 To 42
            la(i - 1).Location = s(i - 1)
            dr()
        Next
        j = 100
    End Sub '歸位
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i = 1 To 42
            If ans.Count > 5 And i = 1 Then
                la(i - 1).Location = s(i - 1)
                ans.Clear()
                j = 100
                dr()
            End If
            dx.Add(x(r.Next(0, 4))) : dy.Add(y(r.Next(0, 4)))
        Next
        rc() '隨機座標
        chk = True
        Timer1.Enabled = True
    End Sub '啟動
    Sub FL(sender As Object, e As EventArgs) Handles MyBase.Shown
        g = Me.CreateGraphics
        For i = 1 To 42
            la.Add(Controls("Label" & i))
            s(i - 1) = la(i - 1).Location
            la(i - 1).Text = i
        Next
        dr()
    End Sub 'label 宣告
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For i = 1 To 42
            If chk_2(i) = True Then
                Dim x As Integer = Controls("Label" & i).Location.X
                Dim y As Integer = Controls("Label" & i).Location.Y
                If (x + dx(i - 1)) > (800 + 30) Or (x + dx(i - 1)) < 130 Then
                    If chk = True Then
                        chk = False
                        Controls("Label" & i).Top = ans1.Top
                        Controls("Label" & i).Left = ans1.Left + j
                        ans.Add(i)
                        j += 30
                        Exit For
                    End If
                    dx(i - 1) *= -1
                ElseIf ((y + dy(i - 1)) > (460 + 30) Or (y + dy(i - 1) < 80)) Then
                    If chk = True Then
                        chk = False
                        Controls("Label" & i).Top = ans1.Top
                        Controls("Label" & i).Left = ans1.Left + j
                        ans.Add(i)
                        j += 30
                        Exit For
                    End If
                    dy(i - 1) *= -1
                End If
                x += dx(i - 1) : y += dy(i - 1)
                Controls("Label" & i).Top = y
                Controls("Label" & i).Left = x
                dr()
            End If
        Next
    End Sub '判斷超出範圍及彈跳
    Sub dr()
        g.FillRectangle(Brushes.Black, 110, 70, 760, 460)
    End Sub '畫圖
    Sub rc()
        For i = 0 To 41
            If chk_2(i + 1) = True Then
                la(i).Top = r.Next(100, 400)
                la(i).Left = r.Next(130, 750)
            End If
        Next
    End Sub '隨機座標
    Function chk_2(n As Integer) As Boolean
        For Each i In ans
            If n = Val(i) Then Return False
        Next
        Return True
    End Function '跳過已經取出來的數
End Class
