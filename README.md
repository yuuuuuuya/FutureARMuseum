# FutureARMuseum

ARFoundationを利用し、未来の美術館をイメージしたARアプリ。<br>
現実空間に浮かぶ球体に入ると、各展示物を鑑賞できる。<br>

Red:画像<br>
Blue:3Dオブジェクト<br>
Green:360度パノラマ<br>

# DEMO

[![demo](https://github.com/yuuuuuuya/FutureARMuseum/wiki/images/futureARmuseum.gif)](https://github.com/yuuuuuuya/FutureARMuseum/wiki/images/futureARmuseum.gif)

# implementation

- 球体を押しのける操作<br>
球体を押下し押しのける操作をする為に、raycastが当たる球体表面の法線を取得。<br>
取得した法線のマイナス方向にaddForceで力を加えおしのける操作を実現。

- 画像を実行時に通信しダウンロード<br>
サンプル画像を提供しているサイトと通信し、実行時にダウンロードした画像をTextureとして使用。

- 球体の内側をレンダリング<br>
Shaderをいじり、デフォルトでは処理されないオブジェクトの内側をレンダリング。

# Usage

- 球体をシングルタッチ→遠ざける<br>
- 球体を長押し→近づいてくる

# Author

* 伊島悠矢
* b.ald.m.wn@gmail.com