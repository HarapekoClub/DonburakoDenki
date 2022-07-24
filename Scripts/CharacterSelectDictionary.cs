using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラ編成画面における図鑑表示を管理するクラス
/// </summary>
public class CharacterSelectDictionary : MonoBehaviour
{
    [SerializeField] CharacterDB datas;
    [SerializeField] int targetStatus;　//編成場所

    private int count;
    private List<GameObject> objects;

    // Start is called before the first frame update
    void Start()
    {
        if (this.objects == null)
        {
            this.objects = new List<GameObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        if (this.objects == null)
        {
            this.objects = new List<GameObject>();
        }
        this.createDictional();
        this.setCharacterIconButtons();
        this.count = 0;
    }

    /// <summary>
    /// アイコンを作成するメソッド
    /// </summary>
    public void createDictional()
    {
        GameObject obj;
        for (int i = 0; i < 50; i++)
        {
            obj = (GameObject)Instantiate(Resources.Load("Prefabs/SelectIconButton"));
            obj.transform.parent = this.transform;
            this.objects.Add(obj);
        }
    }

    /// <summary>
    /// アイコンに画像等を設定するメソッド
    /// </summary>
    public void setCharacterIconButtons()
    {

        CharacterSelectIconButton icon;
        GameObject child;
        count = 1;
        foreach (Transform childTransform in this.transform)
        {
            child = childTransform.gameObject;
            Debug.Log(child.name);
            if (child.GetComponent<CharacterSelectIconButton>() != null)
            {
                icon = child.GetComponent<CharacterSelectIconButton>();
                icon.setParent();
                icon.setCharacter(this.datas.getCharacter(count));
                icon.setIconImages();
                icon.setStatus(this.targetStatus);
                icon.setSelectedCharacter(this.datas.searchCharacterByStatus(this.targetStatus));
                icon.setACButton();
                count += 1;
            }
        }
    }

    public void OnDisable()
    {
        if (this.objects == null)
        {
            return;
        }

        foreach (GameObject obj in this.objects)
        {
            Destroy(obj);
        }

        this.objects = new List<GameObject>();
    }


}