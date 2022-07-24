using UnityEngine;
using System.IO;

public class AudioSourceSetterButton : Button
{
    [SerializeField] AudioSource souce;
    [SerializeField] CharacterDB datas;
    public override void onClick()
    {
        if (this.souce == null)
        {
            return;
        }
        if (this.datas == null)
        {
            return;
        }
        string filename = "AudioSources/M" + this.datas.searchCharacterByStatus(6).getNumberString();
        if (System.IO.File.Exists(Application.dataPath + "/Resources/" + filename + ".wav"))
        {
            this.souce.clip = Resources.Load<AudioClip>(filename);
            Debug.Log("Change Music : " + filename);
        }
        return;
    }
}