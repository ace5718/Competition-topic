Public Class Form1
    Dim mox As Integer() = {0, 1, 1, 1, 0, -1, -1, -1}
    Dim moy As Integer() = {-1, -1, 0, 1, 1, 1, 0, -1}
    Dim map(7, 7) As Integer
    Dim chk As Boolean() = {False, False, False, False, False, False, False, False}
    Dim chk3 As New List(Of String) '上次能否行走的所有路徑
    Dim ttt As New ArrayList  '答案
    Dim p, y, x As New Integer 'x y 現在所在的座標
    Dim c As Boolean = True
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        get_map()
        Do
            get_chk()
            Dim a As Integer = ttt.Count
            get_chk3() '上次能否行走的所有路徑
            Do
                c = True
                For i = 0 To 7
                    If chk(i) = True Then
                        If p > 7 Then p -= 8 Else p = i + 4 '行走方向的相反
                        map(y, x) = 0 '清除之前行走的紀錄
                        y += moy(i) : x += mox(i) '現在座標加上行走方位
                        If ttt.IndexOf(y & "," & x) = -1 Then ttt.Add(y & "," & x)
                        map(y, x) = 2 '紀錄目前位置
                        Exit For
                    Else
                        Try
                            If ttt.IndexOf(y & "," & x) = -1 Then
                                ttt.Add(y & "," & x)
                                map(y, x) = 2
                                Exit For
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
                If ttt.Count = a Then chk2() : c = False '無法繼續行走
            Loop Until c = True
        Loop Until map(7, 7) = 2
        For i = 0 To ttt.Count - 1
            TextBox2.Text &= "(" & ttt(i) & ")"
        Next
    End Sub
    Sub get_map()
        Dim m As String() = My.Computer.FileSystem.ReadAllText("maze.txt").ToString.Replace(vbCrLf, "!").Split("!")
        For i = 0 To m.Count - 1
            Dim s As New Integer
            For Each j In m(i).Split(" ")
                map(i, s) = Val(j)
                s += 1
            Next
        Next
    End Sub
    Sub get_chk()
        For i = 0 To 7
            chk(i) = False
        Next
        For i = 0 To 7
            Try
                If i <> p Then
                    If map(y + moy(i), x + mox(i)) = 0 And ttt.IndexOf((y + moy(i)) & "," & (x + mox(i))) = -1 Then chk(i) = True
                Else
                    chk(i) = False
                End If
            Catch ex As Exception
                chk(i) = False
            End Try
        Next
    End Sub
    Sub chk2()
        For i = ttt.Count - 1 To 0 Step -1
            Dim t As String() = chk3(i + 1).Split(",")
            For j = 0 To 7
                If t(j) = "True" Then
                    If ttt.IndexOf(Val(ttt(i).ToString.Split(",")(0)) + moy(j) & "," & Val(ttt(i).ToString.Split(",")(1)) + mox(j)) = -1 Then
                        y = Val(ttt(i).ToString.Split(",")(0)) + moy(j) : x = Val(ttt(i).ToString.Split(",")(1)) + mox(j)
                        If p > 7 Then p -= 8 Else p = i + 4
                        Exit Sub
                    End If
                End If
            Next
        Next
    End Sub
    Sub get_chk3()
        Dim t(7) As Boolean
        Dim s As String
        For i = 0 To 7
            Try
                If map(y + moy(i), x + mox(i)) = 0 Then t(i) = True Else t(i) = False
            Catch ex As Exception
                t(i) = False
            End Try
        Next
        For i = 0 To 7
            If i = 7 Then s &= t(i) Else s &= t(i) & ","
        Next
        chk3.Add(s)
    End Sub
End Class

