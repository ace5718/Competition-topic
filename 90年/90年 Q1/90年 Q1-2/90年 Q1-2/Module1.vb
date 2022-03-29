Module Module1
    Sub Main()
        Dim n, m As String
        Console.Write("請輸入""m"" = ")
        m = Console.ReadLine
        Console.Write("請輸入""n"" = ")
        n = Console.ReadLine
        Console.WriteLine()
        Console.Write("1 / " & cal3(Cal1(m), Cal1(m - n)))
        Console.Read()
    End Sub
    Function Cal1(n As String) As String
        Dim s As String = 1
        For i = 1 To Val(n)
            Dim n1 = s.Reverse.Select(Function(x) Val(x)).ToArray
            Dim ni = i.ToString.Reverse.Select(Function(x) Val(x)).ToArray
            Dim nt(n1.Count + ni.Count) As Integer
            For j = 0 To n1.Count - 1
                For k = 0 To ni.Count - 1
                    nt(j + k) += n1(j) * ni(k)
                    If nt(j + k) > 9 Then
                        nt(j + k + 1) += nt(j + k) \ 10
                        nt(j + k) = nt(j + k) Mod 10
                    End If
                Next
            Next
            s = ""
            For j = nt.Count - 1 To 0 Step -1
                If nt(j) <> 0 Then
                    For k = j To 0 Step -1
                        s &= nt(k)
                    Next
                    Exit For
                End If
            Next
        Next
        Return s
    End Function '階層計算
    Function cal3(n As String, m As String)
        Dim s As String
        Dim n1 As String = ""
        Dim m1 As String = ""
        For Each i In n
            m1 &= i
            If m1.Count >= m.Count Then
                Dim s1 As New Integer
                While chk(m1, m)
                    m1 = cal4(m1, m)
                    s1 += 1
                End While
                n1 &= s1
            End If
        Next
        If chk(n, m) = False Then
            Return n1
        Else
            If Mid(n1, 1, 1) = 0 Then
                For i = 1 To n1.Count
                    If Mid(n1, i, 1) <> 0 Then
                        s = ""
                        For j = i To n1.Count
                            s &= Mid(n1, j, 1)
                        Next
                        Exit For
                    Else
                        s = 0
                    End If
                Next
                Return s
            Else
                Return n1
            End If
        End If
    End Function '大數除法
    Function cal4(n As String, m As String)
        Dim s As String
        Dim n1() As Integer = n.PadLeft(m.Count, "0").Reverse.Select(Function(x) CInt(x.ToString)).ToArray
        Dim m1() As Integer = m.PadLeft(n.Count, "0").Reverse.Select(Function(x) CInt(x.ToString)).ToArray
        Dim nm(n1.Count) As Integer
        For i = 0 To n1.Count - 1
            nm(i) += If(chk(n, m), n1(i) - m1(i), m1(i) - n1(i))
            If nm(i) < 0 And n1.Count - 1 Then
                nm(i + 1) -= 1
                nm(i) += 10
            End If
        Next
        For i = nm.Count - 1 To 0 Step -1
            If nm(i) <> 0 Then
                s = ""
                For j = i To 0 Step -1
                    s &= nm(j)
                Next
                Exit For
            Else
                s = 0
            End If
        Next
        Return If(chk(n, m), s, "-" & s)
    End Function '大數減法
    Function chk(n As String, m As String)
        Select Case n.Count
            Case > m.Count
                Return True
            Case = m.Count
                For i = 1 To n.Count
                    If Mid(n, i, 1) < Mid(m, i, 1) Then
                        Return False
                    ElseIf Mid(n, i, 1) > Mid(m, i, 1) Then
                        Return True
                    End If
                Next
                Return True
            Case Else
                Return False
        End Select
    End Function '比較
End Module
