Public Class Form1
    Dim t(8, 8) As Integer
    Dim ar As New ArrayList
    Dim s() As String
    Sub a()
        Dim tf As Boolean = True
        Dim n, m As New Integer
        n = 2 : m = 3
        Do While tf = True
            Try
                t(s(n), s(m)) = 2
            Catch ex As Exception
                tf = False
            End Try
            n += 2
            m += 2
        Loop
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'ar(0) = y ar(1) = x
        s = TextBox1.Text.Split(" ")
        ar.Add(s(0)) : ar.Add(s(1))
        Dim n1 As Integer = InputBox("請輸入移動數字鍵")
        Dim tf As Boolean
        Dim n, m As New Integer
        n = 2 : m = 3
        Do While tf
            Try
                t(s(n), s(m)) = 2
            Catch ex As Exception
                tf = True
            End Try
            n += 2
            m += 2
        Loop
        Stop
        TextBox2.Text &= "請輸入移動數字鍵:" & n1 & vbNewLine
        Select Case n1
            Case 0
                TextBox2.Text &= "馬移動到新位置:"
                If (CInt(ar(0)) + 1) > 8 Or (CInt(ar(1)) + 2) > 8 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因超出棋盤而保持原座標)" & vbNewLine
                    Exit Sub
                ElseIf t(ar(0), ar(1) + 1) = 2 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因馬腳困住而保持原座標)" & vbNewLine
                    Exit Sub
                End If
                t(ar(0), ar(1)) = 0
                ar(0) = CInt(ar(0)) + 1 : ar(1) = CInt(ar(1)) + 2
                TextBox2.Text &= ar(0) & " " & ar(1) & vbNewLine
                t(ar(0), ar(1)) = 1
            Case 1
                TextBox2.Text &= "馬移動到新位置:"
                If (CInt(ar(0)) - 1) < 1 Or (CInt(ar(1)) + 2) > 8 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因超出棋盤而保持原座標)" & vbNewLine
                    Exit Sub
                ElseIf t(ar(0), ar(1) + 1) = 2 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因馬腳困住而保持原座標)" & vbNewLine
                    Exit Sub
                End If
                t(ar(0), ar(1)) = 0
                ar(0) = CInt(ar(0)) - 1 : ar(1) = CInt(ar(1)) + 2
                TextBox2.Text &= ar(0) & " " & ar(1) & vbNewLine
                t(ar(0), ar(1)) = 1
            Case 2
                TextBox2.Text &= "馬移動到新位置:"
                If (CInt(ar(0)) - 2) < 1 Or (CInt(ar(1)) + 1) > 8 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因超出棋盤而保持原座標)" & vbNewLine
                    Exit Sub
                ElseIf t(ar(0) + 1, ar(1)) = 2 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因馬腳困住而保持原座標)" & vbNewLine
                    Exit Sub
                End If
                t(ar(0), ar(1)) = 0
                ar(0) = CInt(ar(0)) - 2 : ar(1) = CInt(ar(1)) + 1
                TextBox2.Text &= ar(0) & " " & ar(1) & vbNewLine
                t(ar(0), ar(1)) = 1
            Case 3
                TextBox2.Text &= "馬移動到新位置:"
                If (CInt(ar(0)) - 2) < 1 Or (CInt(ar(1)) - 1) < 1 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因超出棋盤而保持原座標)" & vbNewLine
                    Exit Sub
                ElseIf t(ar(0) + 1, ar(1)) = 2 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因馬腳困住而保持原座標)" & vbNewLine
                    Exit Sub
                End If
                t(ar(0), ar(1)) = 0
                ar(0) = CInt(ar(0)) - 2 : ar(1) = CInt(ar(1)) - 1
                TextBox2.Text &= ar(0) & " " & ar(1) & vbNewLine
                t(ar(0), ar(1)) = 1
            Case 4
                TextBox2.Text &= "馬移動到新位置:"
                If (CInt(ar(0)) - 1) < 1 Or (CInt(ar(1)) - 2) < 1 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因超出棋盤而保持原座標)" & vbNewLine
                    Exit Sub
                ElseIf t(ar(0), ar(1) - 1) = 2 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因馬腳困住而保持原座標)" & vbNewLine
                    Exit Sub
                End If
                t(ar(0), ar(1)) = 0
                ar(0) = CInt(ar(0)) - 1 : ar(1) = CInt(ar(1)) - 2
                TextBox2.Text &= ar(0) & " " & ar(1) & vbNewLine
                t(ar(0), ar(1)) = 1
            Case 5
                TextBox2.Text &= "馬移動到新位置:"
                If (CInt(ar(0)) + 1) > 8 Or (CInt(ar(1)) - 2) < 1 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因超出棋盤而保持原座標)" & vbNewLine
                    Exit Sub
                ElseIf t(ar(0), ar(1) - 1) = 2 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因馬腳困住而保持原座標)" & vbNewLine
                    Exit Sub
                End If
                t(ar(0), ar(1)) = 0
                ar(0) = CInt(ar(0)) + 1 : ar(1) = CInt(ar(1)) - 2
                TextBox2.Text &= ar(0) & " " & ar(1) & vbNewLine
                t(ar(0), ar(1)) = 1
            Case 6
                TextBox2.Text &= "馬移動到新位置:"
                If (CInt(ar(0)) + 2) > 8 Or (CInt(ar(1)) - 1) < 1 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因超出棋盤而保持原座標)" & vbNewLine
                    Exit Sub
                ElseIf t(ar(0) + 1, ar(1)) = 2 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因馬腳困住而保持原座標)" & vbNewLine
                    Exit Sub
                End If
                t(ar(0), ar(1)) = 0
                ar(0) = CInt(ar(0)) + 2 : ar(1) = CInt(ar(1)) - 1
                TextBox2.Text &= ar(0) & " " & ar(1) & vbNewLine
                t(ar(0), ar(1)) = 1
            Case 7
                TextBox2.Text &= "馬移動到新位置:"
                If (CInt(ar(0)) + 2) > 8 Or (CInt(ar(1)) + 1) > 8 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因超出棋盤而保持原座標)" & vbNewLine
                    Exit Sub
                ElseIf t(ar(0) + 1, ar(1)) = 2 Then
                    TextBox2.Text &= ar(0) & " " & ar(1) & "(因馬腳困住而保持原座標)" & vbNewLine
                    Exit Sub
                End If
                t(ar(0), ar(1)) = 0
                ar(0) = CInt(ar(0)) + 2 : ar(1) = CInt(ar(1)) + 1
                TextBox2.Text &= ar(0) & " " & ar(1) & vbNewLine
                t(ar(0), ar(1)) = 1
            Case Else
                End
        End Select
    End Sub
End Class