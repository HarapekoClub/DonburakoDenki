using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// CSVの読み込み担当クラス
/// </summary>
public class CSVReader
{
    private string filepath; // ファイルのパス
    private string filename; // ファイル名
    private TextAsset csv; // CSV内の情報
    private List<string[]> datas; // CSVから取得した情報

    /// <summary>
    /// コンストラクタ
    /// ファイルへアクセスして読み込む
    /// </summary>
    public CSVReader(string filename)
    {
        this.filename = filename;
        this.filepath = "CSVFiles/";
        this.datas = new List<string[]>();
    }

    /// <summary>
    /// パスのゲッター
    /// </summary>
    public string getFilePath()
    {
        return this.filepath;
    }

    /// <summary>
    /// ファイル名のゲッター
    /// </summary>
    public string getFileName()
    {
        return this.filename;
    }

    /// <summary>
    /// ファイル名のセッター
    /// </summary>
    public void setFileName(string filename)
    {
        this.filename = filename;
    }

    /// <summary>
    /// CSVファイルの読み取り
    /// </summary>
    public async Task loadCSV()
    {
        this.csv = (TextAsset)Resources.Load(filepath + filename);
    }

    /// <summary>
    /// 読み取ったファイルをString型の配列のデータに整形
    /// </summary>
    public async Task readFile()
    {
        string line;
        await this.loadCSV();
        // this.csv = (TextAsset)Resources.Load(filepath + filename);
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() != -1)
        {
            line = reader.ReadLine();
            this.datas.Add(line.Split(','));
        }
        return;
    }

    /// <summary>
    /// データのゲッター
    /// </summary>
    public List<string[]> getDatas()
    {
        return this.datas;
    }
}