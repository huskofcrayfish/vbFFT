
Module Module1

    Private vbFFT As New vbFFT

    Sub Main()

        Dim k As Integer

        Dim wdata0() As Double
        Dim wdata1() As Double
        Dim Exponent As Byte = 16

        ReDim wdata0((2 ^ Exponent) - 1)

        For i As Integer = 0 To wdata0.Length - 1 Step 8
            wdata0(i) = 1
            wdata0(i + 1) = 1
            wdata0(i + 2) = 1
            wdata0(i + 3) = 1
        Next i

        ReDim wdata1((2 ^ Exponent) - 1)


        vbFFT.TD_FFT(wdata0, wdata1)
        For k = 0 To wdata0.Length - 1
            Console.WriteLine(wdata0(k) & "," & wdata1(k))
        Next k

        vbFFT.TD_IFFT(wdata0, wdata1)
        For k = 0 To wdata0.Length - 1
            Console.WriteLine(wdata0(k) & "," & wdata1(k))
            'Console.WriteLine(CType(wdata0(k), Integer) & "," & CType(wdata1(k), Integer))
        Next k

        vbFFT.FD_FFT(wdata0, wdata1)
        For k = 0 To wdata0.Length - 1
            Console.WriteLine(wdata0(k) & "," & wdata1(k))
        Next k

        vbFFT.FD_IFFT(wdata0, wdata1)
        For k = 0 To wdata0.Length - 1
            Console.WriteLine(wdata0(k) & "," & wdata1(k))
            'Console.WriteLine(CType(wdata0(k), Integer) & "," & CType(wdata1(k), Integer))
        Next k


    End Sub

End Module
