Module Module1
    Sub Main()
        Console.Write("請輸入徑向距離(r) = ")
        Dim r As Double = Val(Console.ReadLine), n As Integer = -1, m As New Integer
        Do Until n >= 0
            Console.Write("請輸入徑向多項式的次數(n) = ") : n = Val(Console.ReadLine)
            If n < 0 And n <> Int(n) Then Console.WriteLine("請輸入非負整數")
        Loop

        While m <= n
            If (n - Math.Abs(m)) Mod 2 = 0 AndAlso Math.Abs(m) <= n Then
                Console.WriteLine("計算徑向多項式(radial polynomials) ..., r = {0}, n = {1}, m = {2}", r, n, m)
                Console.WriteLine("所求之徑向多項式為 = {0}", anser(r, n, m))
            End If
            m += 1
        End While
        Console.WriteLine("計算完畢！")
        Console.Read()
    End Sub

    Function anser(ByVal r As Double, ByVal n As Integer, ByVal m As Integer)
        Dim sum As New Double
        For s = 0 To ((n - Math.Abs(m)) / 2)
            sum += (-1) ^ s * (_class(n - s) * r ^ (n - 2 * s) / (_class(s) * _class(((n + Math.Abs(m)) / 2) - s) * _class(((n - Math.Abs(m)) / 2) - s)))
        Next
        Return sum
    End Function

    Function _class(ByVal s As Integer)
        Dim total As Integer = 1
        For i = 2 To s
            total *= i
        Next
        Return total
    End Function
End Module
