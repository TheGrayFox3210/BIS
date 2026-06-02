# BIS ソリューション構造とフロントエンド設計

## Scope

- BIS ソリューション全体の責務分割
- Unity フロントエンドのフォルダ構造と設計階層
- BIS ソリューション固有の構造と責務を定義したもの

## Layer

- L3: BIS Solution Knowledge

## Dependency

- このレイヤーは L1 / L2 に依存してよい
- BIS 固有の構造、責務、用語、運用前提を扱う

## Canonical Status

- 現在の一次参照先: このファイル
- 実ディレクトリとの差異はあり得るため、構造変更時はこの定義も更新する

## Terminology

- `BIS` は単一プロジェクト名ではなく、ソリューション全体を指す

## Solution Structure

- `/Backends/BIS.Server`
  ASP.NET / MagicOnion ベースのサーバー機能
- `/Backends/BIS.Shared`
  サーバー・クライアント間で共有されるデータ型やロジック
- `/Frontends/BIS.Client.Shared`
  Unity クライアント間の共有ライブラリ
- `/Frontends/BIS.Client.Dealer`
  ディーラー向け Android クライアント

## Unity Asset Isolation Rule

- 独自スクリプトや独自アセットは `Assets/プロジェクト名/` 配下に集約する
- 例: `Assets/BIS.Client.Shared/`
- 目的:
  サードパーティ製アセットとの混在、命名衝突、責務不明瞭化を避ける

## Frontend Layering Rule

Frontends 配下のスクリプトは、カスタム MVVM として以下の層へ分類する。

### Core

- 基幹クラス
- インフラ
- 各種基底クラス

### Managers

- Model 相当
- データ管理
- 通信
- コアとなるビジネスロジック
- 状態保持

### Modules

- ViewModel 相当
- Managers と UI の仲介
- UI への描画指示
- UI からの入力受付と解釈

### UI

- View 相当
- 画面描画
- 入力受付

UI は粒度別に以下へ細分化する。

- `Parts`
  最小単位の単体 UI。例: ボタン、テキスト
- `Components`
  まとまった機能を持つが、単独ではユースケースを完結しない UI。例: 入力フォーム
- `Widgets`
  単一ユースケースを満たす最上位 UI ブロック。例: ログイン画面

## Documentation Rule

クラスやモジュールを定義ファイルへ記録する際は、役割だけでなく依存関係も残す。

- 参照元:
  どこで使われているか
- 作用先:
  どのロジックや画面に影響するか

## BIS Operating Context

- 既存リポジトリ内の情報には旧方針が混在している可能性がある
- BIS 固有定義は、現行の再構築方針に合わせて都度見直す
- このレイヤーは BIS の構造と責務を明確に伝えることを目的とする

## Notes

- 現在の実ディレクトリには `BIS.Client.Monitor` や `BIS.Client.Player` は存在しない
- 将来プロジェクトが増減した場合は、このファイルと `Registry.json` を更新する
