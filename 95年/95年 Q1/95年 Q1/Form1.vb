Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label2.Text = ""
        Label3.Text = ""
        Dim num As Integer = TextBox1.Text
        Dim ar As New List(Of Integer)
        Dim tf As Boolean
        For i = 2 To num
            tf = True
            For j = 2 To i - 1
                If i Mod j = 0 Then
                    tf = False
                    Exit For
                End If
            Next
            If tf Then ar.Add(i)
        Next
        Label2.Text = "質數有" & ar.Count & "個"
        Label3.Text = "最大的三個質數是" & "　"
        For i = ar.Count - 3 To ar.Count - 1 Step 1
            Label3.Text &= ar(i) & "　"
        Next
    End Sub
End Class
