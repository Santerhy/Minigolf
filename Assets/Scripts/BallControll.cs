using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    public GameManager gameManager;
    public Audiomanager audiomanager;
    public BallAnimatorController bac;
    public SettingsManager settingsmanager;

    public Vector3 initialMousePos;
    public Vector3 currentMousePos;
    public Vector2 lastPosition;

    Rigidbody2D rb;
    public bool aiming = false;
    public bool moving = false;
    public bool inSand = false;
    public bool inMenu = false;
    public bool buttonPressed;
    public bool startPosGet;
    bool respawning = false;

    public bool aimFromBall = true;
    public bool aimFromBehind = true;

    public float shootForce;
    public float distance;          //Used and updated by distance
    public float realDistance;   //Real disntance calculated

    public Vector2 dir;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        settingsmanager = FindObjectOfType<SettingsManager>();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = settingsmanager.GetPlayerSprite();        
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inMenu)
        {
            if (!moving)
            {
                if (Input.GetMouseButton(0))
                {
                    if (startPosGet)
                    {
                        if (aimFromBall)
                            initialMousePos = transform.position;
                        else
                            initialMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        startPosGet = false;
                    }
                    aiming = true;
                    rb.velocity = Vector3.zero;
                    buttonPressed = true;
                } else
                {
                    aiming = false;
                }

                if (aiming)
                {
                    currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    CalcDirection();
                }

                if (Input.GetMouseButtonUp(0) && distance > 0f && buttonPressed)
                {
                    aiming = false;
                    Shoot();
                    buttonPressed = false;
                    startPosGet = true;
                } else if (Input.GetMouseButtonDown(0) && buttonPressed)
                {
                    aiming = false;
                    buttonPressed=false;
                    startPosGet = true;
                }
            }
        }

        speed = rb.velocity.magnitude;

        if (speed < 0.5f)
            rb.velocity = Vector2.zero;

        if (speed > 0.9f)
            moving = true;
        else
            moving = false;

    }

    private void Shoot()
    {
        lastPosition = transform.position;

        rb.AddForce(dir * distance * shootForce, ForceMode2D.Impulse);
        initialMousePos = Vector3.zero;
        currentMousePos = Vector3.zero;
        gameManager.Swing();
    }

    private void CalcDirection()
    {
        if (initialMousePos.z != -10f)
            initialMousePos.z = -10f;
        realDistance = Vector3.Distance(initialMousePos, currentMousePos);
        if (realDistance > 16f)
            distance = 16f;
        else if (realDistance < 0.5f)
            distance = 0f;
        else
            distance = realDistance;
        if (aimFromBehind)
            dir = (initialMousePos - currentMousePos).normalized;
        else
            dir = (currentMousePos - initialMousePos).normalized;
    }

    public void Respawn()
    {
        rb.velocity = Vector2.zero;
        transform.position = new Vector2(lastPosition.x, lastPosition.y);
        respawning = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hole") && speed < 10 && !respawning)
        {
            Debug.Log("HoleFound");
            rb.velocity = Vector2.zero;
            audiomanager.playHole();
            audiomanager.playClapping();
            gameManager.HoleCleared();
            bac.PlayLevelCleared();
        }
        else if (collision.CompareTag("Sand"))
        {
            inSand = true;
            rb.drag = 6f;
        }
        if (collision.CompareTag("Water") && !respawning)
        {
            respawning = true;
            audiomanager.playWater();
            bac.PlayWaterFall();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sand"))
        {
            inSand = false;
            rb.drag = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ballHitCollider"))
            audiomanager.playWall();
    }
}
