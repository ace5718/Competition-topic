Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As String() = TextBox1.Text.Replace(vbCrLf, "!").Split("!")
        t = t(1).Split(" ")
        Dim k, s, k1, s1, com As New Integer
        Do Until k = t.Count - 1
            Dim totol As New Integer
            For i = k To s
                totol += t(i)
                If com < totol Then com = totol : s1 = s : k1 = k
            Next
            s += 1
            If s > t.Count - 1 Then k += 1 : s = k + 1
        Loop
        TextBox2.Text = com & vbCrLf & k1 & " " & s1
    End Sub
End Class
