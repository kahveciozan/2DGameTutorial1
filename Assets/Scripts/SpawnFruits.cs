using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Her bir platform spawn oldugunda bu kod calısacak. Her platformun uzerine ya fruit ya da fruids spawn spawn olacak
public class SpawnFruits : MonoBehaviour
{
    [SerializeField]
    private GameObject oneFruit, fruits;

    [SerializeField]
    private Transform fruitSpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        GameObject newBanana = null;

        if (Random.Range(1, 10) > 2)
            newBanana = Instantiate(oneFruit, fruitSpawnPoint.position, Quaternion.identity);
        else
            newBanana = Instantiate(fruits, fruitSpawnPoint.position, Quaternion.identity);

        newBanana.transform.parent = transform;
    }

}
