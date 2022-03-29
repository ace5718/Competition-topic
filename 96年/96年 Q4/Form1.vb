Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s As New Stack(Of String)
        Dim ar As New ArrayList
        Dim n As String = ""
        For Each i In TextBox1.Text
            Select Case i
                Case "+", "-", "*", "/"
                    ar.Add(n) : n = ""
                    While s.Count <> 0 AndAlso chk(s.Peek) >= chk(i)
                        ar.Add(s.Pop)
                    End While
                    s.Push(i)
                Case "("
                    s.Push(i)
                Case ")"
                    ar.Add(n) : n = ""
                    While s.Count <> 0 AndAlso s.Peek <> "("
                        ar.Add(s.Pop)
                    End While
                Case Else
                    n &= i
            End Select
        Next
        While n <> ""
            ar.Add(n) : n = ""
        End While
        While s.Count <> 0
            If s.Peek = "(" Then s.Pop() Else ar.Add(s.Pop)
        End While
        TextBox2.Text = Join(ar.ToArray, " ")
    End Sub
    Function chk(s As String) As Integer
        Select Case s
            Case "*", "/" : Return 2
            Case "+", "-" : Return 1
        End Select
    End Function
End Class

