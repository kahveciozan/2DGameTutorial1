using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float normalPush = 8f;
    public float extraPush = 10f;

    private bool initialPush;
    private int pushCount;
    private bool playerDied;

    private Rigidbody2D myRb;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (playerDied)
            return;

        if (Input.GetAxisRaw("Horizontal") > 0)
            myRb.velocity = new Vector2(moveSpeed, myRb.velocity.y);

        else if (Input.GetAxisRaw("Horizontal") < 0)
            myRb.velocity = new Vector2(-moveSpeed, myRb.velocity.y);
    }

    /* --- Eslesme olursa calis ---- */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerDied)
            return;


        if (collision.tag == "ExtraPush")
        {
            if (!initialPush)
            {
                initialPush = true;
                myRb.velocity = new Vector2(myRb.velocity.x, 20f);
                collision.gameObject.SetActive(false);

                SoundManager.instance.JumpSoundNormalFX();
                
                return;
            }
        }

        if (collision.tag == "NormalPush")
        {
            myRb.velocity = new Vector2(myRb.velocity.x, normalPush);
            collision.gameObject.SetActive(false);
            pushCount++;

            SoundManager.instance.JumpSoundNormalFX();
        }

        if (collision.tag == "ExtraPush")
        {
            myRb.velocity = new Vector2(myRb.velocity.x, extraPush);
            collision.gameObject.SetActive(false);
            pushCount++;

            SoundManager.instance.JumpSoundExtraFX();
        }

        if(pushCount == 2)
        {
            pushCount = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        if( (collision.tag == "FallDown") || (collision.tag == "Enemy") )
        {
            playerDied = true;

            SoundManager.instance.GameOverSoundFX();
            GameManager.instance.RestartGame();

        }

    }
}
