/// <summary>
/// キャラ編成に行くボタン
/// </summary>

public class ToFormationButton : Button
{
    public override void onClick()
    {
        this.jumpSceneName = "SelectScene";
        this.jumpScene();
        return;
    }
}