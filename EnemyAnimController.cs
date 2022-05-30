using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    Animator playerAnimate;
    Rigidbody2D rb;
    SpriteRenderer sr;
    int randomNumber;

    float time;
    float timeDelay;




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimate = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        time = 0f;
        timeDelay = 0.2f;
    }
    // Update is called once per frame
    void Update()
    {

        NoteHitAnim();
        NoteMissAnim();

    }

    void NoteHitAnim()
    {
        if (GameManager.instance.checkHit == true)
        {
            randomNumber = Random.Range(1, 3);
            playerAnimate.SetInteger("JuniperStage", randomNumber);
            time = time + 1f * Time.deltaTime;

            if (time >= timeDelay)
            {
                time = 0f;
                GameManager.instance.checkHit = false;
                playerAnimate.SetInteger("JuniperStage", 0);
            }

        }

    }

    void NoteMissAnim()
    {
        if (GameManager.instance.checkMiss == true)
        {
            randomNumber = Random.Range(1, 3);
            playerAnimate.SetInteger("JuniperStage", 4);
            time = time + 1f * Time.deltaTime;

            if (time >= timeDelay)
            {
                time = 0f;
                GameManager.instance.checkMiss = false;
                playerAnimate.SetInteger("JuniperStage", 0);
            }

        }
    }
}
