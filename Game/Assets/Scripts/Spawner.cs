using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] movingObjs;
    float randY;
    int randItem;
    Vector2 whereToSpawn;
    public float spawnRate = 0.5f;
    float nextSpawn = 0.0f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2(transform.position.x, Random.Range(-3.75f, 3.75f));
            randItem = Random.Range(0, movingObjs.Length);
            Instantiate(movingObjs[randItem], whereToSpawn, Quaternion.identity);
        }
    }
}
