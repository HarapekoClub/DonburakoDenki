using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクター図鑑を管理するクラス
/// </summary>
public class CharacterDictional : MonoBehaviour
{
    [SerializeField] CharacterDB datas;

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

    /// <summary>
    /// 各アイコンの箱を用意するメソッド
    /// </summary>
    public void createDictional()
    {
        GameObject obj;
        for (int i = 0; i < 50; i++)
        {
            obj = (GameObject)Instantiate(Resources.Load("Prefabs/CharacterIconButton"));
            obj.transform.parent = this.transform;
            this.objects.Add(obj);
        }
    }

    /// <summary>
    /// 各アイコンに画像等を挿入するメソッド
    /// </summary>
    public void setCharacterIconButtons()
    {

        CharacterIconButton icon;
        GameObject child;
        count = 1;
        foreach (Transform childTransform in this.transform)
        {
            child = childTransform.gameObject;
            Debug.Log(child.name);
            if (child.GetComponent<CharacterIconButton>() != null)
            {
                icon = child.GetComponent<CharacterIconButton>();
                icon.setParent();
                icon.setCharacter(this.datas.getCharacter(count));
                icon.setIconImages();
                count += 1;

            }
        }
    }


}
