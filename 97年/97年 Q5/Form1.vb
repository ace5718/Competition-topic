Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim k, d As New List(Of String)
        Dim high, low, ending As Decimal()
        Dim str As String() = My.Computer.FileSystem.ReadAllText(TextBox1.Text).Replace(vbCrLf, "!").Split("!")
        k.Add(TextBox3.Text) : d.Add(TextBox4.Text)
        high = str(0).Split(" ").Select(Function(x) CDec(x)).ToArray
        low = str(1).Split(" ").Select(Function(x) CDec(x)).ToArray
        ending = str(2).Split(" ").Select(Function(x) CDec(x)).ToArray

        For i = 8 To high.Length - 1
            Dim rsv = ((ending(i) - low.Take(i + 1).Min) / (high.Take(i + 1).Max - low.Take(i + 1).Min)) * 100
            k.Add(Format(Val(k(k.Count - 1)) * 2 / 3 + rsv / 3, "0.00"))
            d.Add(Format(Val(d(d.Count - 1)) * 2 / 3 + Val(k(k.Count - 1)) / 3, "0.00"))
        Next

        My.Computer.FileSystem.WriteAllText(TextBox2.Text, Join(k.ToArray, " ") & vbCrLf, False)
        My.Computer.FileSystem.WriteAllText(TextBox2.Text, Join(d.ToArray, " "), True)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class
