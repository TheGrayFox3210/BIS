# AIData

`AIData` は、BIS 開発のための AI 向け知識ベースです。

この知識ベースは、汎用 AI 活用基盤としては広げず、現在は BIS 開発支援のための 3 レイヤー構造に絞って管理します。

## レイヤー構造

### L1: Personalization

- ユーザー個人との対話方針
- 回答の癖や優先順位
- 作業時の判断姿勢

このレイヤーは「何を作るか」を知らなくても機能する対話上の方針を持ちます。

### L2: General CSharp Rules

- C# / Unity に関する汎用的なコーディング規約
- 命名規約
- 低レベルな実装ルール

このレイヤーは BIS を知らなくても、C# で何かを開発するための規約を持ちます。

### L3: BIS Solution Knowledge

- BIS ソリューション固有の構造
- 各プロジェクトの責務
- プロジェクト間の相関
- BIS 特有の設計方針

このレイヤーは BIS 固有情報を定義します。

## 依存ルール

- L1 は他レイヤーに依存しない
- L2 は L1 に依存してよい
- L3 は L1 / L2 に依存してよい
- 下位レイヤーほど具体的になり、上位レイヤーほど独立性が高い

## 現時点の正本

- [`START_HERE.md`](D:/Works/Developments/BIS/Projects/BIS/AIData/START_HERE.md)
- [`Registry.json`](D:/Works/Developments/BIS/Projects/BIS/AIData/Registry.json)
- [`L1/PersonalOperatingPrinciples.md`](D:/Works/Developments/BIS/Projects/BIS/AIData/L1/PersonalOperatingPrinciples.md)
- [`L2/CSharpUnityRules.md`](D:/Works/Developments/BIS/Projects/BIS/AIData/L2/CSharpUnityRules.md)
- [`L3/SolutionStructure.md`](D:/Works/Developments/BIS/Projects/BIS/AIData/L3/SolutionStructure.md)
- [`L3/BISCSharpOverrides.md`](D:/Works/Developments/BIS/Projects/BIS/AIData/L3/BISCSharpOverrides.md)

## 注意

- `Documents/*.html` は構築途中の旧成果物
- 今後の更新は `AIData` 側を優先する
- 既存リポジトリ内のファイルは、常に現在方針に照らして再検証する
