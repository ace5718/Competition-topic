Imports System.Text.RegularExpressions
Public Class Form1
    Class data
        Public level, str As String
        Public IP As Integer()
        Public Sub New(a$, b As Integer(), c$)
            level = a : IP = b : str = c
        End Sub
    End Class
    Dim d As New List(Of data)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each i In My.Computer.FileSystem.ReadAllText("IP_Message.txt", System.Text.Encoding.GetEncoding(950)).Replace(vbCrLf, "@").Split("@")
            d.Add(New data(i.Split(",")(0), get_level(i.Split(",")(0), i.Split(",")(1)), i.Split(",")(2)))
        Next
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 24
    End Sub

    Function get_level(t As String, tt As String)
        Dim c As Integer() = Regex.Split(tt, "\D").Select(Function(x) If(IsNumeric(x), CInt(x), Nothing)).ToArray
        Dim str As String = ""
        Select Case Regex.Replace(t, "\P{Lu}", "")
            Case "A" : str = "0"
            Case "B" : str = "10"
            Case "C" : str = "110"
        End Select
        c(1) = Convert.ToInt64(str & Convert.ToString(c(1), 2).PadLeft(8, "0").Remove(0, str.Count), 2)
        Return c
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        Dim net As Integer() = ComboBox1.Text.Split(".").Select(Function(x) CInt(x)).ToArray
        Dim mask As Integer() = New String("1", ComboBox2.Text).PadRight(32, "0").Insert(8, ".").Insert(17, ".").Insert(26, ".").Split(".").Select(Function(x) CInt(Convert.ToInt64(x, 2))).ToArray
        For i = 1 To 3
            net(i) = net(i) And mask(i)
        Next
        ListBox1.Items.Add("Net：" & Join(net.Select(Function(x) CStr(x)).ToArray, "."))
        ListBox1.Items.Add("Mask：" & Join(mask.Select(Function(x) CStr(x)).ToArray, "."))
        For Each i In d
            Dim chk As Boolean = True
            For j = 1 To 4
                If (i.IP(j) And mask(j - 1)) <> net(j - 1) Then chk = False
            Next
            If chk Then ListBox1.Items.Add(String.Format("IP：{0},Message：{1}", Join(i.IP.Select(Function(x) CStr(x)).ToArray, "."), i.str))
        Next
    End Sub
End Class
