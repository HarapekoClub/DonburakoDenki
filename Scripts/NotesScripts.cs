/// <summary>
/// ノーツを移動させる
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

public class NotesScripts : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        //
    }

    // Update is called once per frame
    void Update() {
        // 常に左に動くよ
        this.transform.position -= transform.right * 10f * Time.deltaTime;
        // -8.0fになるとノーツを破壊する
         if (this.transform.position.x < -6.0f) {
            // Debug.Log("MISS!!");
            // ノーツを消し去る
             Destroy (this.gameObject);
            // ここでミス判定をするメソッドを入れる
            }
    }

}
