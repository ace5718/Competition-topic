Public Class Form1
    Dim num As New List(Of Integer())
    Sub Open_file(sender As Object, e As EventArgs) Handles 選取資料ToolStripMenuItem.Click
        Dim str() As String
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            str = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName).Replace(vbCrLf, "!").Split("!")
            For i = 0 To str.Count - 1
                num.Add(str(i).Split().Select(Function(x) CInt(x)).ToArray)
            Next
            For i = 0 To str.Length - 1
                TextBox1.Text &= String.Format("麵 [{0}] {1}", i + 1, Join(str(i).ToString.Split(), "    ")) & vbCrLf
            Next
        End If

    End Sub
    Sub statistics(sender As Object, e As EventArgs) Handles 求F統計值和自由度dfToolStripMenuItem.Click
        TextBox2.Text = "F統計值計算：" & vbCrLf & "F =" & F() & vbCrLf & String.Format("自由度df：{0},{1}", dfb, dfw)
    End Sub
    Sub End_button(sender As Object, e As EventArgs) Handles 結束ToolStripMenuItem.Click
        End
    End Sub
    Function F() As Decimal
        Return Format(MSb() / MSw(), "00.000")
    End Function
    Function MSb() As Decimal
        Return SSb() / dfb()
    End Function
    Function MSw() As Decimal
        Return SSw() / dfw()
    End Function
    Function SSb() As Decimal
        Dim ans As Decimal
        For i = 0 To num.Count - 1
            ans += num(i).Count * (uti(i) - UT()) ^ 2
        Next
        Return ans
    End Function
    Function SSw() As Decimal
        Dim ans As Decimal
        For i = 0 To num.Count - 1
            For j = 0 To num(i).Count - 1
                ans += (num(i)(j) - uti(i)) ^ 2
            Next
        Next
        Return ans
    End Function
    Function dfb()
        Return num.Count - 1
    End Function
    Function dfw()
        Dim totol As New Integer
        For Each i In num
            For Each j In i
                totol += 1
            Next
        Next
        Return totol - num.Count
    End Function
    Function uti(i As Integer) As Decimal
        Return num(i).Sum / num(i).Count
    End Function
    Function UT() As Decimal
        Dim totol As New Decimal
        Dim n As New Integer
        For Each i In num
            For Each j In i
                totol += j
                n += 1
            Next
        Next
        Return totol / n
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class
