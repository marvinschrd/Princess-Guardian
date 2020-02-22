using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    [SerializeField]float speed;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] Collider2D attackCollider;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        attackCollider.enabled = false;
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
    }
}
