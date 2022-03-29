Public Class Form1
    Dim num As Integer
    Dim test(), max(), ending(), min() As String
    Dim PDM, MDM, PDMS, MDMS, TR, TRS, PDI, MDI, ADX, DX As Decimal()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        data()
        get_PDM_MDM()
        get_PDMS_MDMS()
        get_TR()
        ger_PDI_MDI()
        get_DX()
        get_ADX()
        get_ans()
    End Sub
    Sub data()
        test = My.Computer.FileSystem.ReadAllText("data1.txt").Replace(vbCrLf, "!").Split("!")
        max = test(0).Split(" ")
        ending = test(1).Split(" ")
        min = test(2).Split(" ")
        num = max.Count - 1
        For i = 1 To 3
            Controls("TextBox" & i).Text = test(i - 1)
        Next
    End Sub
    Sub get_PDM_MDM()
        ReDim PDM(num), MDM(num)
        For i = 1 To num
            PDM(i) = max(i) - max(i - 1)
            MDM(i) = min(i - 1) - min(i)
            If PDM(i) < 0 Then PDM(i) = 0
            If MDM(i) < 0 Then MDM(i) = 0
            Select Case PDM(i)
                Case > MDM(i)
                    MDM(i) = 0
                Case < MDM(i)
                    PDM(i) = 0
                Case Else
                    PDM(i) = 0 : MDM(i) = 0
            End Select
        Next
    End Sub
    Sub get_PDMS_MDMS()
        ReDim PDMS(num), MDMS(num)
        For i = 9 To num
            Dim a, b As New Decimal
            For j = i - 9 To i
                a += PDM(j)
                b += MDM(j)
            Next
            PDMS(i) = a / 10
            MDMS(i) = b / 10
        Next
    End Sub
    Sub get_TR()
        Dim a, b, c As Decimal
        ReDim TR(num)
        For i = 1 To num
            a = Math.Abs(max(i) - min(i))
            b = Math.Abs(max(i) - ending(i - 1))
            c = Math.Abs(min(i) - ending(i - 1))
            TR(i) = Math.Max(Math.Max(a, b), c)
        Next
        get_TRS()
    End Sub
    Sub get_TRS()
        ReDim TRS(num)
        For i = 9 To num
            Dim a As New Decimal
            For j = i - 9 To i
                a += TR(j)
            Next
            TRS(i) = a / 10
        Next
    End Sub
    Sub ger_PDI_MDI()
        ReDim PDI(num)
        ReDim MDI(num)
        For i = 0 To num
            Try
                PDI(i) = PDMS(i) / TRS(i)
                MDI(i) = MDMS(i) / TRS(i)
            Catch ex As Exception
            End Try
        Next
    End Sub
    Sub get_DX()
        ReDim DX(num)
        For i = 1 To num
            Try
                DX(i) = 100 * (Math.Abs(PDI(i) - MDI(i))) / (PDI(i) + MDI(i))
            Catch ex As Exception
            End Try
        Next
    End Sub
    Sub get_ADX()
        ReDim ADX(num)
        For i = 9 To num
            Dim a As New Decimal
            For j = i - 9 To i
                a += DX(j)
            Next
            ADX(i) = a / 10
        Next
    End Sub
    Sub get_ans()
        Dim ans, ans2 As New ArrayList
        For i = 20 To num
            ans.Add(Format(ADX(i), "00.00"))
            Select Case ADX(i)
                Case >= ADX(i - 1)
                    ans2.Add(1)
                Case Else
                    ans2.Add(0)
            End Select
        Next
        TextBox4.Text = Join(ans.ToArray, vbTab)
        TextBox5.Text = Join(ans2.ToArray, vbTab)
    End Sub
End Class
