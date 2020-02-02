using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapyardScumBehavior : AEntity
{
    private GameObject target;
    public bool isStop = false;
    public float stunning = 1;
    private float currentStunning;

    private float hitCooldown = 0.2f;
    private float lastHitTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        _life = 3f;
        _speed = 0.05f;
        _damage = 3f;
        _range = 2f;
        currentStunning = stunning;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStop)
        {
            currentStunning -= Time.deltaTime;
            if (currentStunning <= 0)
            {
                isStop = false;
                currentStunning = stunning;
            }
        }
        IA();
    }

    void IA()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target != null && !isStop)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        lastHitTime -= Time.deltaTime;
        if (collision.gameObject.tag == "Player" && lastHitTime <= 0)
        {
            Hit(collision.gameObject);
        }
    }

    public void Hit(GameObject target)
    {
        target.GetComponent<AEntity>().TakeDamage(_damage);
        lastHitTime = hitCooldown;
    }
}
