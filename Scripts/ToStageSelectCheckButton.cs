/// <summary>
/// 音ゲ画面からステージ選択に戻ってくるボタン
/// </summary>

public class ToStageSelectCheckButton : Button
{
    public override void onClick()
    {
        this.jumpSceneName = "StageSelectCheckScene";
        this.jumpScene();
        return;
    }
}