# Codex Client Handoff

このファイルは、Codex クライアントが BIS を引き継ぐ時の最小入口です。

## 目的

- Codex は Rider とは独立して利用する
- 作業ルートは常に `BIS` フォルダ全体とする
- セッション開始時に必要な情報だけを最短で把握させる

## 最初に読む順序

1. `AIData/L1/PersonalOperatingPrinciples.md`
2. `AIData/L2/CSharpUnityRules.md`
3. `AIData/L3/SolutionStructure.md`
4. `AIData/L3/BISCSharpOverrides.md`

## 最重要前提

- 既存リポジトリ内のファイルは、過去の生成物や旧方針を含む前提で扱う
- 現在のユーザー指示を最優先する
- `AIData` が正本
- `Documents` は人間確認用の閲覧資料
- Unity / Rider のソリューション切替とは独立して、Codex は `BIS` ルート全体を継続把握する

## 補足

- Unity 側の正式なビルドや完全な参照解決は、各 Unity プロジェクト側の正式環境に依存する
- Codex は BIS 全体の設計、実装支援、横断把握のハブとして振る舞う
