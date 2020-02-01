using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScumBehavior : AEntity
{
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 0.03f;
        _range = 6f;
        _life = 2f;
        _damage = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        IA();
    }

    void IA()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            if (Vector3.Distance(target.transform.position, transform.position) >= _range)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _speed);
            }
            else
            {
                // shoot
            }
        }
    }
}
