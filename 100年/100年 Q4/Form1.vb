Public Class Form1
    Dim col(255) As Integer
    Private Sub 開啟彩色影像檔案OpenColorimageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 開啟彩色影像檔案OpenColorimageToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
            PictureBox2.Image = Nothing
            For i = 1 To 4
                Controls("TextBox" & i).Text = ""
            Next
        End If
    End Sub

    Private Sub 結束離開ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 結束離開ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub 彩色影像轉灰階影像ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 彩色影像轉灰階影像ToolStripMenuItem.Click
        Dim bit As Bitmap = PictureBox1.Image
        For y = 0 To bit.Height - 1
            For x = 0 To bit.Width - 1
                Dim a = bit.GetPixel(x, y)
                Dim co = a.R * 0.3 + a.G * 0.59 + a.B * 0.11
                col(co) += 1
                bit.SetPixel(x, y, Color.FromArgb(co, co, co))
            Next
        Next
        PictureBox2.Image = bit
    End Sub

    Private Sub 求最小灰階和最大灰階ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 求最小灰階和最大灰階ToolStripMenuItem.Click
        TextBox1.Text = col.Min
        TextBox2.Text = col.Max
    End Sub

    Private Sub 求出現最大之灰階和此機率ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 求出現最大之灰階和此機率ToolStripMenuItem.Click
        TextBox3.Text = Array.IndexOf(col, col.Max)
        TextBox4.Text = col.Max / col.Sum
    End Sub

    Private Sub 劃出灰階影像直方圖ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 劃出灰階影像直方圖ToolStripMenuItem.Click
        Chart1.Series.Clear()
        Chart1.Series.Add("point")
        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
        For Each i In col
            Chart1.Series("point").Points.Add(i)
        Next
    End Sub
End Class
