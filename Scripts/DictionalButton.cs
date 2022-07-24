using UnityEngine;

/// <summary>
///　図鑑を開くボタン。
/// </summary>
public class DictionalButton : Button
{
    [SerializeField] GameObject dictionalObject;
    [SerializeField] GameObject scrollObject;
    private int count;

    void Start()
    {
        this.count = 0;
    }

    public override void onClick()
    {
        CharacterDictional dictional = this.dictionalObject.GetComponent<CharacterDictional>();

        dictional.createDictional();
        dictional.setCharacterIconButtons();
        this.scrollObject.SetActive(true);
        this.dictionalObject.SetActive(true);
        this.gameObject.SetActive(false);

        count += 1;
    }
}