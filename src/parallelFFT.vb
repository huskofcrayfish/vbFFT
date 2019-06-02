
Partial Public Class _vbFFT
    Sub _Parallel_TD_FFT(a As Double(), b As Double(), fftp As FFT_Parameters)

        Dim fftStep As Byte

        Dim sameAngleCount As Long
        Dim butterflyOffset As Long

        sameAngleCount = a.Length >> 1

        butterflyOffset = 1

        For fftStep = 1 To fftp.exponent
            Parallel.For(0, (butterflyOffset >> 1) + 1,
            Sub(j)

                Dim dataIndex0 As Long
                Dim dataIndex1 As Long
                Dim Element_A As Double
                Dim Element_B As Double
                Dim deltaPoint As Long
                Dim localCos As Double
                Dim localSin As Double

                Dim repeatFlag As Byte

                dataIndex0 = j

                deltaPoint = j * sameAngleCount
                localCos = fftp.fcos(deltaPoint)
                localSin = fftp.fsin(deltaPoint)

                If j <> 0 AndAlso j <> butterflyOffset >> 1 Then
                    repeatFlag = 1
                Else
                    repeatFlag = 0
                End If

                For k = 0 To repeatFlag

                    For i = 0 To sameAngleCount - 1

                        dataIndex1 = dataIndex0 + butterflyOffset

                        Element_A = a(dataIndex1) * localCos - b(dataIndex1) * localSin
                        Element_B = b(dataIndex1) * localCos + a(dataIndex1) * localSin

                        a(dataIndex1) = a(dataIndex0) - Element_A
                        b(dataIndex1) = b(dataIndex0) - Element_B

                        a(dataIndex0) = a(dataIndex0) + Element_A
                        b(dataIndex0) = b(dataIndex0) + Element_B

                        dataIndex0 += (butterflyOffset << 1)
                    Next i

                    dataIndex0 = butterflyOffset - j
                    localCos *= (-1)
                Next k
            End Sub)

            sameAngleCount >>= 1
            butterflyOffset <<= 1
        Next fftStep
    End Sub


    Sub _Parallel_FD_FFT(a As Double(), b As Double(), fftp As FFT_Parameters)

        Dim fftStep As Byte

        Dim sameAngleCount As Long
        Dim butterflyOffset As Long

        butterflyOffset = a.Length >> 1

        sameAngleCount = 1

        For fftStep = 1 To fftp.exponent
            Parallel.For(0, (butterflyOffset >> 1) + 1,
            Sub(j)

                Dim dataIndex0 As Long
                Dim dataIndex1 As Long
                Dim Element_A As Double
                Dim Element_B As Double
                Dim deltaPoint As Long
                Dim localCos As Double
                Dim localSin As Double

                Dim repeatFlag As Byte

                dataIndex0 = j
                deltaPoint = j * sameAngleCount
                localCos = fftp.fcos(deltaPoint)
                localSin = fftp.fsin(deltaPoint)

                If j <> 0 AndAlso j <> butterflyOffset >> 1 Then
                    repeatFlag = 1
                Else
                    repeatFlag = 0
                End If

                For k = 0 To repeatFlag
                    For i = 0 To sameAngleCount - 1

                        dataIndex1 = dataIndex0 + butterflyOffset

                        Element_A = a(dataIndex0) - a(dataIndex1)
                        Element_B = b(dataIndex0) - b(dataIndex1)

                        a(dataIndex0) = a(dataIndex0) + a(dataIndex1)
                        b(dataIndex0) = b(dataIndex0) + b(dataIndex1)

                        a(dataIndex1) = localCos * Element_A - localSin * Element_B
                        b(dataIndex1) = localCos * Element_B + localSin * Element_A

                        dataIndex0 += (butterflyOffset << 1)
                    Next i

                    dataIndex0 = butterflyOffset - j
                    localCos *= (-1)
                Next k
            End Sub)
            sameAngleCount <<= 1
            butterflyOffset >>= 1

        Next fftStep
    End Sub

End Class
