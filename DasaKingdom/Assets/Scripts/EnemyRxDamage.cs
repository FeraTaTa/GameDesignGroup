using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRxDamage : MonoBehaviour
{
    public int health = 0;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
