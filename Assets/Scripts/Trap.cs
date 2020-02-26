using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int health;
    PlayerController trap;

    Animator animator_;

    Health ennemyHealth;

    void Start()
    {
        trap = FindObjectOfType<PlayerController>();
        animator_ = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            animator_.SetBool("Activate", true);
           
            ennemyHealth = collision.gameObject.GetComponent<Health>();
        }
    }
    public void TrapDamage()
    {
        ennemyHealth.TakeDamage(damage);
        trap.trapDown();
        Destroy(gameObject, 1f);
    }
}
