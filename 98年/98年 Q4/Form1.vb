Public Class Form1
    Dim data As Decimal()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        data = My.Computer.FileSystem.ReadAllText(TextBox1.Text).Split(" ").Select(Function(x) CDec(x)).ToArray
        Dim t, a, b, c, d As New ArrayList

        For i = 19 To data.Count - 1
            t.Add(Format(data(i), "00.00"))
            a.Add(Format(aa(i), "00.00"))
            b.Add(Format(bb(i), "00.00"))
            c.Add(Format(a(a.Count - 1) - b(b.Count - 1), "00.00"))
            d.Add(Format((4 * data(i - 4) - data(i - 19)) / 3, "00.00"))
        Next
        For i = 1 To 4
            t.Add("00.00")
            a.Add("00.00")
            b.Add("00.00")
            c.Add("00.00")
            d.Add(Format((4 * data(data.Count - 1 + i - 4) - data(data.Count - 1 + i - 19)) / 3, "00.00"))
        Next
        TextBox3.Text = Join(t.ToArray, " ")
        TextBox4.Text = Join(a.ToArray, " ")
        TextBox5.Text = Join(b.ToArray, " ")
        TextBox6.Text = Join(c.ToArray, " ")
        TextBox7.Text = Join(d.ToArray, " ")
        My.Computer.FileSystem.WriteAllText(TextBox2.Text, Join(t.ToArray, " ") & vbCrLf, False)
        My.Computer.FileSystem.WriteAllText(TextBox2.Text, Join(a.ToArray, " ") & vbCrLf, True)
        My.Computer.FileSystem.WriteAllText(TextBox2.Text, Join(b.ToArray, " ") & vbCrLf, True)
        My.Computer.FileSystem.WriteAllText(TextBox2.Text, Join(c.ToArray, " ") & vbCrLf, True)
        My.Computer.FileSystem.WriteAllText(TextBox2.Text, Join(d.ToArray, " "), True)
    End Sub
    Function aa(n As Integer)
        Dim total As New Decimal
        For i = n - 4 To n
            total += data(i)
        Next
        Return total / 5
    End Function
    Function bb(n As Integer)
        Dim total As New Decimal
        For i = n - 19 To n
            total += data(i)
        Next
        Return total / 20
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class
