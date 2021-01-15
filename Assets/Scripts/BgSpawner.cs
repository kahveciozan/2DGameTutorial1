using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawner : MonoBehaviour
{
    private GameObject[] bgs;
    private float height;
    private float highestY_Pos;

    private void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag("BackGround");
    }

    // Start is called before the first frame update
    void Start()
    {
        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;
        highestY_Pos = bgs[0].transform.position.y;

        // En yuksek BackGround nesnesinin orta noktasini karsilastirarak buluyoruz
        for(int i= 1; i<bgs.Length; i++)
        {
            if (bgs[i].transform.position.y > highestY_Pos)
                highestY_Pos = bgs[i].transform.position.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Herhangi bir BackGround objesinin sınırlarına dokunulursa
        if(collision.tag == "BackGround")
        {
            if(collision.transform.position.y >= highestY_Pos)
            {
                Vector3 temporary = collision.transform.position;       //highest positon y gecici degeri

                for(int i=0; i < bgs.Length; i++)
                {
                    if (!bgs[i].activeInHierarchy)
                    {
                        temporary.y += height;                          //new highest position y gecisi degeri
                        bgs[i].transform.position = temporary;
                        bgs[i].gameObject.SetActive(true);

                        highestY_Pos = temporary.y;
                    }
                }
            }
        }
    }
}
