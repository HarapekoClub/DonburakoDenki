using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// キャラクターデータベースを管理するクラス
/// </summary>
public class CharacterDB : MonoBehaviour
{
    private List<string[]> datas;　// キャラ情報を保持するList。CSV管理クラスとの受け渡しに用いる。
    private Dictionary<string, Character> db; // キャラ情報を保持するDitionary。実際のゲーム内で情報取得、操作に用いる。キャラ番号がキー、中身がキャラクターオブジェクト
    private CSVReader reader; // CSVを読み込むオブジェクト
    //private CSVWriter writer; // CSVを書き込むオブジェクト
    private PrefsContoroler contoroler;

    private string path;
    [SerializeField] string csvname; // キャラ情報を書き込んだCSVファイル名。Unity側で書き込む。

    //private bool firstFlag;

    /*
    // Start is called before the first frame update
    async void Start()
    {
        if (this.csvname == "")
        {
            Debug.Log("csvname ga null daze");
            return;
        }
        this.path = Application.dataPath + "/Resources/CSVFiles/";
        this.datas = new List<string[]>();
        this.db = new Dictionary<string, Character>();

        if (File.Exists(this.path + this.csvname))
        {
            this.reader = new CSVReader(this.csvname);
            this.writer = new CSVWriter(this.csvname);
        }

        this.contoroler = new PrefsContoroler();


        await this.setDatabase();
    }*/

    async void Awake()
    {
        this.enableTask();
    }

    ///<summary>
    /// アタッチしたGameObjectが有効化された際に行う処理。Dbの読み込みを行う。
    ///</summary>
    public async void enableTask()
    {
        if (this.csvname == "")
        {
            Debug.Log("csvname ga null daze");
            return;
        }
        this.path = Application.dataPath + "/Resources/CSVFiles/";
        this.datas = new List<string[]>();
        this.db = new Dictionary<string, Character>();
        if (!PlayerPrefs.HasKey("charaFlag"))
        {
            PlayerPrefs.SetString("charaFlag", "True");
            this.reader = new CSVReader(this.csvname);
            //this.writer = new CSVWriter(this.csvname);
        }

        this.contoroler = new PrefsContoroler();

        await this.setDatabase();
    }

    // Update is called once per frame
    void Update()
    {
        //this.updateCSV();
    }

    /// <summary>
    /// キャラデータベースのゲッター（Dictionary）
    /// </summary>
    public Dictionary<string, Character> getDB()
    {
        return this.db;
    }

    /// <summary>
    /// キャラクター情報リストのゲッター（List<string[]>）
    /// 基本は使わない
    /// </summary>
    public List<string[]> getDatas()
    {
        return this.datas;
    }

    /// <summary>
    /// キャラクターのコンストラクタの代用
    /// 引数で受け取ったものからキャラクターオブジェクトを作成して返す
    /// </summary>
    public Character makeCharacter(int num, string name, string type, int level, string exp, string illust, int st)
    {
        //Debug.Log("character making");
        Character chara = new Character();
        chara.setNumber(num);
        chara.setCharacterName(name);
        chara.setCharacterType(type);
        chara.setIllutrater(illust);
        chara.setLevel(level);
        chara.setExplain(exp);
        chara.setStatus(st);
        chara.loadIconImage();
        chara.loadLevelImage();
        return chara;
    }

    /// <summary>
    /// データベース（Dictionary）の作成メソッド
    /// CSVファイルを読み取り、データからキャラクターを作り格納する
    /// スタート時に一度だけ呼び出す
    /// </summary>
    private async Task setDatabase()
    {
        Character chara;
        if (this.reader == null)
        {
            this.datas = this.contoroler.loadDatas();
        }
        else
        {
            await this.reader.readFile();
            this.datas = this.reader.getDatas();
        }
        foreach (string[] data in this.datas)
        {
            chara = this.makeCharacter(Convert.ToInt32(data[0]), data[2], data[1], Convert.ToInt32(data[4]), data[5], data[3], Convert.ToInt32(data[6]));
            this.dbAdd(chara.getNumberString(), chara);
        }
    }


    /// <summary>
    /// キャラクターの情報（List<string>）の更新メソッド
    /// Dictionaryの情報を素にList<string>を更新する
    /// </summary>
    private void updateList()
    {
        List<string[]> datas = new List<string[]>();
        string[] line;
        Character chara;
        foreach (var charaData in this.db)
        {
            line = new string[7];
            chara = charaData.Value;
            line[0] = chara.getNumber().ToString();
            line[1] = chara.getCharacterType();
            line[2] = chara.getCharacterName();
            line[3] = chara.getIllustrater();
            line[4] = chara.getLevel().ToString();
            line[5] = chara.getExplain();
            line[6] = chara.getStatus().ToString();
            datas.Add(line);
        }

        this.datas = datas;
        return;
    }

    /*
    /// <summary>
    /// CSVファイルのアップデート
    /// Dictionaryの変更をCSVに反映する
    /// シーン遷移前に一度だけ呼び出す
    /// </summary>
    public async Task updateCSV()
    {
        this.updateList();
        this.writer.setLines(this.datas);
        this.writer.formatLine();
        await this.writer.saveDatas();
        return;
    }*/

    public void dataSave()
    {
        this.updateList();
        this.contoroler.saveDatas(this.datas);
        return;
    }

    /*
    public async Task deleteCSV()
    {
        if (this.writer == null)
        {
            return;
        }
        await this.writer.deleteFile();
        return;
    }*/

    /// <summary>
    /// Dictionaryにキャラクターを追加するメソッド
    /// 同じキーのキャラクターは追加できない
    /// </summary>
    public void dbAdd(string key, Character chara)
    {
        if (this.db.ContainsKey(key))
        {
            Debug.Log("そのキャラクターは既に実装済みだぜ");
            return;
        }
        this.db.Add(key, chara);
        return;
    }

    /// <summary>
    /// キャラクターの取得メソッド
    /// 整数のキャラ番号で検索
    /// </summary>
    public Character getCharacter(int num)
    {
        string numberString = "";
        if (num < 10) numberString += "0";
        numberString += num.ToString();

        if (this.getDB().ContainsKey(numberString))
        {
            //Debug.Log("found");
        }
        else
        {
            Debug.Log("404 not found");
            return null;
        }
        return this.getDB()[numberString];

    }

    /// <summary>
    /// キャラクターの取得メソッド
    /// 文字列のキャラ番号で検索
    /// </summary>
    public Character getCharacter(string numberString)
    {
        if (this.getDB().ContainsKey(numberString))
        {
            // Debug.Log("found");
        }
        else
        {
            Debug.Log("404 not found ver.2");
            return null;
        }
        return this.getDB()[numberString];
    }

    /// <summary>
    /// statusでキャラ検索
    /// </summary>
    public Character searchCharacterByStatus(int status)
    {
        foreach (Character character in this.db.Values)
        {
            if (character.getStatus() == status)
            {
                return character;
            }
        }
        return this.getCharacter(0);
    }

}


