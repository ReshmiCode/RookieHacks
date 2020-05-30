using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] movingObjs;
    float randY;
    int randItem;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(-2f, 2f);
            whereToSpawn = new Vector2(transform.position.x, randY);
            randItem = Random.Range(0, movingObjs.Length);
            Instantiate(movingObjs[randItem], whereToSpawn, Quaternion.identity);
        }
    }
}
