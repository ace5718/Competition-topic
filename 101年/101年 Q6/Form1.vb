Public Class Form1
    Dim temp As Point() = {
    New Point(-1, 0),
    New Point(-1, 1),
    New Point(0, 1),
    New Point(1, 1),
    New Point(1, 0),
    New Point(1, -1),
    New Point(0, -1),
    New Point(-1, -1)}

    Dim map(7, 7) As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input As String() = IO.File.ReadAllLines(TextBox1.Text)
        For i = 0 To 7
            For j = 0 To 7
                map(i, j) = input(i).Split(" ")(j)
            Next
        Next
        path.Clear()
        path.Add(New Point(0, 0))
        seach(New Point(0, 0))

        TextBox2.Text = ""
        For Each i In path
            TextBox2.Text &= "(" & i.X & "," & i.Y & ")"
        Next
    End Sub

    Dim path As New List(Of Point)
    Sub seach(p As Point)
        For Each i In temp
            If Array.IndexOf(path.ToArray, New Point(7, 7)) = -1 AndAlso chk(p + i) Then
                path.Add(p + i)
                seach(p + i)
            End If
        Next
    End Sub

    Function chk(p As Point)
        Return (((p.X >= 0 And p.X <= 7) And (p.Y >= 0 And p.Y <= 7)) AndAlso (map(p.X, p.Y) <> "1" And Array.IndexOf(path.ToArray, p) = -1))
    End Function
End Class
