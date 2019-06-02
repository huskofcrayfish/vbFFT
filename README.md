# vbFFT
この項目は、書きかけの項目です。この項目を加筆・訂正などするためのやる気を求めています。  
VB.NETで書かれたFFTのソースコードです。"Parallel_xx"はParallelクラスを利用した並列演算用コードになってます。
日本語版WikipediaのFFTのページにあるプログラム例(基数4)に対して15倍ほど高速に動作します。

#  使用されているFFTロジックの説明
同じ三角関数の値を連続して使えるようにした結果、基数2のFFTのくせに基本構造では三重ループ、実装ではさらに使いまわしを増やしたため四重ループになってます。  
基本構造でのTD_FFTの演算順は以下のようになっています
![image1](https://github.com/huskofcrayfish/vbFFT/blob/master/resource/image1.gif)

ソースコード中の"butterflyOffset","sameAngleCount"は以下の図を参考にしてください。
![image0](https://github.com/huskofcrayfish/vbFFT/blob/master/resource/image0.png)

#  使い方
test\test.slnを見てください。

