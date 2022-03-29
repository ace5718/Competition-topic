Public Class Form1
    Dim s As New Integer
    Dim tf As New List(Of Boolean)
    Dim g1, g2, g3, g4, g5, g6 As Graphics
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        s = 1
        cheek(s) : draw()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If s < 6 Then s += 1 Else s = 1
        cheek(s) : draw()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        s = 0
        draw()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        g1 = PictureBox1.CreateGraphics
        g2 = PictureBox2.CreateGraphics
        g3 = PictureBox3.CreateGraphics
        g4 = PictureBox4.CreateGraphics
        g5 = PictureBox5.CreateGraphics
        g6 = PictureBox6.CreateGraphics
    End Sub
    Sub draw()
        For i = 1 To 6
            Controls("PictureBox" & i).Refresh()
        Next
        If s = 0 Then Exit Sub
        If tf(0) = True Then g1.FillEllipse(Brushes.Red, 0, 0, 100, 100)
        If tf(1) = True Then g2.FillEllipse(Brushes.Yellow, 0, 0, 100, 100)
        If tf(2) = True Then g3.FillEllipse(Brushes.Green, 0, 0, 100, 100)
        If tf(3) = True Then g4.FillEllipse(Brushes.Red, 0, 0, 100, 100)
        If tf(4) = True Then g5.FillEllipse(Brushes.Yellow, 0, 0, 100, 100)
        If tf(5) = True Then g6.FillEllipse(Brushes.Green, 0, 0, 100, 100)
    End Sub
    Function cheek(s As Integer)
        tf.Clear()
        Dim RAG As String() = {"1,0,0,0,0,1", "1,0,0,0,1,0", "1,0,0,1,0,0", "0,0,1,1,0,0", "0,1,0,1,0,0", "1,0,0,1,0,0"}
        For Each i In RAG(s - 1).Split(",")
            If i = 1 Then tf.Add(True) Else tf.Add(False)
        Next
        Return tf
    End Function
End Class
