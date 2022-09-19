using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    bool paused = true;
    public GameObject pausePanel;
    public GameObject aimPanel;
    public ScoreboardSetup scoreboardSetup;
    public BallControll bc;
    public bool ableToPause = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ableToPause)
            pauseGame(false, true, false);
    }

    public void pauseGame(bool scoreBoardState, bool pauseGame, bool gameEnded)
    {
        if (pauseGame)
        {
            if (paused)
            {
                Time.timeScale = 0;
                paused = !paused;
                //pausePanel.SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                paused = !paused;
                aimPanel.gameObject.SetActive(false);
                //pausePanel.SetActive(false);
            }
        }
            ShowPanel(scoreBoardState, gameEnded);

    }

    private void ShowPanel(bool scoreBoardState, bool gameEnded)
    {
        if (pausePanel.gameObject.activeInHierarchy)
        {
            pausePanel.gameObject.SetActive(false);
            bc.inMenu = false;
        }
        else
        {
            pausePanel.gameObject.SetActive(true);
            bc.inMenu = true;
        }
        scoreboardSetup.SetState(scoreBoardState, gameEnded);

        /*
        if (pauseGame) //Determine if player is able to shoot or not
            bc.inMenu = true;
        else
            bc.inMenu = false;
        */

    }
}
