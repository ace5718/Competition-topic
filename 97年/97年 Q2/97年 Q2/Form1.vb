Public Class Form1
    Dim tf As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If chk(TextBox1.Text) = True Then
            Dim s, m As New Integer
            Dim n As String = ""
            ISBN_10(s, m, n)
            ISBN_13(s, n)
        Else
            MsgBox("輸入錯誤")
        End If
    End Sub
    Function chk(s As String) As Boolean
        s = s.Replace("-", "")
        If s.Count = 9 Then
            For Each i In s
                If Not IsNumeric(i) Then Return False
            Next
            Return True
        End If
        Return False
    End Function
    Sub ISBN_10(s%, m%, n$)
        Dim te As String = TextBox1.Text.Replace("-", "")
        For i = 10 To 2 Step -1
            s += Val(Mid(te, 11 - i, 1) * i)
        Next
        m = 11 - (s Mod 11)
        Select Case m
            Case = 10 : n = "X"
            Case = 11 : n = "0"
            Case Else : n = m
        End Select
        If TextBox1.Text.Count > 9 Then
            TextBox2.Text = TextBox1.Text & "-" & n
        Else
            n = TextBox1.Text & n
            TextBox2.Text = String.Format("{0}-{1}-{2}-{3}",
                                   Mid(n, 1, 3), Mid(n, 4, 4), Mid(n, 8, 2), Mid(n, 10, 1))
        End If
    End Sub
    Sub ISBN_13(s%, n$)
        Dim cheek As Boolean = True
        Dim te As String = "978" & TextBox1.Text.Replace("-", "")
        For Each i In te
            If cheek = True Then
                s += Val(i) * 1 : cheek = False
            ElseIf cheek = False Then
                s += Val(i) * 3 : cheek = True
            End If
        Next
        n = s Mod 10 : If n <> 0 Then n = 10 - Val(n)
        If TextBox1.Text.Count > 9 Then
            TextBox3.Text = "978-" & TextBox1.Text & "-" & n
        Else
            n = TextBox1.Text & n
            TextBox3.Text = String.Format("978-{0}-{1}-{2}-{3}",
                                   Mid(n, 1, 3), Mid(n, 4, 4), Mid(n, 8, 2), Mid(n, 10, 1))
        End If
    End Sub
End Class
