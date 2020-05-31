using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] movingObjs;
    float randY;
    int randItem;
    Vector2 whereToSpawn;
    public float spawnRate = 1f;
    float nextSpawn = 0.0f;
    int[] probability = {0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 0, 1, 3, 4};

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2(transform.position.x, Random.Range(-3.75f, 3.75f));
            randItem = Random.Range(0, probability.Length);
            Instantiate(movingObjs[probability[randItem]], whereToSpawn, Quaternion.identity);
        }
    }
}
