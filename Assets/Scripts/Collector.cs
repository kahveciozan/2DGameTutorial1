using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BackGround" || collision.tag =="Platform" || collision.tag=="NormalPush" 
           || collision.tag == "ExtraPush" || collision.tag == "ExtraPush" || collision.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
