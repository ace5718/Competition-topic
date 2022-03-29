Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ar As New ArrayList

        For i = 1 To 4
            ar.Add(Controls("TextBox" & i).Text.Split(" "))
        Next
        Dim a = ar(0), b = ar(1), c = ar(2), d = ar(3)

        Dim left = IIf(a(0) > b(0), b, a)
        Dim right = IIf(a(0) < b(0), b, a)
        Stop
        Dim up = IIf(a(1) > b(1), a, b)
        Dim dn = IIf(a(1) < b(1), a, b)

        If a(0) = c(0) Or a(0) = d(0) Then
            If c(1) <= up(1) And c(1) >= dn(1) Or d(1) <= up(1) And d(1) >= dn(1) Then
                TextBox5.Text = "有相交"
            Else
                TextBox5.Text = "沒相交"
            End If
        End If

        Dim m1 = ((a(1) - b(1)) / (a(0) - b(0)))  '斜率
        Dim m2 = ((c(1) - d(1)) / (c(0) - d(0)))

        Dim x = (m1 * a(0) - a(1) - m2 * c(0) + c(1)) / (m1 - m2)
        Dim y = m1 * (x - a(0)) + Val(a(1))


        If x < left(0) Or x > right(0) Then
            TextBox5.Text = "沒相交"
        Else
            If y < up(1) Or y > dn(1) Then
                TextBox5.Text = "有相交"
            End If
        End If
    End Sub
End Class
