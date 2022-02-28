using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] int health = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if(damageDealer == null) return;
        damageDealer.Hit();
        TakeDamage(damageDealer.GetDamage());
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health > 0) return;
        Destroy(gameObject);
    }
}
