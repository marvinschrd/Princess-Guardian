using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="enemy")
        {
            EnemiesMove enemiesMove;
            enemiesMove = collision.gameObject.GetComponent<EnemiesMove>();
            enemiesMove.GetFirstTarget(gameObject.transform);
        }
    }
}
