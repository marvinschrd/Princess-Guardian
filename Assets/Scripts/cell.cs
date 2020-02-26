using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell : MonoBehaviour
{
    [SerializeField] Collider2D collider;
    [SerializeField] Collider2D collider2;
    [SerializeField] Rigidbody2D body;
    [SerializeField] GameObject Cell;

    Vector2 startingPosition;

    [SerializeField] float cellTimer;
    float cellTime;
    bool canFall = true;
    bool fall = false;
    [SerializeField] int cellCounter;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = Cell.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(body.velocity.y==0&&transform.position.y<5)
        {
            Debug.Log("true");
            collider.enabled = true;
            collider2.enabled = true;
            body.bodyType = RigidbodyType2D.Static;
        }

        if(Input.GetKeyDown("e")&&canFall&&cellCounter>0)
        {
            body.gravityScale = 1;
            canFall = false;
            cellTime = cellTimer;
            fall = true;
            cellCounter--;
        }
        if(fall)
        {
            cellTime -= Time.deltaTime;
            if(cellTime<=0)
            {
                Cell.transform.position = startingPosition;
                fall = false;
                canFall = true;
                body.bodyType = RigidbodyType2D.Dynamic;
                body.gravityScale = 0;
                collider.enabled =false;
                collider2.enabled = false;
            }
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("collision" + collision);
    //    if(collision.gameObject.tag=="stop")
    //    {
    //        Debug.Log("true");
    //        collider.enabled = true;
    //        collider2.enabled = true;
    //        body.bodyType = RigidbodyType2D.Static;
    //    }
    //}



}
