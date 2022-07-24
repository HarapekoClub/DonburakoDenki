using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// 音ゲ画面における敵のアイコンを管理するクラス
/// </summary>
public class EnemyIcon : MonoBehaviour
{
    [SerializeField] CharacterDB datas;
    private Character enemy;

    /// <summary>
    /// 表示時にキャラ画像を設定する
    /// </summary>
    void OnEnable()
    {
        this.setEnemy();
        if (this.enemy == null) return;
        this.gameObject.GetComponent<Image>().sprite = this.enemy.getIconImage();
    }

    /// <summary>
    /// 敵のキャラクターを取得するセッターメソッド
    /// </summary>
    public void setEnemy()
    {
        if (datas == null) return;
        this.enemy = this.datas.searchCharacterByStatus(6);
        return;
    }

    /// <summary>
    /// ゲッター
    /// </summary>
    public Character getEnemy()
    {
        return this.enemy;
    }
}