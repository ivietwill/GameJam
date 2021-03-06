using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float health = 100;

    public int worth = 45;

    public GameObject deathEffect;

    public Transform rotatingGobs;

    void Start()
    {
        speed = startSpeed;
    }


      void Die()
    {
        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
        Destroy(gameObject);
    }

    
    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }

}
