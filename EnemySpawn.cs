using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public Transform[] EnemySpawnPosition;
    private float hz = 3;
    private float timer = 0;
    public GameObject[] EnemyPrefab;

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= hz)
        {
            timer -= hz;
            int i = Random.Range(0, 3);
            int j = Random.Range(0, 4);
            GameObject.Instantiate(EnemyPrefab[i], EnemySpawnPosition[j].position, EnemySpawnPosition[j].rotation);
        }
	}
}
