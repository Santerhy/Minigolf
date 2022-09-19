using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSwitchScript : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject aimPanel;

    private void OnEnable()
    {
        CloseAimF();
    }
    public void OpenAimF()
    {
        menuPanel.SetActive(false);
        aimPanel.SetActive(true);
    }

    public void CloseAimF()
    {
        aimPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
