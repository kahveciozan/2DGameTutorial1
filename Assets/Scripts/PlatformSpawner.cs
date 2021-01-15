using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public static PlatformSpawner instance;

    [SerializeField]
    private Transform platformParent;

    [SerializeField]
    private GameObject platform;
    public int spawnCount = 8;


    private float leftX_Min = -2.25f, leftX_Max = 2.25f;
    private float tresholdY = 3f;
    private float lastY;

    [SerializeField]
    private GameObject enemy;
    public float enemyY = 5f;
    private float enemyX_Min = -2.3f, enemyX_Max = 2.3f;


    private void Awake()
    {
        if ( instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        lastY = transform.position.y;
        SpawnPlatforms();
    }

    public void SpawnPlatforms()
    {
        Vector2 temporary = Vector2.zero;
        GameObject newPlatform = null;

        for(int i = 0; i< spawnCount; i++)
        {
            temporary.y = lastY;
            temporary.x = Random.Range(leftX_Min, leftX_Max);
            newPlatform = Instantiate(platform, temporary, Quaternion.identity);
            
            // Clon platformlar PlatformParent GameObjectin altinda tutulacak
            newPlatform.transform.parent = platformParent;

            lastY += tresholdY;
        }

        // %50 olasilikla enemy uret
        if(Random.Range(0,2) > 0)
        {
            SpawnEnemy();
        }
            

    }
    void SpawnEnemy()
    {
        Vector2 temporary = transform.position;
        temporary.x = Random.Range(enemyX_Min, enemyX_Max);
        temporary.y += enemyY;

        GameObject newEnemy = Instantiate(enemy, temporary, Quaternion.identity);
        newEnemy.transform.parent = platformParent;
    }
}
