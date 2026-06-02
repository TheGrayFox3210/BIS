# C#・Unity コーディング規約とアーキテクチャ思想

## Scope

- BIS に限定しない C# / Unity 実装全般の基準
- 書式、可視性、汎用的な命名方針の判断基準
- BIS に依存しない C# / Unity 共通ルールを定義したもの

## Layer

- L2: General CSharp Rules

## Dependency

- このレイヤーは L1 の運用方針を前提にしてよい
- BIS 固有構造を知らなくても成立する
- 特定ソリューションの都合がある場合は、L3 側で追加・上書き方針を定義する

## Canonical Status

- 現在の一次参照先: このファイル
- 実装上の低レベルな書式根拠として `.editorconfig` を併用する

## Format Rules

- 文字コード: UTF-8
- 改行コード: CRLF
- インデント: スペース 4
- 最大行長: 120 文字
- 修飾子順:
  `public`, `private`, `protected`, `internal`, `file`, `new`, `static`, `abstract`, `virtual`, `sealed`, `readonly`, `override`, `extern`, `unsafe`, `volatile`, `async`, `required`

## Naming Rules

- クラス名 / 構造体名 / enum / delegate / ファイル名:
  PascalCase
- 名前空間:
  PascalCase ベースで一貫させる
- インターフェース:
  PascalCase + `I` プレフィックス
- 非公開インスタンスフィールド:
  camelCase + `_` プレフィックス
- 静的フィールド:
  camelCase + `s_` プレフィックス
- 定数:
  PascalCase
- `static readonly`:
  PascalCase

## Encapsulation Rules

- `public` フィールドは原則禁止
- 外部公開が必要な値はプロパティ経由で公開する
- メンバの可視性は最小限に保つ
- 特別な理由がない限り `private` を基準にする

## C# Style Notes

- `var` は許容される
- 組み込み型は C# キーワード表記を優先する
- 不要な `this.` などの修飾は避ける
- 括弧は算術演算では不要なら省略し、その他の二項演算では可読性優先で明示する

## Architecture Rule: Communication

- gRPC やイベント駆動設計は選択肢として許容される
- 通信境界では、型安全性と柔軟性のどちらを優先するかを明示する
- 特定フレームワークや具体的なイベント定義は L3 で扱う

## AI Guidance

- コード生成時は汎用命名規則を維持する
- 公開 API を増やす提案では、カプセル化を崩す理由を説明する
- BIS 固有の命名や通信方式を持ち込む場合は、L3 の定義確認を先に行う

## Notes

- この定義は完成版ではなく、現在の再構築段階における暫定正本
- `BIS` / `IBIS` 接頭辞や MagicOnion 固定ルールなどの BIS 依存要素は L3 へ分離する
