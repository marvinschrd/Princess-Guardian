using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [SerializeField] int damage;
   [SerializeField] BoxCollider2D collider;
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
            Debug.Log("entered");
            Health health;
            health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);
            DisableCollider();
        }
    }
  
    public void DisableCollider()
    {
        collider.enabled = false;
    }
}
