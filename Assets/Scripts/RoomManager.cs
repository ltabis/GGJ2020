using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int WaveNbr = 1;
    public bool inDanger = false;
    public float calmTime = 10;
    public int level = 1;

    private float currentCalmTime;
    private int currentWave = 0;
    private GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        currentCalmTime = calmTime;
        spawners = GameObject.FindGameObjectsWithTag("MobSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCalmTime > 0)
            currentCalmTime -= Time.deltaTime;
        if (currentCalmTime <= 0 && currentWave < WaveNbr)
        {
            currentWave += 1;
            SpawnWave(currentWave * level + 3);
            currentCalmTime = calmTime;
        }
    }

    private void SpawnWave(int level)
    {
        for (int i = 0; i < level; i++)
        {
            int spawnerNbr = (int)Random.Range(0, spawners.Length);
            spawners[spawnerNbr].GetComponent<MobSpawnerBehaviour>().Spawn();
        }
    }
}
