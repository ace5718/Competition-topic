Public Class Form1
    Dim r As New Random
    Dim chk As String() = {"10", "01", "11", "001", "000"}
    Dim ans As String() = {"A", "B", "C", "D", "E"}
    Dim c, a As String
    Dim chk2 As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox3.Text = "" : TextBox5.Text = ""
        Dim h1 As String
        Do
            h1 = ""
            For i = 1 To r.Next(26, 51)
                h1 &= r.Next(0, 2)
            Next
            ch(h1)
        Loop Until chk2 = True
        TextBox1.Text = h1
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox4.Text = "" : TextBox6.Text = ""
        Dim h2 As String
        For i = 1 To r.Next(26, 51)
            h2 &= r.Next(0, 2)
        Next
        ch(h2)
        TextBox2.Text = h2
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For i = 1 To 2
            ch(Controls("TextBox" & i).Text)
            If chk2 = True Then
                Controls("TextBox" & i + 4).Text = a
            Else
                Controls("TextBox" & i + 2).ForeColor = Color.Red
                Controls("TextBox" & i + 2).Text = "不合理"
            End If
        Next
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub
    Function ch(text As String)
        c = "" : a = ""
        For Each i In text
            c &= i
            For Each j In chk
                If c <> j Then
                    chk2 = False
                ElseIf c = j Then
                    a &= ans(chk.IndexOf(chk.ToArray, c))
                    chk2 = True
                    c = ""
                    Exit For
                End If
            Next
        Next
        Return chk2
    End Function '判斷霍夫曼
End Class


