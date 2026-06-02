# BIS 固有の C# 命名・通信ルール

## Scope

- L2 の汎用 C# / Unity ルールに対する BIS 固有の上書き
- BIS ソリューションでのみ有効な命名規則と通信前提
- BIS ソリューションにのみ適用する C# 命名・通信ルールを定義したもの

## Layer

- L3: BIS Solution Knowledge

## Dependency

- このレイヤーは L1 / L2 に依存してよい
- 特に L2 の汎用命名・可視性ルールを前提に、その上に BIS 固有条件を追加する

## Naming Overrides

- クラス名 / 構造体名 / enum / delegate / ファイル名:
  PascalCase + `BIS` プレフィックス必須
- 名前空間:
  ルートは `BIS` で始める
- インターフェース:
  PascalCase + `IBIS` プレフィックス必須

## Communication Overrides

- BIS では gRPC + MagicOnion を採用する
- 通信はイベント駆動の単一パイプ設計を前提とする
- ペイロードは `BISNetworkEvent` と `BISNetworkData` の組み合わせで送受信する
- 通信境界では、完全な静的型安全性より柔軟性を優先する

## AI Guidance

- BIS 向けの新規型名を提案する場合は、L2 ではなくこのファイルの接頭辞規則を適用する
- BIS の通信コードを扱う場合は、汎用論ではなくこのファイルの MagicOnion 前提を優先する
- L2 と矛盾するように見える場合は、BIS 文脈ではこのファイルを優先する

## Notes

- BIS 固有情報を L2 へ混在させないための分離ファイル
