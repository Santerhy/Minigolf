using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimatorController : MonoBehaviour
{
    Animator animator;
    public BallControll bc;
    public bool animationGoing = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animationGoing)
        {
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("BallFallAnimation"))
            {
                bc.Respawn();
                animationGoing = false;
                bc.moving = false;
            }
        }
    }

    public void PlayLevelCleared()
    {
        animator.SetBool("BeVisible", false);
        animator.SetTrigger("PlayFallAnimation");
        Debug.Log("FallAnimation");
       //StartCoroutine(SetBeVisible());
    }

    public void PlayVisible()
    {
        animator.SetBool("BeVisible", true);
    }

    public void PlayWaterFall()
    {
        animator.SetBool("BeVisible", false);
        animator.SetBool("WaterFall", true);
        animator.SetTrigger("PlayFallAnimation");
        animationGoing = true;
        bc.moving = true;
        StartCoroutine(SetBeVisible());
    }

    private IEnumerator SetBeVisible()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("BeVisible", true);
        animator.SetBool("WaterFall", false);
    }
}
