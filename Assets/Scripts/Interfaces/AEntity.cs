using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AEntity : MonoBehaviour
{
    private float _life;
    private float _speed;
    private float _damage;
    private float _range;

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