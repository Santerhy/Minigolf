using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSelect : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    public List<Sprite> sprites = new List<Sprite>();
    public Image selected;
    public Button returnButton;
    public GameObject menuPanel;
    public SettingsManager settingsManager;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int x = i;
            buttons[x].onClick.AddListener(delegate { SwitchImage(x); });
        }
        settingsManager = FindObjectOfType<SettingsManager>();
    }

    public void SwitchImage(int index)
    {
        Debug.Log(index);
        selected.sprite = sprites[index];
    }

    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
        menuPanel.SetActive(true);
        settingsManager.SetPlayerSprite(selected.sprite);
    }
}
