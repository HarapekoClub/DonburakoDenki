using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterFormationManager : MonoBehaviour
{
    [SerializeField] Image form1;　// 編成１
    [SerializeField] Image form2; // 編成２
    [SerializeField] Image form3; // 編成３
    [SerializeField] Image form4; // 編成４
    [SerializeField] CharacterDB datas;


    void Start()
    {
        this.setImages();
    }
    void OnEnable()
    {
        this.setImages();
    }

    /// <summary>
    /// キャラDBから情報を取得して対応する画像に差し替えるメソッド
    /// </summary>
    public void setImages()
    {
        GameObject obj = this.form1.transform.Find("Image").gameObject;
        this.form1.sprite = this.datas.searchCharacterByStatus(1).getIconImage();
        obj.GetComponent<Image>().sprite = this.datas.searchCharacterByStatus(1).getLevelImage();

        obj = this.form2.transform.Find("Image").gameObject;
        this.form2.sprite = this.datas.searchCharacterByStatus(2).getIconImage();
        obj.GetComponent<Image>().sprite = this.datas.searchCharacterByStatus(2).getLevelImage();

        obj = this.form3.transform.Find("Image").gameObject;
        this.form3.sprite = this.datas.searchCharacterByStatus(3).getIconImage();
        obj.GetComponent<Image>().sprite = this.datas.searchCharacterByStatus(3).getLevelImage();

        obj = this.form4.transform.Find("Image").gameObject;
        this.form4.sprite = this.datas.searchCharacterByStatus(4).getIconImage();
        obj.GetComponent<Image>().sprite = this.datas.searchCharacterByStatus(4).getLevelImage();

    }
}