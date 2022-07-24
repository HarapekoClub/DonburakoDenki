using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

/// <summary>
/// ステージ選択の管理クラス。開放されていないステージマップには行けないようにする。
/// </summary>
public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject keyTo2b1; //2-1への矢印
    [SerializeField] GameObject keyTo2b2; // to 2-2
    [SerializeField] GameObject keyTo2b3; // to 2-3
    [SerializeField] GameObject keyTo3; // to 3
    [SerializeField] CharacterDB datas;
    [SerializeField] StageMapManager mapManager; // マップ管理オブジェクト


    void OnEnable()
    {
        this.checkStatus();
    }

    void OnDisable()
    {
        this.checkStatus();
    }

    /// <summary>
    /// 開放状況に応じて矢印の表示を切り替え
    /// </summary>
    public void checkStatus()
    {
        this.check(this.keyTo2b1, 21);
        this.check(this.keyTo2b2, 22);
        this.check(this.keyTo2b3, 23);
        this.check(this.keyTo3, 3);
    }

    /// <summary>
    /// 矢印を切り替え
    /// </summary>
    public void check(GameObject obj, int num)
    {

        if (obj == null) return;
        obj.SetActive(this.mapManager.isActive(num));
    }

}