using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// キャラクターの図鑑情報を表示するアイコン兼ボタンのクラス
/// </summary>
public class CharacterIconButton : Button
{
    private Character character;　// 司るキャラクター

    private GameObject parent; // 親オブジェクト
    private GameObject infoPanel;　// キャラ情報を表示するパネル

    /// <summary>
    /// クリック時にパネルを開示する
    /// </summary>
    public override void onClick()
    {
        this.infoPanel = parent.transform.Find("InfoPanel").gameObject;
        this.setInfoPanel();
        this.infoPanel.SetActive(true);
        return;
    }

    /// <summary>
    /// 親オブジェクトを適当に変える
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
    /// 親オブジェクトを設定する
    /// </summary>
    public void setParent()
    {
        this.parent = transform.root.gameObject;
        Debug.Log("set " + this.parent.name);
    }

    /// <summary>
    /// キャラのセッター
    /// </summary>
    public void setCharacter(Character character)
    {
        this.character = character;
        return;
    }

    /// <summary>
    /// キャラのゲッター
    /// </summary>
    public Character getCharacter()
    {
        return this.character;
    }

    /*
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
    /// キャラのアイコンを設定するメソッド
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

    /// <summary>
    /// キャラの詳細情報パネルを設定するメソッド
    /// </summary>
    public void setInfoPanel()
    {
        if (this.character == null)
        {
            Debug.Log("Character none");
            return;
        }

        this.infoPanel = this.parent.transform.Find("InfoPanel").gameObject;

        if (this.character.getLevel() < 1)
        {
            GameObject infoIcon = this.infoPanel.transform.Find("IconInfo").gameObject;
            infoIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Character/00");
            GameObject infoLevel = infoIcon.transform.Find("LevelInfo").gameObject;
            infoLevel.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/NumberIcon/L0");

            GameObject nameInfo = this.infoPanel.transform.Find("NameBox").gameObject.transform.Find("Text").gameObject;
            nameInfo.GetComponent<Text>().text = "";

            GameObject typeInfo = this.infoPanel.transform.Find("TypeBox").gameObject.transform.Find("Text").gameObject;
            typeInfo.GetComponent<Text>().text = "";

            GameObject explainInfo = this.infoPanel.transform.Find("Explain").gameObject.transform.Find("Text").gameObject;
            explainInfo.GetComponent<Text>().text = "";

            GameObject numInfo = this.infoPanel.transform.Find("NumberInfo").gameObject.transform.Find("Text").gameObject;
            numInfo.GetComponent<Text>().text = "";

            GameObject statusInfo = this.infoPanel.transform.Find("StatusBox").gameObject.transform.Find("Text").gameObject;
            statusInfo.GetComponent<Text>().text = this.character.getStatusString();

            return;
        }
        else
        {

            GameObject infoIcon = this.infoPanel.transform.Find("IconInfo").gameObject;
            infoIcon.GetComponent<Image>().sprite = this.character.getIconImage();
            GameObject infoLevel = infoIcon.transform.Find("LevelInfo").gameObject;
            infoLevel.GetComponent<Image>().sprite = this.character.getLevelImage();

            GameObject nameInfo = this.infoPanel.transform.Find("NameBox").gameObject.transform.Find("Text").gameObject;
            nameInfo.GetComponent<Text>().text = this.character.getCharacterName();

            GameObject typeInfo = this.infoPanel.transform.Find("TypeBox").gameObject.transform.Find("Text").gameObject;
            typeInfo.GetComponent<Text>().text = this.character.getCharacterType();

            GameObject explainInfo = this.infoPanel.transform.Find("Explain").gameObject.transform.Find("Text").gameObject;
            explainInfo.GetComponent<Text>().text = this.character.getInfo();

            GameObject numInfo = this.infoPanel.transform.Find("NumberInfo").gameObject.transform.Find("Text").gameObject;
            numInfo.GetComponent<Text>().text = this.character.getNumberString();

            GameObject statusInfo = this.infoPanel.transform.Find("StatusBox").gameObject.transform.Find("Text").gameObject;
            statusInfo.GetComponent<Text>().text = this.character.getStatusString();
        }

    }

}