﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat3 : MonoBehaviour
{
   // 曲のタイミングデータを宣言
    private static ArrayList _timing;

    // 音符のインデックスを宣言。
    private int _indexTiming    = 0;
    private float _timer        = 0;
    private float _start        = 0;
    private MusicGameManager _mgm;
    private MusicTextManager _mTm;

    private AudioSource _tapMusicSource;
    // Start is called before the first frame update
    void Start() {
        this._mgm = GameObject.FindWithTag("MusicGameManager").GetComponent<MusicGameManager>();
        this._mTm = GameObject.FindWithTag("MusicTextManager").GetComponent<MusicTextManager>();
        this._tapMusicSource = GameObject.FindWithTag("GameTapMusic").GetComponent<AudioSource>();
        _timer = 0;
    }

    // Update is called once per frame
    void Update() {

         _timer = Time.time - _start;

        if(_timing==null || !_mgm.IsPlay()) {
            _start = _mgm.GetStartTime();
            _timing = this._mgm.timing[2];
        } else if(_indexTiming < _timing.Count) {
            if(IsBeat()) {
                //Debug.Log("[ISB]indextiming: "+_indexTiming);
                checkTiming();
            }
            else if((_timer - (float)_timing[_indexTiming])-0.31f >= 0.4f) { // 通り過ぎたミス
                _mgm.DecreamentNumOfZanki(); // 残機減らす
                _indexTiming++;
                //// Debug.Log("[Beat3]通り過ぎた！");

                _mTm.DisplayMiss3();
                _mgm.IncreamentMiss();
            }
        }
        
    }

    public bool IsBeat() {
        if (Input.GetKeyDown(KeyCode.F)){
            _tapMusicSource.Play();
            return true;
        }
        else
            return false;
    }

    public void checkTiming() {
        //Debug.Log("timer: "+_timer+",index: "+_indexTiming+",timing: "+(float)_timing[_indexTiming]);
        //Debug.Log(_timer - (float)_timing[_indexTiming]);

        float userTiming = (float)_timing[_indexTiming];

        if(Mathf.Abs(_timer - userTiming)-0.31f <= 0.03f) {
            //Debug.Log("[Beat3]PERFECCCCCCCCCT判定\ntimer: "+_timer+",index: "+_indexTiming+",timing: "+userTiming);
            _indexTiming++;
            _mgm.IncreamentPerfect();

            _mTm.DisplayPerfect3();
        }
        else if(Mathf.Abs(_timer - userTiming)-0.31f <= 0.1f) {
            //Debug.Log("[Beat3]GREAT判定\ntimer: "+_timer+",index: "+_indexTiming+",timing: "+userTiming);
            _indexTiming++;
            _mgm.IncreamentGreat();

            _mTm.DisplayGreat3();
        }
        else if(Mathf.Abs(_timer - userTiming)-0.31f <= 0.2f) {
            //Debug.Log("[Beat3]GOOD判定\ntimer: "+_timer+",index: "+_indexTiming+",timing: "+userTiming);
            _indexTiming++;
            _mgm.IncreamentGood();

            _mTm.DisplayGood3();
        }
        else if(Mathf.Abs(_timer - userTiming)-0.31f <= 0.4f) {
            //Debug.Log("[Beat3]BAD判定\ntimer: "+_timer+",index: "+_indexTiming+",timing: "+userTiming);
            // 残機減らす
            _mgm.DecreamentNumOfZanki();
            _indexTiming++;
            _mgm.IncreamentBad();

            _mTm.DisplayBad3();
        } else {
            //Debug.Log("[Beat3]今押しても意味がないよ...\ntimer: "+_timer+",index: "+_indexTiming+",timing: "+userTiming);
        }

    }

    
}
