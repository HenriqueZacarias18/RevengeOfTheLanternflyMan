using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;

    private bool allowRespawnOnRoomLeave = false;

    private void Start()
    {
        if (transform.parent.GetComponent<ResetOnRoomReenter>())
        {
            allowRespawnOnRoomLeave = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            health -= damageDealer.damage;
            if(health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if (deathEffect)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
        if (allowRespawnOnRoomLeave)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
