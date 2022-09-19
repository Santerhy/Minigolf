using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public SettingsManager sm;

    public GameObject ball;
    public float timeMax;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<SettingsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= timeMax)
        {
            Spawn();
            time = 0f;
        }
        else
            time += Time.deltaTime;
    }

    private void Spawn()
    {
        GameObject obj = Instantiate(ball, this.transform.position, Quaternion.identity);
        obj.gameObject.GetComponent<SpriteRenderer>().sprite = sm.playerSprite;
    }
}
