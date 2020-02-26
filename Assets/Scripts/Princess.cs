using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    Vector2 position;
    [SerializeField] float speed;
    Vector2 basePosition;
    [SerializeField] float movingAroundTimer;
    float movingAroundTime;
    float xTarget;
    float yTarget;
    Vector2 newTarget;
    bool choseNewTarget = false;
   [SerializeField] bool moveAround = false;

    [SerializeField] SpriteRenderer exclamation;
    [SerializeField] float waitingTime = 0;
    float waitingTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        basePosition = transform.position;
        exclamation.enabled = false;
    }

    enum State
    {
        NOT_MOVING,
        WAITING_TO_MOVE,
        MOVING_AROUND,
        RETURNING_TO_BASE_LOCATION
    }
    State state = State.NOT_MOVING;

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.NOT_MOVING:
                movingAroundTime = movingAroundTimer;
                waitingTimer = waitingTime;
                choseNewTarget = true;
                if(moveAround)
                {
                    state = State.WAITING_TO_MOVE;
                }
                break;
            case State.WAITING_TO_MOVE:
                exclamation.enabled = true;
                waitingTime -= Time.deltaTime;
                if(waitingTime<=0)
                {
                    state = State.MOVING_AROUND;
                }
                break;
            case State.MOVING_AROUND:
                movingAroundTime -= Time.deltaTime;
                if(choseNewTarget)
                {
                randomTarget();
                }
                if (Vector2.Distance(newTarget, transform.position) > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, newTarget, speed * Time.deltaTime);
                }
                if (Vector2.Distance(newTarget, transform.position) < 0.1f)
                {
                    choseNewTarget = true;
                    randomTarget();
                }
                if(movingAroundTime<=0)
                {
                    state = State.RETURNING_TO_BASE_LOCATION;
                }
                break;
            case State.RETURNING_TO_BASE_LOCATION:
                if (Vector2.Distance(basePosition, transform.position) > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, basePosition, speed * Time.deltaTime);
                }
                if (Vector2.Distance(basePosition, transform.position) < 0.1f)
                {
                    state = State.NOT_MOVING;
                }
                moveAround = false;
                break;
        }
    }
    public Vector2 GivePosition()
    {
        position = new Vector2(transform.position.x, transform.position.y);
        return position;
    }
    void randomTarget()
    {
        xTarget = Random.Range(-4.18f, 4.46f);
        yTarget = Random.Range(3.72f, -4.65f);
        newTarget = new Vector2(xTarget, yTarget);
        choseNewTarget = false;
    }
}
