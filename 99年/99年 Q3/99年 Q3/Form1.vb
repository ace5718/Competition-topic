Public Class Form1
    Dim n As Integer
    Dim ar As New ArrayList
    Private Sub Button1_Click(sender As Object, ee As EventArgs) Handles Button1.Click
        n = Val(TextBox1.Text)
        If ar.Count = n Then Exit Sub
        TextBox1.ReadOnly = True
        ar.Add(Val(TextBox2.Text))
        DataGridView1.Rows.Add(ar.Count, TextBox2.Text, a, b, c, d, e)
        Label2.Text = "請輸入第" & ar.Count + 1 & "筆資料"
        If ar.Count = n Then Label2.Text = "資料輸入完畢"
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
    Function a()
        Dim tot As Decimal
        For Each i In ar
            tot += i
        Next
        Return Format(Math.Floor((tot * (1 / ar.Count)) * 100) / 100, "0.00")
    End Function
    Function b()
        If ar.Count = 1 Then Return "0.000"
        Dim aa, bb, n As New Decimal
        n = ar.Count
        For Each i In ar
            aa += i ^ 2
            bb += i
        Next
        Return Format(Math.Floor(Math.Sqrt(((aa * n) - (bb ^ 2)) / (n * (n - 1))) * 1000) / 1000, "0.000")
    End Function
    Function c()
        Dim tot As Decimal = 1
        For Each i In ar
            tot *= i
        Next
        Return Format(Math.Floor(tot ^ (1 / ar.Count) * 1000) / 1000, "0.000")
    End Function
    Function d()
        Dim tot As Decimal
        For Each i In ar
            tot += i ^ 2
        Next
        Return Format(Math.Floor(Math.Sqrt(tot * (1 / ar.Count)) * 1000) / 1000, "0.000")
    End Function
    Function e()
        Dim tot As Decimal
        For Each i In ar
            tot += 1 / i
        Next
        Return Format(Math.Floor(ar.Count / tot * 1000) / 1000, "0.000")
    End Function
End Class
