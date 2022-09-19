using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitSpeedFiller : MonoBehaviour
{
    public float meterMax = 17f;
    public Image filler;

    public BallControll bc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bc.aiming)
        {
            filler.fillAmount = bc.distance / meterMax;
        }
        else
            filler.fillAmount = 0f;
    }
}
