﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public PlayerController parentObj;

    // Start is called before the first frame update
    void Start()
    {
        parentObj = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collide: "+ collider.name);
        if (parentObj.isAttacking && collider.gameObject.tag == "enemy")
        {
            Debug.Log("hit enemy");
            int damage = 20;
            if (collider.gameObject.GetComponentInParent<EnemyRxDamage>() != null)
            {
                collider.gameObject.GetComponentInParent<EnemyRxDamage>().DealDamage(parentObj.lanceDamage);
            }
        }
    }

}
