using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// シナリオを管理するクラス
public class ScenarioManager : Button
{
    private List<string[]> scenarioSource; // シナリオソース
    [SerializeField] CharacterDB characterDB; // キャラクターデータベースオブジェクト
    [SerializeField] string filename; // シナリオファイル名
    [SerializeField] Image background; // 背景画像
    [SerializeField] Image charaImage; // キャラ画像
    [SerializeField] Text scenarioText; // 会話テキスト
    [SerializeField] Text nameText; // キャラ名
    [SerializeField] Text titleText; // 章題
    [SerializeField] ActiveChangeButton button; //ボタン
    CSVReader reader; // CSV読み取りオブジェクト
    private int position; // シナリオ進行数カウント

    /// <summary>
    /// 各オブジェクトの生成とシナリオそーす、背景画像の読み込みを行う
    /// </summary>
    async void Start()
    {
        this.position = 0;
        this.setScenarioName();
        this.reader = new CSVReader(filename);
        await this.reader.readFile();
        this.scenarioSource = this.reader.getDatas();
        this.loadScreen();
        this.onClick();
    }

    /// <summary>
    /// 敵状態のキャラ参照でシナリオ名を設定するメソッド
    /// 今は仮でS00を呼び出すようにしている
    /// </summary>
    public void setScenarioName()
    {
        string number = this.characterDB.searchCharacterByStatus(6).getNumberString();
        this.filename = "Scenario/S" + number;
        Debug.Log(this.filename);
        //this.filename = "Scenario/S" + "49";

        // //以下はビルド時には消す
        // if (System.IO.File.Exists(Application.dataPath + "/Resources/CSVFiles/" + this.filename + ".csv"))
        // {
        //     return;
        // }
        // else
        // {
        //     this.filename = "Scenario/S00";
        //     return;
        // }
    }

    /// <summary>
    /// 背景の読み込み
    /// </summary>
    public void loadScreen()
    {
        this.titleText.text = this.getSouce()[0];
        // BGM設定 GMに管理機能つけるか
        this.background.sprite = Resources.Load<Sprite>("Sprites/Background/" + this.getSouce()[1]);
        // 背景画像設定
        this.positionIncrement();
        return;
    }

    /// <summary>
    /// シナリオの進行度をインクリメント
    /// </summary>
    public void positionIncrement()
    {
        this.position += 1;
        return;
    }

    /// <summary>
    /// ListからString配列を取り出すゲッター。進行度参照。
    /// </summary>
    public string[] getSouce()
    {
        return this.scenarioSource[this.position];
    }

    /// <summary>
    /// クリック時に次のチャットを呼び出しインクリメント
    /// 進行度が最後まで行ったらジャンプシーン
    /// </summary>
    public override void onClick()
    {
        if (this.position < this.scenarioSource.Count)
        {
            string[] source = this.getSouce();
            this.chat(source[0], source[1]);
            this.positionIncrement();
            return;
        }
        else
        {
            this.jumpScene();
            this.button.onClick();
            return;
        }
    }

    /// <summary>
    /// チャットする
    /// 引数1つ目でキャラ検索して画像やキャラ名を取得
    /// 引数2つ目がテキスト内容に
    /// </summary>
    public void chat(string num, string text)
    {
        Character chara = this.characterDB.getCharacter(num);
        if (chara == null)
        {
            Debug.Log("Chara is not");
        }
        // キャラ情報取得
        this.nameText.text = chara.getCharacterName();
        // キャラ名変更
        this.charaImage.sprite = chara.getIconImage();
        // 画像変更
        this.scenarioText.text = text;
        // テキスト変更
        return;
    }

}