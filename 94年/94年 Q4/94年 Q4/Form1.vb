Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t1(), t2(), t3(), t4() As String
        t1 = TextBox1.Text.Split(" ")
        t2 = TextBox2.Text.Split(" ")
        t3 = TextBox3.Text.Split(" ")
        t4 = TextBox4.Text.Split(" ")
        TextBox5.Text = get_ans1(t1(0), t1(1), t1(2))
        TextBox6.Text = get_ans2(t2(0), t2(1), t2(2))
        TextBox7.Text = get_ans3(t3(0), t3(1), t3(2))
        TextBox8.Text = get_ans4(t4(0), t4(1), t4(2))
    End Sub
    Function get_ans1(a As Double, b As String, c As Double)
        Dim s As Double
        Dim t() As Double = b.Split("/").Select(Function(x) CDbl(x)).ToArray
        s = a * t(0) / t(1) / c
        Return CInt(s)
    End Function
    Function get_ans2(a As Double, b As String, c As Double)
        Dim s As Double
        Dim t() As Double = b.Split("/").Select(Function(x) CDbl(x)).ToArray
        s = a * t(0) / t(1) / c
        Return CInt(s)
    End Function
    Function get_ans3(a As Double, b As String, c As Double)
        Dim s As Double
        Dim t() As Double = b.Split("/").Select(Function(x) CDbl(x)).ToArray
        s = a * t(0) / t(1) / c
        Return CInt(s)
    End Function
    Function get_ans4(a As Double, b As String, c As Double)
        Dim s As Double
        Dim t() As Double = b.Split("/").Select(Function(x) CDbl(x)).ToArray
        s = a * t(0) / t(1) / c
        Return CInt(s)
    End Function
End Class
