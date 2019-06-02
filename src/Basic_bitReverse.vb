
Partial Public Class _vbFFT

    Private Sub Swap(ByRef a As Double, ByRef b As Double)

        Dim temp As Double
        temp = a
        a = b
        b = temp

    End Sub


    Sub _Basic_bitReverse(a As Double(), b As Double())

        Dim i As Integer
        Dim j As Integer
        Dim k As Integer

        i = 0
        For j = 1 To a.Length - 1 - 1

            k = a.Length >> 1
            i = i Xor k
            Do While (k > i)
                k >>= 1
                i = i Xor k
            Loop

            If (j < i) Then
                Swap(a(i), a(j))
                Swap(b(i), b(j))

            End If
        Next


    End Sub


End Class
