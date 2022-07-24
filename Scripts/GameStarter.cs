using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
   [SerializeField] MusicGameManager　mng;
  void Start(){
    if(this.mng == null){
      Debug.Log("Nullpo");
    }
  }
  void OnEnable(){
   if(this.mng == null){
    Debug.Log("Nullpo");
    return;
  }
  this.mng.StartGame();
 }
}
