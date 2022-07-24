/// <summary>
/// 音ゲ画面に行くボタン
/// </summary>

public class ToMusicGameButton : Button
{
    public override void onClick()
    {
        this.jumpSceneName = "MusicGameScene";
        this.jumpScene();
        return;
    }
}