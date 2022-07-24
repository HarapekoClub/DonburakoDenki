using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using System.Threading.Tasks;

/// <summary>
/// CSVの書き込み担当クラス
/// </summary>
public class CSVWriter
{
    private string filepath; /// CSVファイルのあるディレクトリの絶対パス

    private string filename; /// CSVファイルの名前
    private List<string> dataLine; /// 書き込むCSVの元データ。一行ごとにListに格納
    private List<string[]> dataLines; /// 書き込むCSVの元データ。1マスごとの要素を格納

    /// <summary>
    /// コンストラクタ
    /// パス等の設定とListの生成
    /// </summary>
    /// <param> filename : ファイル名 </param>
    public CSVWriter(string filename)
    {
        this.filename = filename + ".csv";
        this.filepath = Application.dataPath + "/Resources/CSVFiles/";
        Debug.Log(this.filepath + this.filename);
        this.dataLine = new List<string>();
        this.dataLines = new List<string[]>();

    }


    /// <summary>
    /// 1行の情報を追加するメソッド
    /// 1要素ごとに配列で追加
    /// </summary>
    public void setLine(string[] line)
    {
        this.dataLines.Add(line);
        return;
    }

    /// <summary>
    /// 1行の情報を追加するメソッド
    /// 1行ごと文字列で追加
    /// </summary>
    public void setLine(string line)
    {
        this.dataLine.Add(line);
        return;
    }


    /// <summary>
    /// Listのセッター
    /// 要素単位でのデータをセット
    /// </summary>
    public void setLines(List<string[]> lines)
    {
        this.dataLines = lines;
        return;
    }


    /// <summary>
    /// List<string[]>に含まれるデータを整形してList<string>に投入するメソッド
    /// </summary>
    public void formatLine()
    {
        string oneLine = "";
        List<string> dataLine = new List<string>();
        foreach (string[] line in this.dataLines)
        {
            oneLine = "";
            foreach (string data in line)
            {
                oneLine += data;
                oneLine += ",";
            }
            oneLine = oneLine.TrimEnd(',');
            dataLine.Add(oneLine);
        }
        this.dataLine = dataLine;
        return;
    }

    /// <summary>
    /// List<string>の情報をCSVに書き込むメソッド
    /// </summary>
    public async Task saveDatas()
    {
        string target = this.filepath + this.filename;

        await this.deleteFile();

        Debug.Log("data saving");
        StreamWriter writer;
        writer = new StreamWriter(target, false);

        foreach (string line in this.dataLine)
        {
            writer.WriteLine(line);
            Debug.Log(line);
        }

        writer.Flush();
        writer.Close();
    }


    public async Task deleteFile()
    {
        string target = this.filepath + this.filename;
        File.Delete(target);
        File.Delete(target + ".meta");
        Debug.Log("File Deleted");
        return;
    }
}