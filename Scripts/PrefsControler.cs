using UnityEngine;
using System;
using System.Collections.Generic;

public class PrefsContoroler

{

    private int count;
    public void saveDatas(List<string[]> datas)
    {
        Debug.Log("save");
        this.count = 0;
        foreach (string[] data in datas)
        {
            PlayerPrefs.SetString(data[0], this.formatLine(data));
            //Debug.Log("Saving" + this.formatLine(data));
            this.count += 1;
        }
        //Debug.Log("Character Save : " + this.count.ToString());
        PlayerPrefs.SetInt("count", this.count);
        PlayerPrefs.Save();
    }

    public List<string[]> loadDatas()
    {
        Debug.Log("load");
        this.count = PlayerPrefs.GetInt("count");
        List<string[]> datas = new List<string[]>();
        string num;
        string line;
        for (int i = 0; i < this.count; i++)
        {
            num = "";
            num += i.ToString();
            if (PlayerPrefs.HasKey(num))
            {
                line = PlayerPrefs.GetString(num);
                //Debug.Log("Loading : " + num);
                datas.Add(line.Split(','));
            }
            else
            {
                //Debug.Log("Not found : " + num);
            }
        }
        return datas;
    }

    private string formatLine(string[] line)
    {
        string oneLine = "";
        oneLine = "";
        foreach (string data in line)
        {
            oneLine += data;
            oneLine += ",";
        }
        oneLine = oneLine.TrimEnd(',');
        return oneLine;
    }

    /// <summary>
    /// List<string[]>に含まれるデータを整形してList<string>に投入するメソッド
    /// </summary>
    private List<string> formatLines(List<string[]> datas)
    {
        string oneLine = "";
        List<string> dataLine = new List<string>();
        foreach (string[] line in datas)
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
        return dataLine;
    }
}