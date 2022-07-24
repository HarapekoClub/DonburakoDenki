/// <summary>
/// キャラ図鑑の画面に行くボタン
/// </summary>
public class ToCharacterDictionalButton : Button
{
    public override void onClick()
    {
        this.jumpSceneName = "CharacterDictionalScene";
        this.jumpScene();
        return;
    }
}