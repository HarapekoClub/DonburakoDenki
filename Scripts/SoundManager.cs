using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
     //ヒエラルキーからD&Dしておく
    private AudioSource source;
    public bool DontDestroyEnabled = true;
    private string beforeScene;
    public static bool audiocreat=false;

    // Start is called before the first frame update
    void Start()
    {
        //使用するAudioSource取得
        source = GetComponent<AudioSource> ();
        if(!audiocreat){
            DontDestroyOnLoad(this);//遷移しても流し続ける
            audiocreat = true;
            source.Play();

        }
      
        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //シーンが切り替わった時に呼ばれるメソッド
    void OnActiveSceneChanged ( Scene prevScene, Scene nextScene ) 
    {
        //シーンがどう変わったかで判定

        //メニューからメインへ
        if (nextScene.name == "MusicGameScene" && source != null) 
        {
            source.Stop ();
        }

        //メインからメニューへ
        else if (beforeScene ==  "MusicGameScene" && source != null) 
        {
            source.Play ();
        }

        else if(nextScene.name == "TitleScene" && source != null)
        {
            source.Stop ();
        }

        else if(beforeScene ==  "TitleScene" && source != null)
        {
            source.Play ();
        }

        

        //遷移後のシーン名を「１つ前のシーン名」として保持
        beforeScene = nextScene.name;
    }
}
