using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

/// <summary>
/// ステージ選択ボタン
/// </summary>
public class StageSelectButton : Button
{

    [SerializeField] int charaNumber; //ステージで戦う相手の番号
    [SerializeField] CharacterDB datas;
    private Character character;　//戦う相手

    private Character preCharacter; //一個前のステージの戦闘相手

    private GameObject Activate; //クリック時に表示するパネル
    private GameObject Disactivate; //クリック時に非表示にするパネル
    private bool buttonActive = false; // クリックできるか否か 


    void Start()
    {
        this.setCharacter();
        this.setImages();
        this.setActivate();
        this.setDisactivate();
    }

    void OnEnable()
    {
        this.setCharacter();
        this.setImages();
        this.setActivate();
        this.setDisactivate();
    }

    void OnDisable()
    {
        this.setCharacter();
        this.setImages();
        this.setActivate();
        this.setDisactivate();
    }

    /// <summary>
    /// クリック時に選択情報を設定してトップへ戻る
    /// </summary>
    public override void onClick()
    {
        if (this.character == null)
        {
            return;
        }
        if (!this.buttonActive)
        {
            return;
        }
        this.selectStage();
        this.Activate.SetActive(true);
        this.Disactivate.SetActive(false);
    }

    /// <summary>
    /// キャラ番号をもとにキャラ情報を設定
    /// </summary>
    public void setCharacter()
    {
        if (this.charaNumber == 0)
        {
            return;
        }
        if (this.datas == null)
        {
            return;
        }
        this.preCharacter = this.datas.searchCharacterByStatus(6);
        this.character = this.datas.getCharacter(this.charaNumber);
        return;
    }

    /// <summary>
    /// キャラ情報をもとにアイコンを設定。前の相手を倒していなかったら非表示。倒してたらボタンが押せるようになる。
    /// </summary>
    public void setImages()
    {
        if (this.character == null)
        {
            return;
        }
        int preStatus;
        switch (this.character.getNumber())
        {
            case 11:
            case 21:
            case 31:
                preStatus = 0;
                break;
            case 41:
                if ((this.datas.getCharacter(20).getStatus() > 4) || (this.datas.getCharacter(30).getStatus() > 4) || (this.datas.getCharacter(40).getStatus() > 4))
                {
                    preStatus = 0;
                }
                else
                {
                    preStatus = 5;
                }
                break;
            default:
                preStatus = this.datas.getCharacter(this.charaNumber - 1).getStatus();
                break;
        }

        if (preStatus > 4)
        {
            return;
        }
        this.gameObject.GetComponent<Image>().sprite = this.character.getIconImage();
        this.buttonActive = true;
        return;
    }

    /// <summary>
    /// キャラの選択情報を設定。具体的には状態をエネミーにする。
    /// </summary>
    public void selectStage()
    {
        if (this.preCharacter != null)
        {
            if (this.preCharacter.getLevel() < 1)
            {
                this.preCharacter.setStatus(5);
            }
            else
            {
                this.preCharacter.setStatus(0);
            }
        }
        this.character.setStatus(6);
        return;
    }

    /// <summary>
    /// クリック時に表示するパネルの設定
    /// </summary>
    public void setActivate()
    {
        this.Activate = transform.root.gameObject.transform.Find("GoMusicGame").gameObject;
        return;
    }

    /// <summary>
    /// クリック時に非表示にするパネルの設定
    /// </summary>
    public void setDisactivate()
    {
        this.Disactivate = transform.parent.gameObject.transform.parent.gameObject;
        return;
    }
}