using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
/// キャラクターの情報を管理するクラス
///</summary>
public class Character
{
    private int number; //キャラ番号主人公が１で５１まで
    private string characterName; //キャラ名
    private string characterType; //種族名
    private string illustrater; //イラストレイター情報
    private Sprite iconImage; // キャラアイコン画像
    private int level; // 絆レベル
    private Sprite levelImage; // レベルの画像
    private string explain; //キャラ説明文
    private int status; // キャラ状態 0:編成なし,1:編成1, 2:編成2, 3:編成3, 4:編成4, 5:未所持, 6:エネミー, その他:エラー

    /// <summary>
    /// キャラ番号のゲッター
    /// </summary>
    public int getNumber()
    {
        return this.number;
    }

    /// <sumary>
    /// キャラ番号のゲッター（文字列）
    /// 01,02,03 ~ 51 みたいな感じ
    /// </summary>
    public string getNumberString()
    {
        string numberString = "";
        if (this.number < 10) numberString += "0";
        numberString += this.number.ToString();
        return numberString;
    }

    /// <summary>
    /// キャラ種族のゲッター
    /// </summary>
    public string getCharacterType()
    {
        return this.characterType;
    }

    /// <summary>
    /// キャラ名のゲッター
    /// </summary>
    public string getCharacterName()
    {
        return this.characterName;
    }

    /// <summary>
    /// イラストレーター名のゲッター
    /// </summary>
    public string getIllustrater()
    {
        return this.illustrater;
    }

    /// <summary>
    /// アイコン画像のゲッター
    /// </summary>
    public Sprite getIconImage()
    {
        return this.iconImage;
    }

    /// <summary>
    /// 絆レベルのゲッター
    /// </summary>
    public int getLevel()
    {
        return this.level;
    }

    /// <summary>
    /// レベル画像のゲッター
    /// </summary>
    public Sprite getLevelImage()
    {
        return this.levelImage;
    }

    /// <summary>
    /// キャラ説明文のゲッター
    /// </summary>
    public string getExplain()
    {
        return this.explain;
    }

    /// <summary>
    /// キャラ情報のゲッター、説明文＋イラストレーター
    /// </summary>
    public string getInfo()
    {
        return this.getExplain() + "\n illustrated by " + this.getIllustrater();
    }

    /// <summary>
    /// キャラ状態のゲッター
    /// </summary>
    public int getStatus()
    {
        return this.status;
    }

    /// <summary>
    /// キャラ状態のゲッター（文字列）
    /// </summary>
    public string getStatusString()
    {
        string msg = "";
        switch (this.status)
        {
            case 0:
                msg = "所持（編成なし）";
                break;
            case 1:
                msg = "編成１";
                break;
            case 2:
                msg = "編成２";
                break;
            case 3:
                msg = "編成３";
                break;
            case 4:
                msg = "編成４";
                break;
            case 5:
                msg = "未所持";
                break;
            case 6:
                msg = "エネミー";
                break;
            default:
                msg = "ステータスエラー";
                break;
        }
        return msg;
    }

    /// <summary>
    /// キャラ番号のセッター
    /// </summary>
    public void setNumber(int num)
    {
        this.number = num;
        return;
    }

    /// <summary>
    /// キャラ種族のセッター
    /// </summary>
    public void setCharacterType(string ty)
    {
        this.characterType = ty;
        return;
    }

    /// <summary>
    /// キャラ名のセッター
    /// </summary>
    public void setCharacterName(string nam)
    {
        this.characterName = nam;
        return;
    }

    /// <summary>
    /// イラストレーターのセッター
    /// </summary>
    public void setIllutrater(string illust)
    {
        this.illustrater = illust;
        return;
    }

    /// <summary>
    /// アイコン画像のセッター
    /// </summary>
    public void setIconImage(Sprite iconI)
    {
        this.iconImage = iconI;
        return;
    }

    /// <summary>
    /// 絆レベルのセッター
    /// </summary>
    public void setLevel(int lv)
    {
        this.level = lv;
        return;
    }

    /// <summary>
    /// レベル画像のセッター
    /// </summary>
    public void setLevelIcon(Sprite levelI)
    {
        this.levelImage = levelI;
        return;
    }

    /// <summary>
    /// 説明文のセッター
    /// </summary>
    public void setExplain(string ex)
    {
        this.explain = ex;
        return;
    }

    /// <summary>
    /// 状態のセッター
    /// </summary>
    public void setStatus(int st)
    {
        if (st < 0 && st > 6)
        {
            Debug.Log("Character.status can has 0~6");
            return;
        }
        this.status = st;
        return;
    }

    /// <summary>
    /// アイコン画像の読み込み
    /// Resources/Sprites/Character/キャラ種族 のスプライトを読み込んでアイコン画像に設定する
    /// </summary>
    public void loadIconImage()
    {
        string fileName = "Sprites/Character/" + this.getNumberString();
        this.iconImage = Resources.Load<Sprite>(fileName);
    }

    /// <summary>
    /// レベル画像の読み込み
    /// Resources/Sprites/NumberIcon/Nキャラ番号文字列 のスプライトを読み込んでレベル画像に設定する
    /// </summary>
    public void loadLevelImage()
    {
        string fileName = "Sprites/NumberIcon/L" + this.getLevel().ToString();
        this.levelImage = Resources.Load<Sprite>(fileName);
    }

    /// <summary>
    /// キャラのレベルを上げるメソッド
    /// </summary>
    public void incrementLevel()
    {
        if (this.level > 99)
        {
            return;
        }
        this.level += 1;
        return;
    }

    /// <summary>
    /// キャラをオトモにしてレベルを上げるメソッド
    /// </summary>

    public void otomorize()
    {
        this.setStatus(0);
        this.incrementLevel();
        return;
    }

}
