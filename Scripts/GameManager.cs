using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] CharacterDB datas;
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("I am Game Manager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 指定のシーンがあればCSV情報を更新してシーン遷移する
    /// </summary>
    public async Task jumpScene(string jumpSceneName)
    {
        if (jumpSceneName == "")
        {
            Debug.Log("Missed.");
            return;
        }
        if (this.datas == null)
        {
            return;
        }
        this.sceneName = jumpSceneName;
        //await this.datas.updateCSV();
        //if (File.Exists(Application.dataPath + "/Resources/CSVFiles/" + "charaFlag"))
        if (!PlayerPrefs.HasKey("charaFlag"))
        {
            //File.Delete(Application.dataPath + "/Resources/CSVFiles/" + "charaFlag");
            PlayerPrefs.SetString("charaFlag", "True");
        }
        this.datas.dataSave();
        SceneManager.LoadScene(this.sceneName);

        return;
    }

    public async Task initializeSaveDatas()
    {
        //if (File.Exists(Application.dataPath + "/Resources/CSVFiles/" + "charaFlag"))
        if (!PlayerPrefs.HasKey("charaFlag"))
        {
            return;
        }
        else
        {
            PlayerPrefs.DeleteKey("charaFlag");
            //File.Create(Application.dataPath + "/Resources/CSVFiles/" + "charaFlag");
            Debug.Log("SHOKI KA KANRYOU");
            this.datas.enableTask();
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
#endif
    }

}
