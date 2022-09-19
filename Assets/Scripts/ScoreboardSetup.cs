using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardSetup : MonoBehaviour
{
    public GameObject holeNumbers;
    public GameObject parNumbes;
    public GameObject playerNumbes;
    public List<GameObject> playerScoresList;

    public float columns;

    public GameManager gameManager;

    public GameObject textFieldPrefab;
    public pauseMenu pauseMenu;

    public Button nextHole;
    public Button quitButton;
    public Text titleText;
    public Text playerScores;

    public bool pauseState = false; //False = pause, true = level end

    public bool endGame;
    private void OnEnable()
    {
        updateScores();
    }

    void Start()
    {
        if (playerScoresList.Count == 0)
            GenerateArrays();
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(bool state, bool gameEnded)
    {
        nextHole.gameObject.SetActive(state);

        if (gameEnded)
        {
            playerScores.gameObject.SetActive(true);
            playerScores.text = "Your strokes: " + gameManager.gameSwings.ToString();
            nextHole.gameObject.GetComponentInChildren<Text>().text = "Restart";
            endGame = true;
        } else
        {
            playerScores.gameObject.SetActive(false);
            nextHole.gameObject.GetComponentInChildren<Text>().text = "Next hole";
            endGame = false;
        }
        //Show Level cleared or Paused according the state
        
        if (state)
        {
            titleText.text = "Hole cleared!";
            updateScores();
        }
        else
            titleText.text = "Paused";
    }

    public void ProceedToNextHole()
    {
        pauseMenu.ableToPause = true;       //Make PauseMenu able to pause the game again
        gameManager.NextHole();             //Proceed to next location
        if (endGame)
        {
            ResetArrays();
            endGame = false;
        }
        pauseMenu.pauseGame(false, false, false);  //Hide panel
    }

    public void updateScores()
    {
        //If Objects are generated, get current swing counter and update it to Canvas
        if (playerScoresList.Count == 0)
            GenerateArrays();
        Text cText = playerScoresList[gameManager.holeCounter + 1].GetComponentInChildren(typeof(Text)) as Text;
        cText.text = gameManager.currentHoleSwings.ToString();
    }

    private void GenerateArrays()
    {
        for (int i = 0; i < columns; i++)
        {
            if (i == 0)
            {
                GameObject textField = Instantiate(textFieldPrefab);
                textField.GetComponentInChildren<Text>().text = "Hole";
                textField.transform.SetParent(holeNumbers.transform);
                textField.transform.localScale = new Vector3(1, 1, 1);

            }
            else
            {
                GameObject textField = Instantiate(textFieldPrefab);
                textField.GetComponentInChildren<Text>().text = i.ToString();
                textField.transform.SetParent(holeNumbers.transform);
                textField.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        for (int i = 0; i < columns; i++)
        {
            GameObject textField = Instantiate(textFieldPrefab);

            if (i == 0)
                textField.GetComponentInChildren<Text>().text = "Par";
            else
                textField.GetComponentInChildren<Text>().text = gameManager.pars[i - 1].ToString();
            textField.transform.SetParent(parNumbes.transform);
            textField.transform.localScale = new Vector3(1, 1, 1);

        }

        for (int i = 0; i < columns; i++)
        {
            GameObject textPref = Instantiate(textFieldPrefab);

            if (i == 0)
                textPref.GetComponentInChildren<Text>().text = "You";
            else
                textPref.GetComponentInChildren<Text>().text = gameManager.playerScores[i - 1];
            textPref.transform.SetParent(playerNumbes.transform);
            textPref.transform.localScale = new Vector3(1, 1, 1);
            playerScoresList.Add(textPref);
        }
    }

    public void ResetArrays()
    {
        for (int i = 1; i < columns; i++)
        {
            playerScoresList[i].GetComponentInChildren<Text>().text = "-";
        }
        Debug.Log("Arrasy cleared");
    }
}
