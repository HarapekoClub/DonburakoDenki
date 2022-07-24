using UnityEngine;
using UnityEngine.UI;

public class ActivateLines : MonoBehaviour
{

    [SerializeField] GameObject Line1;
    [SerializeField] GameObject Line2;
    [SerializeField] GameObject Line3;
    [SerializeField] GameObject Line4;
    [SerializeField] AudioSource souce;
    [SerializeField] CharacterDB datas;


    void OnEnable()
    {
        this.Line1.SetActive(true);
        this.Line2.SetActive(true);
        this.Line3.SetActive(true);
        this.Line4.SetActive(true);
        //this.Line1.GetComponent<SpriteRenderer>().sprite = this.datas.searchCharacterByStatus(1).getIconImage();
        //this.Line2.GetComponent<SpriteRenderer>().sprite = this.datas.searchCharacterByStatus(2).getIconImage();
        //this.Line3.GetComponent<SpriteRenderer>().sprite = this.datas.searchCharacterByStatus(3).getIconImage();
        //this.Line4.GetComponent<SpriteRenderer>().sprite = this.datas.searchCharacterByStatus(4).getIconImage();

        return;
    }

    void OnDisable()
    {
        this.Line1.SetActive(false);
        this.Line2.SetActive(false);
        this.Line3.SetActive(false);
        this.Line4.SetActive(false);
        this.souce.Stop();
        return;
    }
}