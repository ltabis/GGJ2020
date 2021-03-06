﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AEntity : MonoBehaviour
{
    protected float _life = 0;
    protected float _maxLife = 0;
    protected float _shield = 0;
    protected float _maxShield = 0;
    protected float _energy = 0;
    protected float _maxEnergy = 0;
    protected float _speed = 0;
    protected float _damage = 0;
    protected float _range = 0;

    public void AddLife(float amount)
    {
        if (_life + amount <= _maxLife)
            _life += amount;
        else
            _life = _maxLife;
    }
    public void AddShield(float amount)
    {
        if (_shield + amount <= _maxShield)
            _shield += amount;
        else
            _shield = _maxShield;
    }
    public void AddEnergy(float amount)
    {
        if (_energy + amount <= _maxEnergy)
            _energy += amount;
        else
            _energy = _maxEnergy;
    }

    // Get the life points of the entity.
    public float Life()
    {
        return _life;
    }

    public float MaxLife()
    {
        return _maxLife;
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

    // Get the shield of the entity.
    public float Shield()
    {
        return _shield;
    }

    public float MaxShield()
    {
        return _maxShield;
    }

    // Get the energy of the entity.
    public float Energy()
    {
        return _energy;
    }

    public float MaxEnergy()
    {
        return _maxEnergy;
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
            _life = 0;
        else
            _life -= amount;
        GameObject hud = GameObject.Find("HUD");
        if (hud != null)
            hud.GetComponent<HUD>().OnUpdate();
        if (_life == 0)
            Destroy(gameObject);
    }
}