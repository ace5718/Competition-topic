Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ans
        If cheek(TextBox4.Text) Then ans = Binary() Else ans = Real()
        Label4.Text = String.Format("Ans = {0}", ans)
    End Sub
    Function Binary() As String '二進位
        Dim t1 = TextBox1.Text, t2 = TextBox2.Text, t3 = TextBox3.Text
        Dim c As Integer = coding((t2 - t1) * 10 ^ t3)
        Dim x As Decimal = Convert.ToInt64(TextBox4.Text, 2)
        x = t1 + x * (t2 - t1) / (2 ^ c - 1)
        Return Format(x, "0." & New String("0", t3))
    End Function
    Function Real() As String '實數
        Dim t1 = TextBox1.Text, t2 = TextBox2.Text, t3 = TextBox3.Text
        Dim c As Integer = coding((t2 - t1) * 10 ^ t3)
        Dim x As Decimal = TextBox4.Text
        x = (x + t1 * -1) * (2 ^ c - 1) / (t2 - t1)
        Return Convert.ToString(CInt(x), 2).PadLeft(c, "0")
    End Function
    Function coding(t As Decimal) '編碼
        Dim i As Integer = 1
        While t > 2 ^ i
            i += 1
        End While
        Return i
    End Function
    Function cheek(t As String) As Boolean
        For Each i In t
            If i <> "0" And i <> "1" And i <> "." Then Return False
        Next
        Return True
    End Function
End Class
