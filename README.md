# チャリ走の3Dカジュアルゲーム開発

## 開発環境
* Unity 2021.3.19f1
* VisualStadio 2022

## 概要
* チャリ走を3D視点にしたランゲーム
* タップしてジャンプ
* 何段かジャンプできる
* 穴とか障害物をよける

## 実装
**取り敢えず走らせる**  
* 直線的なフィールドを用意
  * 傾斜や穴を設ける
* 自機を作る
  * 自動的に前進
  * タップでジャンプ
    * 複数回タップするとその分跳べる
* エンドレススコアマッチ形式のゲームプレイ
  * 秒速5mくらいのスピード感