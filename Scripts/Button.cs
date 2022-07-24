using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボタンオブジェクトの雛形
/// </summary>
public abstract class Button : MonoBehaviour
{
    [SerializeField] GameObject gmObject; // GameManagerオブジェクトをアタッチされているGameObject
    GameManager gm; // ゲームマネージャーオブジェクト
    [SerializeField] protected string jumpSceneName = ""; // 次のシーン名。jumpSceneメソッドを使わないなら空欄でおｋ

    // Start is called before the first frame update
    // GameManagerオブジェクトを設定
    void Start()
    {

        if (gmObject == null)
        {
            return;
        }

        this.gm = gmObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void onClick();

    /// <summary>
    /// シーン移動メソッド
    /// GameManagerオブジェクトのメソッドに処理は移譲
    /// </summary>
    public async void jumpScene()
    {
        if (this.jumpSceneName == "") return;
        else
        {
            if (this.gm == null)
            {
                Debug.Log("NullPoinetException at GameManager");
                return;
            }
            await gm.jumpScene(this.jumpSceneName);
            return;
        }
    }

    public async void initializeDatas()
    {
        this.gm.initializeSaveDatas();
        return;
    }
}
