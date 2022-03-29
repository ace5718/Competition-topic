Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ip As String = TextBox1.Text.Split("/")(0)
        Dim mask As String = TextBox1.Text.Split("/")(1)
        TextBox2.Text = t1(ip, mask)
        TextBox4.Text = 2 ^ (32 - mask) - 2
    End Sub

    Function t1(ip As String, mask As String)
        Dim t() As String = ip.Split(".")
        Dim Binary As String = ""
        Dim k As New Integer
        For i = 0 To 3
            t(i) = Convert.ToString(CInt(t(i)), 2)
            t(i) = t(i).PadLeft(8, "0")
            Binary &= t(i) & "."
        Next
        TextBox3.Text = t2(t, mask)
        ReDim t(3)
        For i = 1 To Binary.Count
            If Mid(Binary, i, 1) = "." Then
                t(k) = Convert.ToInt32(t(k), 2) : k += 1
            Else
                If i < mask + 4 Then t(k) &= Mid(Binary, i, 1) Else t(k) &= "0"
            End If
        Next
        Return Join(t, ".")
    End Function

    Function t2(t() As String, mask As String)
        Dim a As New String("1", 32 - Val(mask))
        a = a.PadLeft(32, "0")
        Dim tt() As String = a.Split(".")
        Dim ans(3) As String
        For i = 1 To 3
            a = a.Insert(8 * i + i - 1, ".")
        Next
        For i = 0 To 3
            For j = 1 To t(i).Count
                ans(i) &= Mid(t(i), j, 1) Or Mid(tt(i), j, 1)
            Next
            ans(i) = Convert.ToInt32(ans(i), 2)
        Next
        Return Join(ans, ".")
    End Function
End Class
