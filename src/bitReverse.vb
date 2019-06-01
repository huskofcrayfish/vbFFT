
Partial Public Class _vbFFT

    Private Sub Swap(ByRef a As Double, ByRef b As Double)

        Dim temp As Double
        temp = a
        a = b
        b = temp

    End Sub


    Sub _bitReverse(a As Double(), b As Double())

        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim N_half As Integer
        Dim N_half1 As Integer

        N_half = a.Length >> 1
        N_half1 = N_half + 1
        i = 0

        For j = 0 To N_half - 1 Step 2
            If (j < i) Then

                Swap(a(i), a(j))
                Swap(b(i), b(j))

                Swap(a(i + N_half1), a(j + N_half1))
                Swap(b(i + N_half1), b(j + N_half1))

            End If

            Swap(a(j + N_half), a(i + 1))
            Swap(b(j + N_half), b(i + 1))

            k = N_half >> 1
            i = i Xor k
            Do While (k > i)
                k >>= 1
                i = i Xor k
            Loop

        Next
    End Sub

    Sub _Parallel_bitReverse(a As Double(), b As Double())

        Dim k As Integer
        Dim m As Integer

        Dim ip() As Integer
        Dim tmpd As Double = Math.Sqrt(a.Length)

        If (tmpd = (Math.Truncate(tmpd))) Then
            ReDim ip(tmpd)
        Else
            ReDim ip(Math.Sqrt(a.Length >> 1))
        End If


        ip(0) = 0
        k = a.Length
        m = 1

        Do While ((2 * m) < k)
            k >>= 1
            For j = 0 To m - 1
                ip(m + j) = ip(j) + k
            Next j
            m <<= 1
        Loop


        If (m = k) Then

            Parallel.For(1, m,
             Sub(i)

                 Dim ij As Integer
                 Dim ji As Integer

                 For j = 0 To i - 1

                     ji = j + ip(i)
                     ij = i + ip(j)

                     Swap(a(ji), a(ij))
                     Swap(b(ji), b(ij))
                 Next j
             End Sub)
        Else

            Parallel.For(1, m,
            Sub(i)

                Dim ij As Integer
                Dim ji As Integer

                For j = 0 To i - 1

                    ji = j + ip(i)
                    ij = i + ip(j)

                    Swap(a(ji), a(ij))
                    Swap(b(ji), b(ij))

                    Swap(a(ji + m), a(ij + m))
                    Swap(b(ji + m), b(ij + m))
                Next j
            End Sub)
        End If
    End Sub

End Class
