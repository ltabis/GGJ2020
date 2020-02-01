﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapyardScumBehavior : AEntity
{
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        _life = 3f;
        _speed = 0.05f;
        _damage = 3f;
        _range = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        IA();
    }

    void IA()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed);
    }
}