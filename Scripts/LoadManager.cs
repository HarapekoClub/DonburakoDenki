using UnityEngine;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    [SerializeField] GameObject nextPanel;
    [SerializeField] Text textBox;

    private double time;
    private int count;

    private string[] tips =
    {
     "#桃太郎最強,桃太郎かなーやっぱ,自分では思わないんだけど周りには織田信長に似てるって,よく言われる,ちなみに彼女も帰蝶似（聞いてない）",
     "#モモタロウTips,”モモタロウ・トレーニング”,握ったものを刀に変化させる技。,生き物に試すと意識のある刀に変化する。,本人曰く「気味が悪い能力」",
     "#加熱のヤイバー,今週もいい話だった！,新しい仲間はお金がないからあんな行動に出たんだね,俺と一緒に講義を受けて理想の月収700万に☆,LINEを追加してね",
     "ぬおおおおおおおん,もう人間いやだああああああああ,美少女JKになりたいおおおおおおおおおおおおおおおおん",
     "#キャラクター紹介,ワンコロは最高速度マッハ2で走る。",
     "#がきがっきー,給食袋の中には食べきれなかった食パン、嫌いなトマトにおやつとして食べるためのシチューが入っている。",
     "#メンバー紹介,何人かで制作している。あえて一人一人紹介する必要はないはずだ。",
     "#キャラクター紹介,ごずんは声変りにより好きなアニソンを歌えなくなってきたうえ、髭も生えてきてルックスに不安を抱えている。",
     "ホップ・ステップ・ジャンプと言いながら三段跳びをすると三段突きができる気がするんだ。,#新技考案 #剣術",
     "#キャラクター紹介,おーくにーはなかなか家賃を払わない入居者を夜な夜な音響兵器で攻撃したいと考えている。",
     "#キャラクター紹介,ズッキーニ将軍の中の人は夏野旬菜。"
     };

    void Start()
    {
        System.Random random = new System.Random();
        int rand = random.Next() % tips.Length;
        this.setTweet(this.tips[rand]);
        this.time = 0;
    }

    private void setTweet(string msg)
    {
        string[] tweet = msg.Split(',');
        foreach (string line in tweet)
        {
            if (line.Contains("#"))
            {
                this.textBox.text += "<color=#ffa1cd>" + line + "</color>";
            }
            else
            {
                this.textBox.text += line;
            }
            this.textBox.text += "\n";
        }
    }

    void Update()
    {
        this.time += Time.deltaTime;
        if (time > 1)
        {
            count += 1;
            time = 0;
        }
        if (count > 1)
        {
            this.loaded();
            this.time = 0;
            this.count = 0;
        }
    }

    private void loaded()
    {
        this.nextPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }


}