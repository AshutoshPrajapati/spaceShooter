using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float min_x = -3f, max_x = 3f;

    public GameObject[] astroid_Prefeb;
    public GameObject enemy_prefeb;
    public float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies", timer);
    }

    void SpawnEnemies()
    {
        float pos_x = Random.Range(min_x, max_x);
        Vector3 temp = transform.position;
        temp.x = pos_x;

        if (Random.Range(1, 3) > 1)
        {
            Instantiate(astroid_Prefeb[Random.Range(0, astroid_Prefeb.Length)], temp, Quaternion.identity);
        }
        else
        {
            Instantiate(enemy_prefeb, temp, Quaternion.Euler(0f, 0f,180f));
        }
        Invoke("SpawnEnemies", timer);
    }
}
