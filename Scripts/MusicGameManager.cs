/// <summary>
/// 音ゲーの全体管理クラス
/// </summary>
/// 
/// <author>
/// Blacktororo
/// Soyak
/// </author>
/// 
/// <date>
/// created_at:     2021-05-15
/// last_updated:   2021-05-15
/// </date>
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using NoteEditor.DTO;



[System.Serializable]
public class NotesData
{
    public string _name;

    public string _composer;
    public int _bpm;
    public int _notesLine;

    public int _notesType;

}

public class MusicGameManager : MonoBehaviour
{
    private notesScriptGod _nsg;

    public GameObject _startButton;

    public GameObject _zanki;

    public Text _textZanki;

    [SerializeField] Image _ImageReadygo;

    public int _numOfZanki;

    public GameObject[] _notes;

    public GameObject _bridge;

    private GameObject _bridgeobject;

    private int _notesCount = 0;

    private AudioSource _audioSource;

    private AudioSource _ClearSource;
    
    private AudioSource _OverSource;
    
    private AudioSource _AllPerfectSource;

    private string filePath = "JSON/N06";

    private float _startTime;

    private bool _isPlaying = false;

    private bool _isPUIPUINotes = false;

    private bool _isGameOver = false;

    private string fumenjson;

    public MusicDTO.EditData fumen;

    private float _generateNotesTiming;

    private float _finaltiming = 1.1f;


    private int perfect = 0;
    private int great = 0;

    private int good = 0;

    private int bad = 0;
    private int miss = 0;
    
    private List<GameObject> _notesInstances;

    [SerializeField] Text resultTextWin;
    [SerializeField] GameObject resultCanvasWin;
    [SerializeField] Text resultTextLose;
    [SerializeField] GameObject resultCanvasLose;
    [SerializeField] CharacterDB datas;

    [SerializeField] Image character1;
    [SerializeField] Image character2;
    [SerializeField] Image character3;
    [SerializeField] Image character4;

    public ArrayList[] timing = {
        new ArrayList(),
        new ArrayList(),
        new ArrayList(),
        new ArrayList()
        };


    // Start is called before the first frame update
    void Start()
    {
        _textZanki = _zanki.GetComponent<Text>();

        _audioSource = GameObject.FindWithTag("PlayGameMusic").GetComponent<AudioSource>();

        _ClearSource = GameObject.FindWithTag("GameClearSound").GetComponent<AudioSource>();

        _OverSource = GameObject.FindWithTag("GameOverSound").GetComponent<AudioSource>();

        _AllPerfectSource = GameObject.FindWithTag("GamePerfectSound").GetComponent<AudioSource>();



        this.SetJson();

        this.SetAudioSource();

        this.SetCharacterImages();

        Debug.Log(filePath);

        this.fumenjson = Resources.Load<TextAsset>(this.filePath).ToString();

        LoadJson();
        this._notesInstances = new List<GameObject>();

        GenerateNotes();

        _generateNotesTiming = (float)GetGenarateNotesTiming();

    }

    // Update is called once per frame
    void Update()
    {
        cheatMode();
    }


    ///<summary>
    /// ゲーム終了時に起動すべきメソッド
    ///</summary>
    private void GameFinish()
    {
        _bridgeobject.SetActive(false);
        NoteActivate(false);
        // 音楽ストップ
        _audioSource.Stop();


        if (this._isGameOver)
        {
            this.resultTextLose.text = "\n" + this.perfect + "\n" + this.great
                                          + "\n" + this.good + "\n" + this.bad + "\n" + this.miss;

            this.resultCanvasLose.SetActive(true);
            
            //負けBGM
            this._OverSource.Play();
        }
        else if( _notesInstances.Count==perfect && !this._isGameOver)
        {
            this.resultTextWin.text = "\n" + this.perfect + "\n" + this.great
                                          + "\n" + this.good + "\n" + this.bad + "\n" + this.miss;

            this.resultCanvasWin.SetActive(true);
            
            //勝ちBGM
            this._AllPerfectSource.Play();
        }
        else
        {
             this.resultTextWin.text = "\n" + this.perfect + "\n" + this.great
                                          + "\n" + this.good + "\n" + this.bad + "\n" + this.miss;

            this.resultCanvasWin.SetActive(true);
            
            //勝ちBGM
            this._ClearSource.Play();
        }

        
        return;
    }

   

    private void SetJson()
    {
        this.filePath = "JSON/N" + this.datas.searchCharacterByStatus(6).getNumberString();
        return;
    }

    private void SetAudioSource(){
        this._audioSource.clip = Resources.Load<AudioClip>("Music/M" + this.datas.searchCharacterByStatus(6).getNumberString());
        return;
    }

    /// <summary>
    /// ゲームをスタートする
    /// </summary>

    public void StartGame()
    {
        //スタートボタン消える
        _startButton.SetActive(false);
        
       //橋のPrefabを生成
        _bridgeobject = Instantiate<GameObject>(this._bridge,Vector3.zero, Quaternion.identity);


        _ImageReadygo.gameObject.SetActive(true);

        _ImageReadygo.sprite = Resources.Load<Sprite>("Sprites/MusicGame/ready");

        _isPUIPUINotes = true;

        //2秒間待つ関数

        StartCoroutine(DelayMethod(2.0f, "test"));
    }

    /// <summary>
    /// Readyを表示する
    /// </summary>

    private IEnumerator DelayMethod(float delay, string text)
    {
        //delay秒待つ
        yield return new WaitForSeconds(delay);
        /*処理*/

        //_textReadygo.text = "Go!";

        _ImageReadygo.sprite = Resources.Load<Sprite>("Sprites/MusicGame/Go");

        //一秒間待つ

        yield return new WaitForSeconds(1.0f);

        _ImageReadygo.gameObject.SetActive(false);

        //残基表示

        _textZanki.text = "X " + _numOfZanki;

        //スタートタイムに現在の時間を入れる

        _startTime = Time.time;

        //ここで事前に配置されたオブジェクト(ノーツ)をアクティブにする
        NoteActivate(true);


        //Notesが弾くラインに来るまでの時間曲を遅らせる関数呼び出し
        StartCoroutine(FinalTiming(_finaltiming));

    }


    /// <summary>
    /// Jsonファイル(譜面)を読み込む
    /// </summary>
    public void LoadJson()
    {

        fumen = JsonUtility.FromJson<MusicDTO.EditData>(this.fumenjson);
        //Debug.Log("name:  " + fumen.name);
        //Debug.Log("BPM:  " + fumen.BPM);
        //Debug.Log("notestype: "+ fumen.notes[2].num );
        //Debug.Log("notes18 num: " + fumen.notes[17].num);


        for (int i = 0; i < fumen.notes.Count; i++)
        {
            if (fumen.notes[i].line == -1)
            {  
            }
            else if (Digit(fumen.notes[i].line) == 1)
            {       // 桁数が1桁(同時押し無し)
                add(fumen.notes[i].line, fumen.notes[i].timing);

            }
            else if (Digit(fumen.notes[i].line) == 2)
            {       // 桁数が2桁
                add(fumen.notes[i].line / 10, fumen.notes[i].timing);
                add(fumen.notes[i].line % 10, fumen.notes[i].timing);

            }
            else if (Digit(fumen.notes[i].line) == 3)
            {       // 桁数が3桁
                add(fumen.notes[i].line / 100, fumen.notes[i].timing);
                add((fumen.notes[i].line % 100) / 10, fumen.notes[i].timing);
                add((fumen.notes[i].line % 100) % 10, fumen.notes[i].timing);
            }
            else if (Digit(fumen.notes[i].line) == 4)
            {       // 桁数が4桁
                add(1, fumen.notes[i].timing);
                add(2, fumen.notes[i].timing);
                add(3, fumen.notes[i].timing);
                add(4, fumen.notes[i].timing);

            }
        }

    }

    private void add(int linenum, float timingdayo)
    {
        this.timing[linenum - 1].Add(timingdayo + this._finaltiming);
    }


    /// <summary>
    /// ラインの桁数を返す
    /// </summary>
    private int Digit(int num)
    {
        // Mathf.Log10(0)はNegativeInfinityを返すため、別途処理する。
        return (num == 0) ? 1 : ((int)Mathf.Log10(num) + 1);
    }

    //ノーツを流すラインの番号を引数にしてる
    private void GenerateNotes()
    {

        List<int> lineNum = new List<int>();
        List<float> zahyou = new List<float>();
        for(int l=0; l<fumen.notes.Count; l++) {
            if(this.fumen.notes[l].line < 0){
                continue; // 負は無視
            }else if(this.fumen.notes[l].line < 10){
                // 1桁の処理
                lineNum.Add(this.fumen.notes[l].line);
                zahyou.Add((10f) * fumen.notes[l].timing);
            }else if(this.fumen.notes[l].line < 100){
                // 2桁の処理
                lineNum.Add(this.fumen.notes[l].line/10);
                zahyou.Add((10f) * fumen.notes[l].timing);
                lineNum.Add(this.fumen.notes[l].line%10);
                zahyou.Add((10f) * fumen.notes[l].timing);
            }else if(this.fumen.notes[l].line < 1000){
                // 3桁の処理
                lineNum.Add(this.fumen.notes[l].line/100);
                zahyou.Add((10f) * fumen.notes[l].timing);
                lineNum.Add((this.fumen.notes[l].line%100)/10);
                zahyou.Add((10f) * fumen.notes[l].timing);
                lineNum.Add((this.fumen.notes[l].line%10));
                zahyou.Add((10f) * fumen.notes[l].timing);
            }else{
                // 4桁以上の処理
                lineNum.Add(1);
                zahyou.Add((10f) * fumen.notes[l].timing);
                lineNum.Add(2);
                zahyou.Add((10f) * fumen.notes[l].timing);
                lineNum.Add(3);
                zahyou.Add((10f) * fumen.notes[l].timing);
                lineNum.Add(4);
                zahyou.Add((10f) * fumen.notes[l].timing);
            }
        }

        if(zahyou.Count != lineNum.Count)
        {
            Debug.Log("座標に含まれる要素数はLineNumに含まれる要素数に等しくない");
            return;
        }
        

    
        for(int j=0; j<zahyou.Count; j++) 
        { 
            this._notesInstances.Add(Instantiate<GameObject>(_notes[lineNum[j]-1],new Vector3(8.0f + zahyou[j],   -6f + (2.1f * lineNum[j]), 5),Quaternion.identity));
        }
        // 残基決定
        _numOfZanki = zahyou.Count / 3;


    }

    // 全てのノーツのアクティブ状態をを引数の真偽値にする
    private void NoteActivate(bool isActive)
    {
        foreach(GameObject o in this._notesInstances){
            if(o == null){
                continue;
            }
            o.SetActive(isActive);
        }
    }


    /// <summary>
    /// タイミングをずらして音楽を流す
    /// </summary>
    protected IEnumerator FinalTiming(float delaytime)
    {
        yield return new WaitForSeconds(delaytime);

        //音楽流す
        _audioSource.Play();

        //ゲームが始まったためtrueにする
        _isPlaying = true;

        //ここで事前に配置されたオブジェクト(ノーツ)をアクティブにする
        NoteActivate(_isPlaying);
        
    }

    /// <summary>
    /// 残基を減らす
    /// </summary>
    public void DecreamentNumOfZanki()
    {
        this._numOfZanki--;
        _textZanki.text = "X " + _numOfZanki;
        if (this._numOfZanki <= 0)
        {
            this._isGameOver = true;
            this.GameFinish();
        }

    }

    /// <summary>
    /// ノーツは一つ生成する時間を返す
    /// </summary>
    public double GetGenarateNotesTiming()
    {
        return 1.0 / (fumen.BPM / 60.0);
    }

    /// <summary>
    /// 音楽が始まってから経過した時間を返す
    /// </summary>
    public float GetMusicTime()
    {
        return Time.time - this._startTime;
    }

    /// <summary>
    /// 音楽が始まった時間を返す
    /// </summary>

    public float GetStartTime()
    {
        return this._startTime;
    }

    /// <summary>
    /// 音楽が始まってからの時間を返す
    /// </summary>
    public bool IsPlay()
    {
        return this._isPlaying;
    }

    public bool IsGameOver()
    {
        return this._isGameOver;
    }


    public int GetNotesCount()
    {
        return this._notesCount;
    }

    /// <summary>
    /// ファイルパスのセッター
    /// </summary>
    public void SetfilePath(string filePath)
    {
        this.filePath = filePath;
    }

    /// <summary>
    /// ファイルパスのゲッター
    /// </summary>
    public string GetfilePath()
    {
        return this.filePath;
    }


    /// <summary>
    /// ゲームオーバーかどうか判定
    /// </summary>
    public void isGameOver()
    {
        _isGameOver = true;
    }

    /// <summary>
    /// パーフェクト数をインクリメント
    /// </summary>
    public void IncreamentPerfect()
    {
        this.perfect++;
        this.GameClear();
    }

    /// <summary>
    /// パーフェクト数のゲッター
    /// </summary>
    public int GetNumOfPerfect()
    {
        return this.perfect;
    }

    /// <summary>
    /// グレイト数をインクリメント
    /// </summary>
    public void IncreamentGreat()
    {
        this.great++;
        this.GameClear();
    }

    /// <summary>
    /// グレイト数のゲッター
    /// </summary>
    public int GetNumOfGreat()
    {
        return this.great;
    }

    /// <summary>
    /// グッド数をインクリメント
    /// </summary>
    public void IncreamentGood()
    {
        this.good++;
        this.GameClear();
    }

    /// <summary>
    /// グッド数のゲッター
    /// </summary>
    public int GetNumOfGood()
    {
        return this.good;
    }

    /// <summary>
    /// バッド数をインクリメント
    /// </summary>
    public void IncreamentBad()
    {
        this.bad++;
        this.GameClear();
    }

    /// <summary>
    /// バッド数のゲッター
    /// </summary>
    public int GetNumOfBad()
    {
        return this.bad;
    }

    /// <summary>
    /// ミス数をインクリメント
    /// </summary>
    public void IncreamentMiss()
    {
        this.miss++;
        this.GameClear();
    }

    /// <summary>
    /// ミス数のゲッター
    /// </summary>
    public int GetNumOfMiss()
    {
        return this.miss;
    }

    /// <summary>
    /// /// /// /// /// ノーツ数合計値が一致すればゲーム終了
    /// </summary>
    private void GameClear() 
    {
        if((perfect+great+good+bad+miss) == _notesInstances.Count)
        {
            //GameFinish();
            Invoke(nameof(GameFinish),5.0f);
        }
    }

    public void SetCharacterImages(){
        this.character1.sprite = this.datas.searchCharacterByStatus(1).getIconImage();
        this.character2.sprite = this.datas.searchCharacterByStatus(2).getIconImage();
        this.character3.sprite = this.datas.searchCharacterByStatus(3).getIconImage();
        this.character4.sprite = this.datas.searchCharacterByStatus(4).getIconImage();
        return;
    }

    //音楽停止した際に残基が残っていたらゲームクリア
    

    //チートモード 
    private void cheatMode(){
        if(_isPlaying && Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.A)){
            GameFinish();
        }
    }

    
}

