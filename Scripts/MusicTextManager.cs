/// <summary>
/// テキスト表字系クラス
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

public class MusicTextManager : MonoBehaviour
{

    [SerializeField] GameObject perfect1;
    [SerializeField] GameObject perfect2;
    [SerializeField] GameObject perfect3;
    [SerializeField] GameObject perfect4;

    [SerializeField] GameObject great1;
    [SerializeField] GameObject great2;
    [SerializeField] GameObject great3;
    [SerializeField] GameObject great4;

    [SerializeField] GameObject good1;
    [SerializeField] GameObject good2;
    [SerializeField] GameObject good3;
    [SerializeField] GameObject good4;

    [SerializeField] GameObject bad1;
    [SerializeField] GameObject bad2;
    [SerializeField] GameObject bad3;
    [SerializeField] GameObject bad4;

    [SerializeField] GameObject miss1;
    [SerializeField] GameObject miss2;
    [SerializeField] GameObject miss3;
    [SerializeField] GameObject miss4;


    public void DisplayPerfect1() {
        perfect1.SetActive(true);
        Invoke("HidePerfect1",0.1f);
    }

    public void DisplayPerfect2() {
        perfect2.SetActive(true);
        Invoke("HidePerfect2",0.1f);
    }

    public void DisplayPerfect3() {
        perfect3.SetActive(true);
        Invoke("HidePerfect3",0.1f);
    }

    public void DisplayPerfect4() {
        perfect4.SetActive(true);
        Invoke("HidePerfect4",0.1f);
    }

    public void HidePerfect1(){
        perfect1.SetActive(false);
    }

    public void HidePerfect2(){
        perfect2.SetActive(false);
    }

    public void HidePerfect3(){
        perfect3.SetActive(false);
    }

    public void HidePerfect4(){
        perfect4.SetActive(false);
    }




    public void DisplayGreat1() {
        great1.SetActive(true);
        Invoke("HideGreat1",0.1f);
    }

    public void DisplayGreat2() {
        great2.SetActive(true);
        Invoke("HideGreat2",0.1f);
    }

    public void DisplayGreat3() {
        great3.SetActive(true);
        Invoke("HideGreat3",0.1f);
    }

    public void DisplayGreat4() {
        great4.SetActive(true);
        Invoke("HideGreat4",0.1f);
    }

    public void HideGreat1(){
        great1.SetActive(false);
    }

    public void HideGreat2(){
        great2.SetActive(false);
    }

    public void HideGreat3(){
        great3.SetActive(false);
    }

    public void HideGreat4(){
        great4.SetActive(false);
    }




    public void DisplayGood1(){
        good1.SetActive(true);
        Invoke("HideGood1",0.1f);
    }

    public void DisplayGood2(){
        good2.SetActive(true);
        Invoke("HideGood2",0.1f);
    }

    public void DisplayGood3(){
        good3.SetActive(true);
        Invoke("HideGood3",0.1f);
    }

    public void DisplayGood4(){
        good4.SetActive(true);
        Invoke("HideGood4",0.1f);
    }

    public void HideGood1(){
        good1.SetActive(false);
    }

    public void HideGood2(){
        good2.SetActive(false);
    }

    public void HideGood3(){
        good3.SetActive(false);
    }

    public void HideGood4(){
        good4.SetActive(false);
    }




    public void DisplayBad1(){
        bad1.SetActive(true);
        Invoke("HideBad1",0.1f);
    }

    public void DisplayBad2(){
        bad2.SetActive(true);
        Invoke("HideBad2",0.1f);
    }

    public void DisplayBad3(){
        bad3.SetActive(true);
        Invoke("HideBad3",0.1f);
    }

    public void DisplayBad4(){
        bad4.SetActive(true);
        Invoke("HideBad4",0.1f);
    }

    public void HideBad1(){
        bad1.SetActive(false);
    }

    public void HideBad2(){
        bad2.SetActive(false);
    }

    public void HideBad3(){
        bad3.SetActive(false);
    }

    public void HideBad4(){
        bad4.SetActive(false);
    }




    public void DisplayMiss1(){
        miss1.SetActive(true);
        Invoke("HideMiss1",0.1f);
    }

    public void DisplayMiss2(){
        miss2.SetActive(true);
        Invoke("HideMiss2",0.1f);
    }

    public void DisplayMiss3(){
        miss3.SetActive(true);
        Invoke("HideMiss3",0.1f);
    }

    public void DisplayMiss4(){
        miss4.SetActive(true);
        Invoke("HideMiss4",0.1f);
    }

    public void HideMiss1(){
        miss1.SetActive(false);
    }

    public void HideMiss2(){
        miss2.SetActive(false);
    }

    public void HideMiss3(){
        miss3.SetActive(false);
    }

    public void HideMiss4(){
        miss4.SetActive(false);
    }





    




}
