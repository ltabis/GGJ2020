using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnerBehaviour : MonoBehaviour
{
    public GameObject mob;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Spawn()
    {
        GameObject spawn = Instantiate(mob, gameObject.transform.position, gameObject.transform.rotation);
        spawn.transform.SetParent(gameObject.transform);
    }
}
