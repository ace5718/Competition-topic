Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a, t As New ArrayList
        For Each i In TextBox1.Text
            If a.Contains(i) Then
                t(a.IndexOf(i)) += 1
            Else
                a.Add(i)
                t.Add(1)
            End If
        Next
        Dim a2 = a.ToArray, t2 = t.ToArray
        Array.Sort(t2, a2)
        For i = a.Count - 1 To 0 Step -1
            TextBox2.Text &= """" & a2(i) & """=" & t2(i) & ";" & vbNewLine
        Next
    End Sub
End Class
