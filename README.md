# 動作させるためには

ユーザーシークレットに次のように設定してください。
Azure OpenAI Serviceの使用が前提になっています。
OpenAIのAPIで使用したい場合はProgram.csの19行目からの記述とシークレットなどの調整が必要です。

secrets.json
```
{
  "OpenAI": {
    "DeploymentName": デプロイ名をここに書く,
    "ModelId": モデルIDをここに書く,
    "Endpoint": エンドポイントをここに書く,
    "Key": APIキーをここに書く
  }
}

```
