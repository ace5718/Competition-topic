Module Module1
    Class Disk
        Public name As String
        Public cost As Integer
        Public Sub New(a As String, b As Integer)
            name = a : cost = b
        End Sub
    End Class

    Class Transfer
        Public name As String
        Public input As New List(Of Disk)
        Public out As Disk
        Public Sub New(a As String)
            name = a
        End Sub
    End Class

    Dim temp As New List(Of Disk)
    Sub Main()
        Dim data As New List(Of String)

        Console.WriteLine("鍵入「輸入小圓盤」的數目及其名稱：")
        For Each i In Console.ReadLine.Split(" ").Skip(1) : temp.Add(New Disk(i, 0)) : Next

        Console.WriteLine("鍵入「內部小圓盤」的數目及其名稱：")
        For Each i In Console.ReadLine.Split(" ").Skip(1) : temp.Add(New Disk(i, 0)) : Next

        Console.WriteLine("鍵入「輸出小圓盤」的數目及其名稱：")
        For Each i In Console.ReadLine.Split(" ").Skip(1) : temp.Add(New Disk(i, 0)) : Next

        Console.WriteLine("鍵入「2-1轉移棒」的名稱及小圓盤的名稱：")
        Do
            data.Add(Console.ReadLine)
            Console.Write("Continue(1/0)：")
        Loop Until Console.ReadLine() = 0

        Console.WriteLine("鍵入「1-1」的名稱及其小圓盤的名稱：")
        Do
            data.Add(Console.ReadLine)
            Console.Write("Continue(1/0)：")
        Loop Until Console.ReadLine() = 0
        Get_Data(data)

        Console.WriteLine("轉移棒與小圓盤的關係：" & Print_ans1())
        Console.WriteLine("小圓盤與轉移棒的關係：" & Print_ans2())
        Do
            Console.Write("鍵入將放權杖的小圓盤名稱：")
            Insert_Weights(Console.ReadLine)
            Console.WriteLine("查看各個小圓盤權杖的情況：" & Print_Weights())
            Console.WriteLine("執行轉移棒.") : Run_Transfer()
            Console.WriteLine("查看各個小圓盤權杖的情況：" & Print_Weights())
            Console.Write("Continue(1/0)：")
        Loop Until Console.ReadLine = 0
        Console.Read()
    End Sub

    Dim sc As New List(Of Transfer)
    Sub Get_Data(data As List(Of String))
        For Each i In data
            Dim t As String() = i.Split(" ")
            sc.Add(New Transfer(t(0)))
            For j = 1 To t.Count - 2 : sc(sc.Count - 1).input.Add(Seach_node(t(j))) : Next
            sc(sc.Count - 1).out = Seach_node(t(t.Count - 1))
        Next
    End Sub

    Function Seach_node(name As String)
        For Each i In temp
            If i.name = name Then Return i
        Next
        Return Nothing
    End Function

    Function Print_ans1()
        Dim str As String = ""
        For Each i In sc
            str &= i.name & "："
            For Each j In i.input : str &= j.name & " " : Next
            str &= i.out.name & " "
        Next
        Return str
    End Function

    Function Print_ans2()
        Dim str As String = ""
        For Each i In temp
            str &= i.name & "："
            For Each j In sc
                For Each k In j.input
                    If k.name = i.name Then str &= j.name & " "
                Next
                If j.out.name = i.name Then str &= j.name & " "
            Next
        Next
        Return str
    End Function

    Sub Insert_Weights(name As String)
        For Each i In temp
            If i.name = name Then i.cost += 1
        Next
    End Sub

    Function Print_Weights()
        Dim str As String = ""
        For Each i In temp : str &= i.name & "：" & i.cost & " " : Next
        Return str
    End Function

    Sub Run_Transfer()
        Do
            For Each i In sc
                Dim tf As Boolean = False
                For Each j In i.input
                    If j.cost = 0 Then tf = True : Exit For
                Next

                If tf Then
                    Continue For
                Else
                    For Each j In i.input : j.cost = 0 : Next
                    i.out.cost = 1
                    Continue Do
                End If
            Next
            Exit Do
        Loop
    End Sub
End Module
