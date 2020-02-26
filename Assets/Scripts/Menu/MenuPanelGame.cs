using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanelGame : MonoBehaviour
{
    [SerializeField] GameObject panelPause;

    bool Pause;

    void Start()
    {
        panelPause.SetActive(false);
        Pause = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & Pause)
        {
            Pause = false;
            Time.timeScale = 1;
            panelPause.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.Escape) & !Pause)
        {
            Pause = true;
            Time.timeScale = 0;
            panelPause.SetActive(true);
        }
    }

    public void ChangePanel(GameObject panel)
    {
        panelPause.SetActive(false);
    }
}
