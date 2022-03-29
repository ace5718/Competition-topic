Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Count = 8 And TextBox2.Text.Count = 8 Then
            Dim s() As Integer = {0, 7, 4, 1, 8, 5, 2, 9, 6, 3}
            Dim n As Integer
            For i = Val(TextBox1.Text) To Val(TextBox2.Text)
                n += 1
                TextBox4.Text &= String.Format("{0}{1}@antu.edu.tw;", i, s(get_number(i)))
                If n = 3 Then TextBox4.Text &= vbCrLf : n = 0
            Next
            Dim t$() = TextBox3.Text.Replace(" ", ",").Split(",")
            For Each i In t
                If i <> "" And i.Count = 8 Then
                    n += 1
                    TextBox4.Text &= i & s(get_number(i)) & "@antu.edu.tw;"
                    If n = 3 Then TextBox4.Text &= vbCrLf : n = 0
                End If
            Next
            TextBox4.Text = Strings.LSet(TextBox4.Text, TextBox4.TextLength - 1)
        Else
            MsgBox("輸入錯誤")
        End If
    End Sub
    Function get_number(t As String)
        Dim number As Integer
        For i = 1 To 8
            number += Val(Mid(t, i, 1)) * i
        Next
        Return number Mod 10
    End Function
End Class
