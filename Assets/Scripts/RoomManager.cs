using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int WaveNbr = 1;
    public bool inDanger = false;
    public float calmTime = 10;

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
            Debug.Log("Wave incomming");
            currentWave += 1;
            SpawnWave(3);
        }
    }

    private void SpawnWave(int level)
    {
        int spawnerNbr = (int)Random.Range(0, spawners.Length);
        Debug.Log("Spawn on : " + spawners[spawnerNbr].name);
        spawners[spawnerNbr].GetComponent<MobSpawnerBehaviour>().Spawn();
    }
}
