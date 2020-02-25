using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstTarget : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    void Start()
    {
        target = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag=="Player")
    //    {
    //        Debug.Log("stay");
    //        EnemiesMove enemiesMove;
    //        enemiesMove = collision.gameObject.GetComponent<EnemiesMove>();
    //        enemiesMove.GetFirstTarget(target);
    //    }
    //}
}
