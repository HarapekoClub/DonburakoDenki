using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// 音ゲパートの仮機能として置いとこうかなと。
/// </summary>
public class MusicGameManagerKali : MonoBehaviour
{
    [SerializeField] GameObject wining; // 勝利時に起動するボタン
    [SerializeField] GameObject losing; // 敗北時に起動するボタン

    /// <summary>
    /// ゲーム終了時に呼び出すメソッド。引数がなければランダムで勝敗判定。
    /// </summary>
    public void gameFinish()
    {
        if (this.resultCheck())
        {
            this.wining.GetComponent<ActiveChangeButton>().onClick();
        }
        else
        {
            this.losing.GetComponent<ActiveChangeButton>().onClick();
        }
        return;
    }

    /// <summary>
    /// ゲーム終了時に呼び出すメソッド。引数はboolでTrueは勝利、Falseは敗北。
    /// </summary>
    public void gameFinish(bool result)
    {
        if (result)
        {
            this.wining.GetComponent<ActiveChangeButton>().onClick();
        }
        else
        {
            this.losing.GetComponent<ActiveChangeButton>().onClick();
        }
        return;
    }

    /// <summary>
    /// 乱数でTrueかFalseを返すメソッド
    /// </summary>
    public bool resultCheck()
    {
        int seed = Environment.TickCount;
        System.Random randMaker = new System.Random(seed);
        int rand = randMaker.Next(0, 99);
        if (rand % 2 == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}