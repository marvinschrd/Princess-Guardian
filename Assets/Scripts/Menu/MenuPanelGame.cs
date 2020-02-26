using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanelGame : MonoBehaviour
{
    [SerializeField] GameObject panelPause;
    [SerializeField] GameObject panelLoose;
    [SerializeField] GameObject panelWin;


    bool Pause;
    [SerializeField] bool end;

    void Start()
    {
        panelPause.SetActive(false);
        panelLoose.SetActive(false);
        panelWin.SetActive(false);
        Pause = false;
        Time.timeScale = 1;
        end = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & Pause & !end)
        {
            Pause = false;
            Time.timeScale = 1;
            panelPause.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.Escape) & !Pause & !end)
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
    public void EndGame()
    {
        end = true;
    }
}
