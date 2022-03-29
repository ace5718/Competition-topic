Public Class Form1
    Dim x, y As New List(Of Decimal)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox3.Text = ""
        TextBox4.Text = ""
        get_xy()
        ans()
        For i = 9 To x.Count - 1
            Dim x1, y1 As New List(Of Decimal)
            For j = i - 9 To i
                x1.Add(x(j))
                y1.Add(y(j))
            Next
            TextBox3.Text &= Format(b(x1, y1), "0.0") & "  "
            Dim t As Decimal = a(x1, y1) + b(x1, y1) * (i + 2)
            If i + 2 <> x(x.Count - 1) + 1 Then TextBox4.Text &= Format(t, "0.0") & "  "
        Next
        ' Stop
    End Sub
    Sub get_xy()
        x.Clear()
        y.Clear()
        For Each i In TextBox1.Text.Split("  ")
            x.Add(i)
        Next
        For Each i In TextBox2.Text.Split("  ")
            y.Add(i)
        Next
    End Sub
    Sub ans()
        For i = 1 To 10
            If i <> 1 Then TextBox3.Text &= "0.0 "
            TextBox4.Text &= "0.0 "
        Next
    End Sub
    Function b(x As List(Of Decimal), y As List(Of Decimal)) As Decimal
        Dim xt, yt As Decimal
        Dim aa, bb As Decimal
        For i = 0 To x.Count - 1
            xt += x(i)
            yt += y(i)
        Next
        xt /= x.Count
        yt /= y.Count

        For i = 0 To x.Count - 1
            aa += (x(i) - xt) * (y(i) - yt)
            bb += (x(i) - xt) ^ 2
        Next

        Return aa / bb
    End Function
    Function a(x As List(Of Decimal), y As List(Of Decimal)) As Decimal
        Dim xt, yt As Decimal
        For i = 0 To x.Count - 1
            xt += x(i)
            yt += y(i)
        Next
        xt /= x.Count
        yt /= y.Count

        Dim ans As Decimal = yt - b(x, y) * xt
        Return ans
    End Function
End Class

