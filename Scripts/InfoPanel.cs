using UnityEngine;

/// <summary>
/// キャラ詳細を表示するウィンドウの表示を司るボタン
/// </summary>
public class InfoPanel : Button
{
    /// <summary>
    /// クリック時に非表示
    /// </summary>
    public override void onClick()
    {
        this.gameObject.SetActive(false);
        return;
    }
}