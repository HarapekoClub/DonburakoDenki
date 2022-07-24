using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpButton : Button
{
    private Button toHomeButton;
    private Button acButton;
    // Start is called before the first frame update
    void Start()
    {
        this.toHomeButton = this.gameObject.GetComponent<ToHomeButton>();
        this.acButton = this.gameObject.GetComponent<ActiveChangeButton>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void onClick()
    {
        if (PlayerPrefs.HasKey("started"))
        {
            PlayerPrefs.DeleteKey("started");
            this.toHomeButton.onClick();
        }
        else
        {
            PlayerPrefs.SetString("started", "True");
            Debug.Log("Opening Movie play");
            this.acButton.onClick();
        }
    }
}
