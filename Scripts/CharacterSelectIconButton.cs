using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// キャラ編成画面におけるアイコン兼ボタンクラス
/// </summary>
public class CharacterSelectIconButton : Button
{
    private Character character; //司るキャラ情報

    private Character selectedCharacter; //現在編成されているキャラクター情報

    private GameObject parent; //親オブジェクト

    private ActiveChangeButton acbutton; //選択の確定時にポップアップを消すためのボタン

    private int status; //目標のステータス

    /// <summary>
    /// クリック時にステータスの変更とポップアップの非表示処理をするためのメソッド
    /// </summary>
    public override void onClick()
    {
        if (this.character.getStatus() > 4)
        {
            Debug.Log("Mada motte nai yo");
            return;
        }

        if (this.character == this.selectedCharacter)
        {
            Debug.Log("Hensei Chu");
            return;
        }

        this.selectedCharacter.setStatus(this.character.getStatus());
        this.character.setStatus(this.status);
        this.acbutton.onClick();
        return;
    }

    /// <summary>
    /// 親要素を適当に変更するメソッド
    /// </summary>
    public void changeParent()
    {
        this.setParent();
        GameObject dict = this.parent.transform.Find("Dictional").gameObject;
        Debug.Log("change " + dict.name);
        transform.parent = dict.transform;
        return;
    }

    /// <summary>
    /// 親要素を設定するメソッド
    /// </summary>
    public void setParent()
    {
        this.parent = transform.root.gameObject;
        Debug.Log("set " + this.parent.name);
    }

    /// <summary>
    /// 目標ステータスのセッター
    /// </summary>
    public void setStatus(int num)
    {
        this.status = num;
        return;
    }

    /// <summary>
    /// 担当キャラのセッター
    /// </summary>
    public void setCharacter(Character character)
    {
        this.character = character;
        return;
    }

    /// <summary>
    /// 編成キャラのセッター
    /// </summary>
    public void setSelectedCharacter(Character character)
    {
        this.selectedCharacter = character;
        return;
    }

    /// <summary>
    /// ボタンのセッター
    /// </summary>
    public void setACButton()
    {
        GameObject obj = this.parent.transform.Find("Select" + this.status.ToString()).gameObject;
        obj = obj.transform.Find("ActiveButton").gameObject;
        this.acbutton = obj.GetComponent<ActiveChangeButton>();
    }

    /// <summary>
    /// キャラのゲッター
    /// </summary>
    public Character getCharacter()
    {
        return this.character;
    }

    /// <summary>
    /// ステのゲッター
    /// </summary>
    public int getStatus()
    {
        return this.status;
    }

    /*
    /// <summary>
    /// 
    /// </summary>
    public void resetJumpSceneName()
    {
        if (this.character == null)
        {
            Debug.Log("Null Pointer Exception at Character on button");
            return;
        }
        this.jumpSceneName = character.getNumberString() + "InfoScene";
    }
    */

    /// <summary>
    /// アイコン画像の設定
    /// </summary>
    public void setIconImages()
    {
        if (this.character == null)
        {
            Debug.Log("Character none");
            return;
        }

        if (this.character.getLevel() < 1)
        {
            return;
        }

        GameObject charaIcon = this.gameObject.transform.Find("IconImage").gameObject;
        charaIcon.GetComponent<Image>().sprite = this.character.getIconImage();
        GameObject levelIcon = charaIcon.transform.Find("LevelImage").gameObject;
        levelIcon.GetComponent<Image>().sprite = this.character.getLevelImage();
    }

}