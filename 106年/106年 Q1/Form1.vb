Public Class Form1
    Class node
        Public math As Integer?
        Public english As Integer?
        Public k As Integer?
        Public Sub New(math As Integer?, engilsh As Integer?)
            Me.math = math
            Me.english = engilsh
            k = Nothing
        End Sub
    End Class
    Dim sc As New List(Of node)
    Dim r As New Random
    Dim ans As New List(Of Decimal)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Series(0).IsVisibleInLegend = False
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line

        For i = 1 To Val(TextBox1.Text)
            sc.Add(New node(TextBox3.Text.Split(" ")(i - 1), TextBox4.Text.Split(" ")(i - 1)))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sc.Clear()
        For i As Integer = 1 To TextBox2.Text
            sc.Add(New node(r.Next(1, 101), r.Next(1, 101)))
        Next
        TextBox3.Text = Join(sc.Select(Function(x) CStr(x.math)).ToArray, " ")
        TextBox4.Text = Join(sc.Select(Function(x) CStr(x.english)).ToArray, " ")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        randk()
        ans.Clear()
        Dim u1 As node = u(1), u2 As node = u(2)

        For p As Integer = 1 To TextBox2.Text
            For Each i In sc
                i.k = IIf(d(u1, i) > d(u2, i), 1, 2)
            Next
            u1 = u(1) : u2 = u(2)
            ans.Add(MSE(u1, u2))
        Next
        TextBox5.Text = Join(sc.Select(Function(x) CStr(x.k)).ToArray, "  ")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Chart1.Series(0).Points.Clear()
        For Each i In ans
            Chart1.Series(0).Points.Add(i)
        Next
    End Sub
    Sub randk()
        For Each i In sc
            If r.Next(0, 2) = 0 Then i.k = 1 Else i.k = 2
        Next
    End Sub
    Function u(n As Integer) As node
        Dim t As List(Of node) = (From x In sc Where x.k = n Select x).ToList
        Return New node((From x In t Select x.math).Sum / t.Count, (From x In t Select x.english).Sum / t.Count)
    End Function
    Function d(u As node, i As node) As Decimal
        Return Math.Sqrt((i.math - u.math) ^ 2 + (i.english - u.english) ^ 2)
    End Function
    Function MSE(u1 As node, u2 As node) As Decimal
        Dim total As New Decimal
        For Each i In sc
            Select Case i.k
                Case 1 : total += (i.math - u1.math) ^ 2 + (i.english - u1.english) ^ 2
                Case 2 : total += (i.math - u2.math) ^ 2 + (i.english - u2.english) ^ 2
            End Select
        Next
        Return total / sc.Count
    End Function
End Class
