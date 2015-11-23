# shootingGame
---

# DEV
---

## Stage
 1. Assets/Resources/Scenes/stage.unityを開く
 1. Hierarchy上から「Main Camera」を探し、Inspectorを開く
 1. TopWindowコンポーネント上の「Debug」にチェックを入れる
 1. シーンを再生する

ステージ１が再生され、挙動を確認することが出来ます。


## 各種デバッグシーン
 - 各種デバッグシーンは、個別のツールとして作ってあるので、少し特殊な操作が必要です。
  - battleDebug
   - Scripts/Game/Body/Base/PrimBase.csの中の「TopWindow」を「BattleDebug」に”書き変えて”下さい
   - クソみたいな理由でそうなっていますが、我慢して下さい。
 - soundDebugは現状動いていません。動かしたい場合は、CommonSoundForCriと上手く連動するようにして下さい
