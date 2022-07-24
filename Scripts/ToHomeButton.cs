/// <summary>
/// ホーム画面に行くボタン
/// </summary>

public class ToHomeButton : Button
{
    public override void onClick()
    {
        this.jumpSceneName = "HomeScene";
        this.jumpScene();
        return;
    }
}