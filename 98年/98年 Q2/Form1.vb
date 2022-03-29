Public Class Form1
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        TextBox1.Text = "1" & vbCrLf
        Dim num As String = "1"
        For i = 1 To NumericUpDown1.Value
            Dim cheek As String = Mid(num, 1, 1), str As String = "", count As New Integer
            For Each j In num & " "
                If j = cheek Then count += 1 Else str &= count & cheek : cheek = j : count = 1
            Next
            TextBox1.Text &= str & vbCrLf
            num = str
        Next
    End Sub
End Class
