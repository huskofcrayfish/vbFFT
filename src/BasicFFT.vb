
Partial Public Class _vbFFT
    Sub _Basic_TD_FFT(a As Double(), b As Double(), fftp As FFT_Parameters)

        Dim fftStep As Byte
        Dim i As Long
        Dim j As Long

        Dim inAButterflyCount As Long
        Dim butterflyOffset As Long
        Dim dataIndex0 As Long
        Dim dataIndex1 As Long
        Dim Element_A As Double
        Dim Element_B As Double
        Dim deltaPoint As Long
        Dim localCos As Double
        Dim localSin As Double

        'ReDim Preserve fftp.fcos(a.Length / 2 - 1)
        'ReDim Preserve fftp.fsin(a.Length / 2 - 1)

        'For n = 0 To a.Length / 4 - 1
        'fftp.fsin(a.Length / 4 + n) = fftp.fsin(a.Length / 4 - n)
        'fftp.fcos(a.Length / 4 + n) = -fftp.fcos(a.Length / 4 - n)
        'Next


        inAButterflyCount = a.Length >> 1

        butterflyOffset = 1

        For fftStep = 1 To fftp.exponent

            For j = 0 To butterflyOffset - 1

                dataIndex0 = j
                deltaPoint = j * inAButterflyCount
                localCos = fftp.fcos(deltaPoint)
                localSin = fftp.fsin(deltaPoint)

                For i = 0 To inAButterflyCount - 1

                    dataIndex1 = dataIndex0 + butterflyOffset

                    Element_A = a(dataIndex1) * localCos - b(dataIndex1) * localSin
                    Element_B = b(dataIndex1) * localCos + a(dataIndex1) * localSin

                    a(dataIndex1) = a(dataIndex0) - Element_A
                    b(dataIndex1) = b(dataIndex0) - Element_B

                    a(dataIndex0) = a(dataIndex0) + Element_A
                    b(dataIndex0) = b(dataIndex0) + Element_B

                    dataIndex0 += (butterflyOffset << 1)

                Next i
            Next j

            inAButterflyCount >>= 1
            butterflyOffset <<= 1

        Next fftStep

    End Sub


    Sub _Basic_FD_FFT(a As Double(), b As Double(), fftp As FFT_Parameters)

        Dim fftStep As Byte
        Dim i As Long
        Dim j As Long

        Dim inAButterflyCount As Long
        Dim butterflyOffset As Long
        Dim dataIndex0 As Long
        Dim dataIndex1 As Long
        Dim Element_A As Double
        Dim Element_B As Double
        Dim deltaPoint As Long
        Dim localCos As Double
        Dim localSin As Double

        'ReDim Preserve fftp.fcos(a.Length / 2 - 1)
        'ReDim Preserve fftp.fsin(a.Length / 2 - 1)

        'For n = 0 To a.Length / 4 - 1
        'fftp.fsin(a.Length / 4 + n) = fftp.fsin(a.Length / 4 - n)
        'fftp.fcos(a.Length / 4 + n) = -fftp.fcos(a.Length / 4 - n)
        'Next


        butterflyOffset = a.Length >> 1

        inAButterflyCount = 1

        For fftStep = 1 To fftp.exponent
            For j = 0 To butterflyOffset - 1

                dataIndex0 = j
                deltaPoint = j * inAButterflyCount
                localCos = fftp.fcos(deltaPoint)
                localSin = fftp.fsin(deltaPoint)

                For i = 0 To inAButterflyCount - 1

                    dataIndex1 = dataIndex0 + butterflyOffset

                    Element_A = a(dataIndex0) - a(dataIndex1)
                    Element_B = b(dataIndex0) - b(dataIndex1)

                    a(dataIndex0) = a(dataIndex0) + a(dataIndex1)
                    b(dataIndex0) = b(dataIndex0) + b(dataIndex1)

                    a(dataIndex1) = localCos * Element_A - localSin * Element_B
                    b(dataIndex1) = localCos * Element_B + localSin * Element_A

                    dataIndex0 += (butterflyOffset << 1)

                Next i
            Next j

            inAButterflyCount <<= 1
            butterflyOffset >>= 1

        Next fftStep
    End Sub

End Class
