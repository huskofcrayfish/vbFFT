

Public Class FFT_Parameters

    Public inv As SByte
    Public exponent As SByte
    Public fcos() As Double
    Public fsin() As Double

End Class

Public Class vbFFT

    Public _vbFFT As New _vbFFT

    Sub TD_FFT(data0 As Double(), data1 As Double())

        Dim FFTP As New FFT_Parameters With
        {
            .inv = 1,
            .exponent = Math.Log(data0.Length) / Math.Log(2)
        }

        _vbFFT._Set_FFT(data0, data1, FFTP)
        _vbFFT._Cal_TD_FFT(data0, data1, FFTP)

    End Sub


    Sub TD_IFFT(data0 As Double(), data1 As Double())

        Dim FFTP As New FFT_Parameters With
        {
            .inv = -1,
            .exponent = Math.Log(data0.Length) / Math.Log(2)
        }

        _vbFFT._Set_FFT(data0, data1, FFTP)
        _vbFFT._Cal_TD_FFT(data0, data1, FFTP)

        For k As Integer = 0 To data0.Length - 1
            data0(k) /= data0.Length
            data1(k) /= data0.Length
        Next k

    End Sub


    Sub FD_FFT(data0 As Double(), data1 As Double())

        Dim FFTP As New FFT_Parameters With
        {
            .inv = 1,
            .exponent = Math.Log(data0.Length) / Math.Log(2)
        }

        _vbFFT._Set_FFT(data0, data1, FFTP)
        _vbFFT._Cal_FD_FFT(data0, data1, FFTP)

    End Sub


    Sub FD_IFFT(data0 As Double(), data1 As Double())

        Dim FFTP As New FFT_Parameters With
        {
            .inv = -1,
            .exponent = Math.Log(data0.Length) / Math.Log(2)
        }

        _vbFFT._Set_FFT(data0, data1, FFTP)
        _vbFFT._Cal_FD_FFT(data0, data1, FFTP)

        For k As Integer = 0 To data0.Length - 1
            data0(k) /= data0.Length
            data1(k) /= data0.Length
        Next k

    End Sub


    Sub Parallel_TD_FFT(data0 As Double(), data1 As Double())

        Dim FFTP As New FFT_Parameters With
        {
            .inv = 1,
            .exponent = Math.Log(data0.Length) / Math.Log(2)
        }

        _vbFFT._Set_FFT(data0, data1, FFTP)
        _vbFFT._Cal_Parallel_TD_FFT(data0, data1, FFTP)

    End Sub


    Sub Parallel_TD_IFFT(data0 As Double(), data1 As Double())

        Dim FFTP As New FFT_Parameters With
        {
            .inv = -1,
            .exponent = Math.Log(data0.Length) / Math.Log(2)
        }

        _vbFFT._Set_FFT(data0, data1, FFTP)
        _vbFFT._Cal_TD_FFT(data0, data1, FFTP)

        For k As Integer = 0 To data0.Length - 1
            data0(k) /= data0.Length
            data1(k) /= data0.Length
        Next k

    End Sub


    Sub Parallel_FD_FFT(data0 As Double(), data1 As Double())

        Dim FFTP As New FFT_Parameters With
        {
            .inv = 1,
            .exponent = Math.Log(data0.Length) / Math.Log(2)
        }

        _vbFFT._Set_FFT(data0, data1, FFTP)
        _vbFFT._Cal_FD_FFT(data0, data1, FFTP)

    End Sub


    Sub Parallel_FD_IFFT(data0 As Double(), data1 As Double())

        Dim FFTP As New FFT_Parameters With
        {
            .inv = -1,
            .exponent = Math.Log(data0.Length) / Math.Log(2)
        }

        _vbFFT._Set_FFT(data0, data1, FFTP)
        _vbFFT._Cal_FD_FFT(data0, data1, FFTP)

        For k As Integer = 0 To data0.Length - 1
            data0(k) /= data0.Length
            data1(k) /= data0.Length
        Next k

    End Sub

End Class
