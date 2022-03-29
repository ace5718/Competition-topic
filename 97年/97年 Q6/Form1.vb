Public Class Form1
    Dim s As String = ""
    Dim chk As Boolean = True
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Label1.Text = 0
    End Sub 'AC
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Label1.Text = 0 : Label2.Text = ""
    End Sub 'CE
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Val(Label1.Text) > 0 Then Label1.Text = Math.Log10(Label1.Text)
    End Sub 'Log
    Private Sub Button8_Click(sender As Button, e As EventArgs) Handles Button19.Click, Button9.Click, Button8.Click, Button3.Click, Button2.Click, Button15.Click, Button14.Click, Button13.Click, Button10.Click, Button1.Click
        If chk = False Or Not IsNumeric(Label1.Text) Or Label1.Text = "0" Then Label1.Text = "" : chk = True
        Label1.Text &= sender.Text
    End Sub '數字
    Private Sub Button18_Click(sender As Button, e As EventArgs) Handles Button18.Click
        If sender.Text = "." AndAlso Label1.Text.IndexOf(".") = -1 Then Label1.Text &= sender.Text
    End Sub '.

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        If Label1.Text.IndexOf("-") = -1 AndAlso Label1.Text <> "0" Then
            Label1.Text = Label1.Text.PadLeft((Label1.Text.Count + 1), "-")
        ElseIf Label1.Text <> "0" Then
            Label1.Text = Label1.Text.Replace("-", "")
        End If
    End Sub

    Private Sub Button11_Click(sender As Button, e As EventArgs) Handles Button7.Click, Button6.Click, Button12.Click, Button11.Click
        Select Case sender.Text
            Case "+"
                If Len(Label2.Text) > 0 AndAlso chk = False Then
                    Label2.Text = Label2.Text.Replace(s, "")
                    Label2.Text &= "+"
                Else
                    Label2.Text &= Label1.Text & "+"
                End If
                s = "+"
            Case "-"
                If Len(Label2.Text) > 0 AndAlso chk = False Then
                    Label2.Text = Label2.Text.Replace(s, "")
                    Label2.Text &= "-"
                Else
                    Label2.Text &= Label1.Text & "-"
                End If
                s = "-"
            Case "x"
                If Len(Label2.Text) > 0 AndAlso chk = False Then
                    Label2.Text = Label2.Text.Replace(s, "")
                    Label2.Text &= "x"
                Else
                    Label2.Text &= Label1.Text & "x"
                End If
                s = "x"
            Case "/"
                If Len(Label2.Text) > 0 AndAlso chk = False Then
                    Label2.Text = Label2.Text.Replace(s, "")
                    Label2.Text &= "/"
                Else
                    Label2.Text &= Label1.Text & "/"
                End If
                s = "/"
        End Select
        chk = False
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim str As String = Label2.Text & Label1.Text
        Dim t = ""
        Dim st As New Stack
        Dim num As New List(Of Single)

        Do
            num.Clear()

            For Each i In str & " "
                If IsNumeric(i) Or i = "." Then
                    t &= i
                Else
                    num.Add(Val(t)) : t = ""
                    If st.Count > 0 AndAlso cheek(i) <= cheek(st.Peek) Then
                        get_ans(st, num)
                    End If
                    st.Push(i)
                End If
            Next
            str = ""
            For i = num.Count - 1 To 0 Step -1
                If st.Count > 0 Then
                    If st.Peek <> " " Then
                        str &= st.Pop & num(i)
                    Else
                        str &= num(i)
                        st.Pop()
                    End If
                Else
                    str &= num(i)
                End If
            Next
            If num.Count > 1 Then str = StrReverse(str)
        Loop Until num.Count = 1
        Label1.Text = str
        Label2.Text = ""
    End Sub

    Sub get_ans(st As Stack, num As List(Of Single))
        Dim a, b As Single
        a = num(num.Count - 2) : b = num(num.Count - 1)
        For i = 1 To 2
            num.RemoveAt(num.Count - 1)
        Next
        Select Case st.Pop
            Case "+"
                num.Add(a + b)
            Case "-"
                num.Add(a - b)
            Case "x"
                num.Add(a * b)
            Case "/"
                num.Add(a / b)
        End Select
    End Sub
    Function cheek(str As String)
        Select Case str
            Case "+", "-"
                Return 1
            Case "x", "/"
                Return 2
            Case Else
                Return 0
        End Select
    End Function


End Class
