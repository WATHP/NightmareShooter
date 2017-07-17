using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject enemyPrefab;
    public float spawnTime = 3;
    private float timer = 0;

    void Start()
    {
        InvokeRepeating("ACC", 0, 1);
    }

    void ACC()
    {
        spawnTime -= 0.05f;
    }

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            timer -= spawnTime;
            SpawnEnemy();
        }
	}

    void SpawnEnemy()
    {
        GameObject.Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
