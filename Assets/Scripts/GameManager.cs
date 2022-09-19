using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] holes;
    public GameObject[] cameraLocations;
    public Camera camera;
    public int holeCounter = 0;

    public GameObject ball;
    public ScoreboardSetup boardSetup;
    public pauseMenu pauseMenu;
    public BallControll bc;
    public SettingsManager settingsManager;

    public BallAnimatorController bac;

    public int[] pars;
    public string[] playerScores;
    public int gameSwings;
    public int currentHoleSwings;

    public Text StrikesText;
    public Text HoleText;

    bool strokeLimit = false;
    private void Awake()
    {
        //Fill players scores for every hole with "-"
        for (int i = 0; i < playerScores.Length; i++)
        {
            playerScores[i] = "-";
        }
    }

    void Start()
    {
        settingsManager = FindObjectOfType<SettingsManager>();
        //Transfer camera and ball to starting hole
        ball.transform.position = new Vector2(holes[holeCounter].transform.position.x, holes[holeCounter].transform.position.y);
        camera.transform.position = new Vector3(cameraLocations[holeCounter].transform.position.x, cameraLocations[holeCounter].transform.position.y, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (strokeLimit)
        {
            if (!bc.moving)
            {
                HoleCleared();
                strokeLimit = false;
            }
        }

    }

    public void HoleCleared()
    {
        if (holeCounter >= 14)
        {
            if (settingsManager.record > gameSwings)
                settingsManager.SetRecord(gameSwings);
            pauseMenu.pauseGame(true, false, true);
        }
        else
        {                                       //Set pausemenu-panel/level cleared- panel to visible
            pauseMenu.pauseGame(true, false, false);      //Make pausing the game disabled for the duration of Level cleared- screen
        }
        StrikesText.enabled = false;
        pauseMenu.ableToPause = false;
    }

    public void NextHole()
    {
        if (holeCounter >=14)
        {
            holeCounter = -1;
            gameSwings = 0;
        }
        StrikesText.enabled = true;
        holeCounter++;
        ball.transform.position = new Vector2(holes[holeCounter].transform.position.x, holes[holeCounter].transform.position.y);
        camera.transform.position = new Vector3(cameraLocations[holeCounter].transform.position.x, cameraLocations[holeCounter].transform.position.y, -10f);
        currentHoleSwings = 0;
        StrikesText.text = "Strikes: 0";
        HoleText.text = "Hole: " + (holeCounter + 1).ToString();
        bac.PlayVisible();
    }

    public void Swing()
    {
        currentHoleSwings++;
        gameSwings++;
        StrikesText.text = "Strokes: " + currentHoleSwings.ToString();
        if (currentHoleSwings >= 12)
            strokeLimit = true;
    }
}
