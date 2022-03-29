Public Class Form1
    Class node
        Public top, center, down As Integer
        Public data As Integer
        Public Sub New(a%, b%, c%, d%)
            top = a : center = b : down = c : data = d
        End Sub
    End Class

    Dim sc As New List(Of node)
    Dim q As New ArrayList

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a$() = TextBox1.Text.Split(" "), b$() = TextBox2.Text.Split(" "), c$() = TextBox3.Text.Split(" "), d$() = My.Computer.FileSystem.ReadAllText(TextBox4.Text).Split(" ")
        For i = 0 To a.Count - 1
            sc.Add(New node(a(i), b(i), c(i), d(i)))
        Next
        TextBox5.Text = Join(d, " ")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ar As New List(Of Decimal)
        q.Clear()
        For i = 0 To sc.Count - 1
            Dim n1 = 1 / (sc(i).top - sc(i).center), n2 = 1 / (sc(i).center - sc(i).down)
            Select Case sc(i).data
                Case Is >= sc(i).top
                    ar.Add(0)
                Case Is = sc(i).center
                    ar.Add(1)
                Case Is <= sc(i).down
                    ar.Add(0)
                Case Is > sc(i).center
                    ar.Add((sc(i).top - sc(i).data) * n1)
                Case Is < sc(i).center
                    ar.Add((sc(i).data - sc(i).down) * n2)
            End Select
        Next
        q.AddRange(ar)
        Label3.Text = "平均相似度為：" & Format(ar.Sum / ar.Count, "0.000000")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.AddRange(q.ToArray)
    End Sub
End Class
