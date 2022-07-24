/// <summary>
/// シナリオ画面に行くボタン
/// </summary>

public class ToScenarioButton : Button
{
    public override void onClick()
    {
        this.jumpSceneName = "ScenarioScene";
        this.jumpScene();
        return;
    }
}