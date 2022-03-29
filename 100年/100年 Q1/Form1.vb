Public Class Form1
    Dim pe() As Pen = {Pens.Black, Pens.Red, Pens.Green, Pens.Blue}
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, NumericUpDown1.ValueChanged
        Dim g As Graphics = PictureBox1.CreateGraphics
        Dim point As New HashSet(Of Point)
        g.Clear(Form.DefaultBackColor)
        Dim n As Integer = NumericUpDown1.Value
        Dim c = IIf(ComboBox1.SelectedIndex = -1, 0, ComboBox1.SelectedIndex)
        For i = 0 To n - 1
            Dim a As Point = New Point(125 * Math.Cos(360 / n * i * Math.PI / 180) + 125, 125 * Math.Sin(360 / n * i * Math.PI / 180) + 125)
            Dim b As Point = New Point(125 * Math.Cos(360 / n * (i + 1) * Math.PI / 180) + 125, 125 * Math.Sin(360 / n * (i + 1) * Math.PI / 180) + 125)
            point.Add(a) : point.Add(b)
            g.DrawLine(pe(c), a, b)
        Next
        For Each i In point
            For Each j In point
                If j <> i Then g.DrawLine(pe(c), i, j)
            Next
        Next
        ' Stop
    End Sub
End Class
