Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        input1.Text = ""
        output1.Text = ""
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        output1.Text = ""
        Dim r As Integer = Val(input1.Text)
        Dim arr, ar As New ArrayList
        Dim tf As Boolean
        Dim x, y As Integer
        x = y = 1
        Do
            For i = 1 To r
                If (x ^ 2) + (y ^ 2) = r Then
                    arr.Add(x)
                    ar.Add(y)
                End If
                y += 1
                If y > (r / 2) Then Exit For
            Next
            x += 1
            If x > (r / 2) AndAlso y > (r / 2) Then
                tf = True
            End If
            y = 1
        Loop While tf = False
        If arr.Count = 0 Then
            output1.Text = "Sorry,No answer found"
        Else
            output1.Text &= "count" & vbTab & "X" & vbTab & "Y" & vbCrLf
            For i = 0 To arr.Count - 1
                output1.Text &= i + 1 & vbTab & arr(i) & vbTab & ar(i) & vbCrLf
            Next
            output1.Text &= vbCrLf & "There are" & " " & ar.Count & " " & "possible answers"
        End If
    End Sub
End Class
