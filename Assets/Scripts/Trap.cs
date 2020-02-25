using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int health;
    PlayerController trap;
    void Start()
    {
        trap = FindObjectOfType<PlayerController>();

    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Health health;
            health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);
            trap.trapDown();
            Destroy(gameObject);
        }
    }
}
