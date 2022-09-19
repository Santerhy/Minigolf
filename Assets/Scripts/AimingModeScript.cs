using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AimingModeScript : MonoBehaviour
{
    public BallControll bc;

    public Image aimImage;
    public Text aimText;
    public List<Sprite> sprites;
    public List<string> infoTexts;
    public List<string> buttonTexts;
    public Text aimButton;

    public Text sideTextButton;
    public Text sideText;
    public List<string> sideInfoText;
    public List<string> sideInfoButton;

    public int modeCounter;
    public int sideCounter;
    // Start is called before the first frame update

    public void ChangeMode() {
        modeCounter *= -1;
        UpdateInfo();

    }

    public void ChangeAimSide()
    {
        sideCounter *= -1;
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        if (modeCounter == -1)
        {
            aimText.text = infoTexts[0];
            aimImage.sprite = sprites[0];
            aimButton.text = buttonTexts[0];
            bc.aimFromBall = true;
        } else
        {
            aimText.text = infoTexts[1];
            aimImage.sprite = sprites[1];
            aimButton.text = buttonTexts[1];
            bc.aimFromBall = false;
        }
        if (sideCounter == -1)
        {
            sideTextButton.text = sideInfoButton[0];
            sideText.text = sideInfoText[0];
            bc.aimFromBehind = true;
        } else
        {
            sideTextButton.text = sideInfoButton[1];
            sideText.text = sideInfoText[1];
            bc.aimFromBehind = false;
        }

    }
}
