using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBall : MonoBehaviour
{
    public float xMomentum;
    public float yMomentum;
    public float power;
    public Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        xMomentum = Random.Range(0.5f, 1f);
        yMomentum = Random.Range(-1f, 1f);
        movement = new Vector3(xMomentum, yMomentum, 0f);
        power = Random.Range(2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(xMomentum, yMomentum, 0f);
        transform.position += movement * power * Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ballHitCollider") || collision.gameObject.CompareTag("Ball"))
        {
            yMomentum *= -1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BallDespawn"))
            Destroy(this.gameObject);
    }
}
