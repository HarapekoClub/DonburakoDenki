/// <summary>
/// ステージ選択画面に行くボタン
/// </summary>

public class ToStageSelectButton : Button
{
    public override void onClick()
    {
        this.jumpSceneName = "StageSelectScene";
        this.jumpScene();
        return;
    }
}