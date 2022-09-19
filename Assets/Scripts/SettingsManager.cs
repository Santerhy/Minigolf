using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;
    public Sprite playerSprite;
    //public BallSelect bs;
    public int record;
    string recordParameter = "RecordParameter";

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        record = PlayerPrefs.GetInt(recordParameter, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerSprite(Sprite sprite)
    {
        playerSprite = sprite;
        Debug.Log("playersprite set");
    }

    public Sprite GetPlayerSprite()
    {
        return playerSprite;
    }

    public void SetRecord(int score)
    {
        PlayerPrefs.SetInt(recordParameter, score);
    }
}
