using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControll : MonoBehaviour
{
    SceneManager sceneManager;
    public GameObject ballPanel;
    public SettingsManager settingsManager;
    public Text recordText;

    private void OnEnable()
    {
        settingsManager = FindObjectOfType<SettingsManager>();
        recordText.text = "Course record: " + settingsManager.record.ToString();
    }
    public void StartGame()
    {
        //settingsManager.SetPlayerSprite();
        SceneManager.LoadScene("Gameplay");
    }

    public void SelectBall()
    {
        this.gameObject.SetActive(false);
        ballPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
