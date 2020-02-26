using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomTrigger : MonoBehaviour
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
        Debug.Log("trigger");
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("room");
            EnemiesMove ennemy;
            ennemy = collision.gameObject.GetComponent<EnemiesMove>();
            ennemy.InRoom();
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "enemy")
    //    {
    //        Debug.Log("room");
    //        EnemiesMove ennemy;
    //        ennemy = collision.gameObject.GetComponent<EnemiesMove>();
    //        ennemy.InRoom();
    //    }
    //}

}
