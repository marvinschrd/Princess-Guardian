using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMove : MonoBehaviour
{
    [SerializeField] Vector2 targetPosition;
    [SerializeField] int speed;

    void Start()
    {
        
    }


    void Update()
    {
        if (Vector2.Distance(targetPosition, transform.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
