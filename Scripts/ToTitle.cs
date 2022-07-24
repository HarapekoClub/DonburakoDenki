/// <summary>
/// タイトル画面に戻るボタン
/// </summary>

public class ToTitle : Button
{
    public override void onClick()
    {
        this.jumpSceneName = "TitleScene";
        this.jumpScene();
        return;
    }
}