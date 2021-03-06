﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    [SerializeField]float speed;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] Collider2D attackCollider;

    //provisoir
    [SerializeField] private Transform[] spawn;
    [SerializeField] GameObject trap;
    [SerializeField] int actualCooldown;
    bool trapspawned;
    CooldownTrap cooldownTrap;

    bool facingRight = false;
    bool facingLeft = true;
    float horizontalSpeed;
    Animator anim;

    int count;
        //provisoir

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        attackCollider.enabled = false;
        cooldownTrap = FindObjectOfType<CooldownTrap>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical")*speed);
        if(Input.GetKeyDown("q"))
        {
            attackCollider.enabled = true;
        }
        horizontalSpeed = Input.GetAxis("Horizontal");
       
        if (horizontalSpeed > 0 && !facingLeft)
        {
           
            facingLeft = true;
            facingRight = false;
            anim.transform.Rotate(0, 180, 0);
        }
        if (horizontalSpeed < 0 && !facingRight)
        {
           
            facingRight = true;
            facingLeft = false;
            anim.transform.Rotate(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !trapspawned)
        {
            if (count <= 2)
            {
                GameObject invocation = Instantiate(trap, transform.position, Quaternion.identity);
                count++;
            }
        }
    }
    public void trapDown()
    {
        count--;
    }
    /*public IEnumerator cooldown()
    {
        if (count <= 2)
        {
            GameObject invocation = Instantiate(trap, transform.position, Quaternion.identity);
            count++;
        }
        if (count >= 3)
        {
            trapspawned = true;
            cooldownTrap.cooldownTrapSpawn();
            yield return new WaitForSeconds(actualCooldown);
            trapspawned = false;
        }
        
    }*/
}
