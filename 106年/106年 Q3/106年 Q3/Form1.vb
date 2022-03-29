Public Class Form1
    Dim tt(6) As TextBox
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 7
            tt(i - 1) = Controls("textbox" & i)
            tt(i - 1).BackColor = Color.White
        Next
    End Sub
    Sub chk()
        TextBox8.Text = ""
        Dim num = {"1,2,3,5,6,7", "2,5", "1,3,4,5,7", "1,3,4,6,7", "2,3,4,6", "1,2,4,6,7", "1,2,4,5,6,7", "1,3,6", "1,2,3,4,5,6,7", "1,2,3,4,6,7"} '0 1 2 3 4 5 6 7 8 9
        For Each i In num
            Dim ch(6) As Integer
            Dim tf As Boolean = True
            For Each j In i.Split(",")
                ch(Val(j) - 1) = 1
            Next
            For j = 0 To ch.Count - 1
                If ch(j) = 1 Then
                    If tt(j).BackColor <> Color.Red Then tf = False
                Else
                    If tt(j).BackColor <> Color.White Then tf = False
                End If
            Next
            If tf Then TextBox8.Text = Array.IndexOf(num, i) : Exit Sub
        Next
        Dim num2 = {"3,6", "2,4,5,6,7", "1,2,3,4,6"} '1 6 9
        For Each i In num2
            Dim ch(6) As Integer
            Dim tf As Boolean = True
            For Each j In i.Split(",")
                ch(Val(j) - 1) = 1
            Next
            For j = 0 To ch.Count - 1
                If ch(j) = 1 Then
                    If tt(j).BackColor <> Color.Red Then tf = False
                Else
                    If tt(j).BackColor <> Color.White Then tf = False
                End If
            Next
            If tf Then
                Select Case Array.IndexOf(num2, i)
                    Case 0
                        TextBox8.Text = 1
                        Exit Sub
                    Case 1
                        TextBox8.Text = 6
                        Exit Sub
                    Case 2
                        TextBox8.Text = 9
                        Exit Sub
                End Select
            End If
        Next
        TextBox8.Text = "非數字"
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each i In tt
            i.BackColor = Color.White
        Next
        Dim ran As New Random
        Dim n = ran.Next(1, 8)
        Do Until n = 0
            Dim a = ran.Next(0, 7)
            If tt(a).BackColor = Color.White Then
                tt(a).BackColor = Color.Red
                n -= 1
            End If
        Loop
        chk()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        chk()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
    Private Sub TextBox1_click(sender As TextBox, e As EventArgs) Handles TextBox1.Click, TextBox2.Click, TextBox3.Click, TextBox4.Click, TextBox5.Click, TextBox6.Click, TextBox7.Click
        If sender.BackColor = Color.White Then
            sender.BackColor = Color.Red
        Else
            sender.BackColor = Color.White
        End If
    End Sub
End Class
