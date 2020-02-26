using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    //PlayerAttack PlayerAttack;
    //[SerializeField] GameObject attack;
    [SerializeField] Collider2D collider;
    bool canDamage = false;
    [SerializeField] int damage = 0;

    [SerializeField] float cooldownTimer = 0;
    float cooldownTime = 0;

    Vector2 initialPosition;
    Vector2 attackPosition;

   

    [SerializeField] float attackTimer = 0;
    float attackTime = 0;
    void Start()
    {
        collider.enabled = false;
        initialPosition = transform.position;
        attackPosition = new Vector2(transform.position.x + 0.3f, transform.position.y);
    }

    enum AttackState
    {
        NOT_ATTACKING,
        ATTACKING,
        COOLDOWN
    }

    AttackState state = AttackState.NOT_ATTACKING;

    // Update is called once per frame
    void Update()
    {
        
        switch(state)
        {
            case AttackState.NOT_ATTACKING:
                cooldownTime = cooldownTimer;
                attackTime = attackTimer;
                if(Input.GetKeyDown("q"))
                {
                    state = AttackState.ATTACKING;
                }
                break;
            case AttackState.ATTACKING:
                // collider.enabled = true;
                // canDamage = true;
                collider.enabled = true;
                GetComponent<Animation>().Play("spear animation");
               
                //attackTime -= Time.deltaTime;
                //if(attackTime<=0)
                //{
                state = AttackState.COOLDOWN;
                
                break;
            case AttackState.COOLDOWN:
               
                // canDamage = false;
                collider.enabled = false;
                cooldownTime -= Time.deltaTime;
                if(cooldownTime<=0)
                {
                    state = AttackState.NOT_ATTACKING;
                }
                break;
        }

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "enemy")
    //    {
    //        Debug.Log("entered");
    //        Health health;
    //        health = collision.gameObject.GetComponent<Health>();
    //        health.TakeDamage(damage);
            
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("entered");
            Health health;
            health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);

        }
    }
}
