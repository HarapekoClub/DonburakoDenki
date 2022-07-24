using UnityEngine;

/// <summary>
/// 敗北時の結果処理を管理するクラス
/// </summary>
public class ResultLoseManager : MonoBehaviour
{
    [SerializeField] CharacterDB datas;
    [SerializeField] GameObject gameCanvas;

    void OnEnable()
    {
        this.gameCanvas.SetActive(false);
        this.lose();
    }

    /// <summary>
    /// 編成していたキャラのレベルを上げるメソッド
    /// <summary>
    public void lose()
    {
        this.datas.searchCharacterByStatus(1).incrementLevel();
        this.datas.searchCharacterByStatus(2).incrementLevel();
        this.datas.searchCharacterByStatus(3).incrementLevel();
        this.datas.searchCharacterByStatus(4).incrementLevel();
        return;
    }
}