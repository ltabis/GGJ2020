using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AEntity : MonoBehaviour
{
    protected float _life = 0;
    protected float _speed = 0;
    protected float _damage = 0;
    protected float _range = 0;

    // Get the life points of the entity.
    public float Life()
    {
        return _life;
    }

    // Get the damage value of the entity.
    public float Damage()
    {
        return _damage;
    }

    // Get the speed of the entity.
    public float Speed()
    {
        return _speed;
    }

    // Get the attack range of the entity.
    public float Range()
    {
        return _range;
    }

    // Subsctracte damage to the entity.
    public void TakeDamage(float amount)
    {
        if (_life <= amount)
            Debug.Log("Entity " + gameObject.tag + " is dead.");
        else
            _life -= amount;
    }
}