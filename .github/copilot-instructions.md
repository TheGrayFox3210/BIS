# BIS AI 運用指示

本ソリューションで AI が参照すべき正本は、GitHub 上の慣習的な補助ファイルではなく `AIData` 配下の定義です。

## 基本原則

- 既存リポジトリ内のファイルは、過去の開発途中生成物を含む前提で扱う
- 既存ファイルの内容を無条件に信用しない
- 現在のユーザー指示を最優先する
- `Documents` は人間向けの閲覧資料であり、正本ではない

## AIData の参照順

1. `/AIData/Registry.json`
2. `/AIData/L1/PersonalOperatingPrinciples.md`
3. `/AIData/L2/CSharpUnityRules.md`
4. `/AIData/L3/SolutionStructure.md`
5. `/AIData/L3/BISCSharpOverrides.md`

## レイヤー構造

- `L1`: ユーザー個人との対話・運用方針
- `L2`: BIS 非依存の C# / Unity 共通規約
- `L3`: BIS 固有の構造・設計・運用

依存方向は `L1 -> L2 -> L3` の順で具体化される。

## 出力方針

- 出力形式は、その時点のユーザー指示を最優先する
- 特に指定がない場合は、BIS の Wikipedia 記事風に自然文で整理する
- 仕様書形式が求められる場合は、案内的・運用的な節を抑え、仕様本文を優先する

## 注意

- `Documents` 配下の HTML は `AIData` を元に生成された閲覧用資料として扱う
- GitHub や IDE のローカル状態は、設計判断の根拠として優先しない
