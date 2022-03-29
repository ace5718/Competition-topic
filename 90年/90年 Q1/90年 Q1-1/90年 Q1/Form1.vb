Public Class Form1
    Dim r As New Random()
    Dim t(5) As Integer
    Dim num, s As New Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i = 1 To 8
            Controls("TextBox" & i).Text = ""
            Controls("TextBox" & i).Text = r.Next(1, 43)
            For j = 1 To 8
                If i <> j And Controls("TextBox" & j).Text = Controls("TextBox" & i).Text Then i -= 1 : Exit For
            Next
        Next
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        num += 1
        Dim ts(5) As Integer
        For i = 0 To 5
            t(i) = r.Next(1, 9)
            For j = 0 To 5
                If i <> j And t(i) = t(j) Then i -= 1 : Exit For Else ts(i) = Val(Controls("TextBox" & t(i)).Text)
            Next
        Next
        For i = 0 To 5
            For j = 0 To 5
                If ts(i) < ts(j) Then s = ts(i) : ts(i) = ts(j) : ts(j) = s
            Next
        Next
        TextBox9.Text &= "(" & num & ")" & String.Join(",", ts.ToArray) & vbCrLf
    End Sub
End Class
