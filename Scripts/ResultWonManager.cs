using UnityEngine;

/// <summary>
/// 勝利時の結果処理を管理するクラス
/// </summary>
public class ResultWonManager : MonoBehaviour
{
    [SerializeField] CharacterDB datas;
    [SerializeField] GameObject gameCanvas;

    void OnEnable()
    {
        this.gameCanvas.SetActive(false);
        this.win();
    }

    /// <summary>
    /// 編成していたキャラのレベルを上げ、敵だったキャラをオトモにするメソッド
    /// <summary>
    public void win()
    {
        this.datas.searchCharacterByStatus(1).incrementLevel();
        this.datas.searchCharacterByStatus(2).incrementLevel();
        this.datas.searchCharacterByStatus(3).incrementLevel();
        this.datas.searchCharacterByStatus(4).incrementLevel();
        this.datas.searchCharacterByStatus(6).otomorize();
        return;
    }
}