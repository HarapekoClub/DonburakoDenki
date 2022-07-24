using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

/// <summary>
/// ステージマップの管理クラス
/// </summary>
public class StageMapManager : MonoBehaviour
{
    [SerializeField] GameObject map1; // 1
    [SerializeField] GameObject map2b1; //2-1
    [SerializeField] GameObject map2b2; //2-2
    [SerializeField] GameObject map2b3; //2-3
    [SerializeField] GameObject map3; //3
    [SerializeField] CharacterDB datas;



    void OnEnable()
    {
        this.checkStatus();
    }

    void OnDisable()
    {
        this.checkStatus();
    }

    /// <summary>
    /// 各マップのアクティブ状態を返すメソッド
    /// </summary>
    public bool isActive(int num)
    {
        switch (num)
        {
            case 1: return this.map1.activeSelf;
            case 21: return this.map2b1.activeSelf;
            case 22: return this.map2b3.activeSelf;
            case 23: return this.map2b3.activeSelf;
            case 3: return this.map3.activeSelf;
            default: return false;
        }
    }

    /// <summary>
    /// キャラ情報からマップの開放状態を設定するメソッド
    /// </summary>
    public void checkStatus()
    {
        Character character;
        for (int i = 2; i <= 50; i++)
        {
            character = this.datas.getCharacter(i);
            if (character.getLevel() > 0 && character.getStatus() > 4)
            {
                character.setStatus(0);
            }
        }


        this.map2b1.SetActive(false);
        this.map2b2.SetActive(false);
        this.map2b3.SetActive(false);
        this.map3.SetActive(false);



        character = this.datas.getCharacter(10);

        if (character.getLevel() > 0)
        {
            this.map2b1.SetActive(true);
            this.map2b2.SetActive(true);
            this.map2b3.SetActive(true);
        }

        character = this.datas.getCharacter(20);

        if (character.getLevel() > 0)
        {
            this.map3.SetActive(true);
        }

        character = this.datas.getCharacter(30);

        if (character.getLevel() > 0)
        {
            this.map3.SetActive(true);
        }


        character = this.datas.getCharacter(40);

        if (character.getLevel() > 0)
        {
            this.map3.SetActive(true);
        }

    }

    }

    // /// <summary>
    // /// キャラ情報からマップの開放状態を設定するメソッド
    // /// </summary>
    // public void checkStatus()
    // {
    //     Character character;

    //     character = this.datas.getCharacter(10);

    //     if (character.getLevel() > 0)
    //     {
    //         this.map2b1.SetActive(true);
    //         this.map2b2.SetActive(true);
    //         this.map2b3.SetActive(true);
    //     }
    //     else
    //     {
    //         this.map2b1.SetActive(false);
    //         this.map2b2.SetActive(false);
    //         this.map2b3.SetActive(false);
    //     }

    //     character = this.datas.getCharacter(20);

    //     if (character.getLevel() > 0)
    //     {
    //         this.map3.SetActive(true);
    //     }
    //     else
    //     {
    //         this.map3.SetActive(false);
    //     }

    //     character = this.datas.getCharacter(30);

    //     if (character.getLevel() > 0)
    //     {
    //         this.map3.SetActive(true);
    //     }
    //     else
    //     {
    //         this.map3.SetActive(false);
    //     }

    //     character = this.datas.getCharacter(40);

    //     if (character.getLevel() > 0)
    //     {
    //         this.map3.SetActive(true);
    //     }
    //     else
    //     {
    //         this.map3.SetActive(false);
    //     }

    // }

