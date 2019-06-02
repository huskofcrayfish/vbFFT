
Partial Public Class _vbFFT

    Private Const PI = 3.14159265358979


    Sub _Cal_TD_FFT(data0 As Double(), data1 As Double(), fftp As FFT_Parameters)

        _Basic_bitReverse(data0, data1)
        _Basic_TD_FFT(data0, data1, fftp)

    End Sub


    Sub _Cal_FD_FFT(data0 As Double(), data1 As Double(), fftp As FFT_Parameters)

        _Basic_FD_FFT(data0, data1, fftp)
        _Basic_bitReverse(data0, data1)

    End Sub


    Sub _Set_FFT(data0 As Double(), data1 As Double(), fftp As FFT_Parameters)

        Dim tmpi As Integer
        Dim PI2 As Double = -fftp.inv * PI

        tmpi = (2 ^ fftp.exponent) >> 1

        ReDim fftp.fcos(tmpi)
        ReDim fftp.fsin(tmpi)

        For n = 0 To tmpi
            fftp.fsin(n) = Math.Sin(PI2 * (n / tmpi))
            fftp.fcos(n) = Math.Cos(PI2 * (n / tmpi))
        Next

        ReDim data0((2 ^ fftp.exponent) - 1)
        ReDim data1((2 ^ fftp.exponent) - 1)

    End Sub

End Class