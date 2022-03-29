Imports System.Text.RegularExpressions
Public Class Form1
    Dim s As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As String = TextBox1.Text.Replace("-", "")
        TextBox2.Text = ISBN_10(t)
        TextBox3.Text = ISBN_13(t)
    End Sub
    Function ISBN_10(t As String)
        Dim total As New Integer
        For i = 10 To 2 Step -1
            total += Val(t(10 - i)) * i
        Next
        s = 11 - total Mod 11
        If s = 10 Then s = "X"
        If s = 11 Then s = "0"
        Return Regex.Replace(t & s, "^(\d{3})(157|204|421|442|7198|7323|8573)(\d+)(\d|X)", "$1-$2-$3-$4")
    End Function

    Function ISBN_13(t As String)
        t = "978" & t
        Dim total As New Integer
        For i = 1 To t.Count
            total += Val(Mid(t, i, 1)) * If(i Mod 2 = 1, 1, 3)
        Next
        s = If(total Mod 10 = 0, 0, 10 - total Mod 10)
        Return Regex.Replace(t & s, "^(978)(\d{3})(157|204|421|442|7198|7323|8573)(\d+)(\d|X)", "$1-$2-$3-$4-$5")
    End Function
End Class
