using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMove : MonoBehaviour
{
    [SerializeField] float speed;
    Transform Target;
    Vector3 targetPosition;
    Princess princess;
    Vector2 princessPosition;
    bool canMove = false;

    bool chasePrincess = false;

    bool facingRight = false;
    bool facingLeft = true;

     SpriteRenderer sprite;

    Vector2 startingPosition;

    bool princessIn = false;

    

    void Start()
    {
       // targetPosition = new Vector2(Target.position.x, Target.position.y);
        princess = FindObjectOfType<Princess>();
       checkPositionForFirstTarget();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        if(sprite==null)
        {
            Debug.Log("null");
        }
        
    }

    enum State
    {
        WAITING, //a enlever quand corriger
        CHECKING_START_POSITION,
        MOVING_TO_FIRST_TARGET,
        MOVING_TO_PRINCESS
    }
    State state = State.MOVING_TO_FIRST_TARGET;
    void Update()
    {
        switch(state)
        {
            case State.WAITING:

                break;
            case State.CHECKING_START_POSITION:
                if(canMove)
                {
                    state = State.MOVING_TO_FIRST_TARGET;
                }
                break;
            case State.MOVING_TO_FIRST_TARGET:
                if (Vector2.Distance(targetPosition, transform.position) > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
                //if (Vector2.Distance(targetPosition, transform.position) < 0.1f)
                //{
                //    state = State.MOVING_TO_PRINCESS;
                //}
                if(chasePrincess)
                {
                    state = State.MOVING_TO_PRINCESS;
                }
                break;
            case State.MOVING_TO_PRINCESS:
                princessPosition = princess.GivePosition();
                if (Vector2.Distance(princessPosition, transform.position) > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, princessPosition, speed * Time.deltaTime);
                }
                break;
        }
      
    }

    void checkPositionForFirstTarget()
    {
        if(gameObject.transform.position.x>0&&transform.position.y<0)
        {
            facingLeft = true;
            sprite.flipX = true;
            Debug.Log("true");
            //Target = rightDown;
            //targetPosition = new Vector2(Target.position.x, Target.position.y);
            targetPosition = new Vector2(0, transform.position.y);
        }
        if(transform.position.x>0&&transform.position.y>0)
        {
            facingLeft = true;
            sprite.flipX = true;
            Debug.Log("true");
            //Target = rightUp;
            //targetPosition = new Vector2(Target.position.x, Target.position.y);
            targetPosition = new Vector2(0, transform.position.y);
        }
        if(transform.position.x<0&&transform.position.y>0)
        {
            //Target = leftUp;
            //targetPosition = new Vector2(Target.position.x, Target.position.y);
            targetPosition = new Vector2(0, transform.position.y);
        }
        if(transform.position.x<0&&transform.position.y<0)
        {
            //Target = leftDown;
            //targetPosition = new Vector2(Target.position.x, Target.position.y);
            targetPosition = new Vector2(0, transform.position.y);
        }
        canMove = true;
    }

    public void InRoom()
    {
        chasePrincess = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="princess")
        {
            Debug.Log("princess");
            princess.takeDamage();
        }
    }



}
