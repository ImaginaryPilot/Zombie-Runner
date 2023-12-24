﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10f;
    void Start()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        print(health);
        if (health <= 0)
        {
            var deadscreenobject = FindObjectOfType<DeathHandler>();
            deadscreenobject.HandleDeath();
        }
    }
}
