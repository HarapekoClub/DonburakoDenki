using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameObjectのアクティブ、非アクティブを切り替えるオブジェクト
/// </summary>
public class ActiveChangeButton : Button
{
    [SerializeField] GameObject toActive;
    [SerializeField] GameObject disAtcive;

    /// <summary>
    /// アクティブ状態の変更
    /// </summary>
    public override void onClick()
    {
        if (this.disAtcive != null)
        {
            this.disAtcive.SetActive(false);
        }
        if (this.toActive != null)
        {
            this.toActive.SetActive(true);
        }
    }
}