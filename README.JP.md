# 共通体験サンプル(Common experience sample)

[English version README](https://github.com/open-video-game-library/CommonExperienceSample/blob/main/README.md)

共通体験サンプル(Common experience sample)は、触覚ディスプレイを評価するための、オープンな体験サンプルです。触覚ディスプレイを用いて、掴む、持つ、かざすといった基本動作を調整・体験できます。触覚ディスプレイがフィードバックする6次元のものの特性(質感、硬さ、温度、重さ、形状、動き）ごとに、既存研究にて利用頻度の高いサンプルを利用できます。また、共通体験サンプルは触覚ディスプレイの標準評価刺激となることを目指しており、ディスプレイ間の比較促進を目的としています。

 

https://user-images.githubusercontent.com/71160720/186408669-96bc2ad9-e50c-4c37-95b8-366332fc7501.mp4

詳細なデモ動画は[こちら](https://www.youtube.com/watch?v=3QshPIVFACQ)



## Features



#### パラメータ調整・出力機能
	
サンプル内で調整ニーズの高い各種パラメータをGUI上で容易に調整することができます。さらに、調整されたパラメータ情報を書き出し、読み込むことで差分を反映させることができます。これにより、他研究者のパラメータ情報を反映させ、実験条件を統一させることもできます。


https://user-images.githubusercontent.com/71160720/186425256-223169bc-e52f-4aaf-98e5-c1e7213b05b5.mov		


		

### 研究利用例


1. 共通体験サンプルを用いて開発した触覚ディスプレイの評価実験をする。
2. 学会のデモ発表にて共通体験サンプルを用いる。

## Requirement

* Unity 2021.3.4f1
* Oculus XR Plugin 3.0.2
* XR Plugin Management 4.2.1

## Installation

[こちら](https://unity3d.com/jp/get-unity/download/archive)からUnityのインストールができます。

## Usage

本リポジトリを下記コマンドでローカル環境にクローンしてご利用ください。

```bash
git clone git@github.com:open-video-game-library/CoExperienceSamples.git
```



## Licence
共通体験サンプルの使用許諾は、[MITライセンス](https://github.com/open-video-game-library/CommonExperienceSample/blob/main/LICENSE.md)およびオリジナルライセンスとなります。オリジナルライセンスは、他の研究者があなたの実験環境を再現するため設定しています。
  
### Original License
  
研究目的で、オープンビデオゲームライブラリが提供するソフトウェアを改変して使用する場合は、ソフトウェアのバージョンとそのソースコードを公開し、使用するソフトウェアに同梱されているREADMEファイルに記述されている論文を引用する必要があります。


## 引用
Common Experience Sample 1.0: Developing a sample for comparing the characteristics of haptic displays

[論文のページに行く](https://dl.acm.org/doi/10.1145/3562939.3565649)

### BibTeX
```
@inproceedings{10.1145/3562939.3565649,
author = {Oka, Takuya and Morimoto, Kosuke and Yanase, Yohei and Watanabe, Keita},
title = {Common Experience Sample 1.0: Developing a Sample for Comparing the Characteristics of Haptic Displays},
year = {2022},
isbn = {9781450398893},
publisher = {Association for Computing Machinery},
address = {New York, NY, USA},
url = {https://doi.org/10.1145/3562939.3565649},
doi = {10.1145/3562939.3565649},
abstract = {Many haptic displays that provide haptic feedback to users have been proposed;however, differences in experimental environments make comparisons of displays difficult. Therefore, we categorized the characteristics of feedback based on existing research, and developed a common experience sample that includes virtual objects necessary for the expression of each characteristic. Additionally, we will study the methods of evaluating displays using the proposed sample, and aim at comparative evaluation of multiple displays.},
booktitle = {28th ACM Symposium on Virtual Reality Software and Technology},
articleno = {47},
numpages = {2},
keywords = {haptic, virtual reality, crossmodal, sample, evaluation, multimodal},
location = {Tsukuba, Japan},
series = {VRST '22}
}
```

## Contact

意見や要望、質問などがありましたら、[こちら](https://openvideogame.cc/contact)からお問い合わせ下さい。
