Public Class Form1
    Dim lb As New List(Of Label)
    Dim r As New Random
    Dim a, b As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 6
            lb.Add(addte(New Label))
        Next
        a = r.Next(0, 6)
        b = (a + 1) Mod (lb.Count)
        lb(a).Text = r.Next(1, 1000)
        lb(b).Text = r.Next(1, 1000)
        For Each i In lb
            FlowLayoutPanel1.Controls.Add(i)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        b = (b + 1) Mod (lb.Count)
        If lb(b).Text <> "" Then
            For i = 1 To lb.Count
                lb.Insert(b, addte(New Label))
                a = (a + 1) Mod (lb.Count)
            Next
            FlowLayoutPanel1.Controls.Clear()
            For Each i In lb
                FlowLayoutPanel1.Controls.Add(i)
            Next
        End If
        Dim num As Integer = r.Next(1, 1000)
        TextBox1.Text = String.Format("added {0}", num)
        lb(b).Text = num
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If lb(a).Text <> "" Then TextBox1.Text = String.Format("remove {0}", lb(a).Text) Else TextBox1.Text = "Queue is emprt"
        lb(a).Text = ""
        a = (a + 1) Mod (lb.Count)
        FlowLayoutPanel1.Controls.Clear()
        For Each i In lb
            FlowLayoutPanel1.Controls.Add(i)
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Function addte(t As Label)
        t.Size = New Size(50, 40)
        t.BackColor = Color.White
        t.BorderStyle = BorderStyle.FixedSingle
        t.Margin = New Padding(0, 0, 0, 0)
        t.TextAlign = ContentAlignment.MiddleCenter
        Return t
    End Function
End Class
