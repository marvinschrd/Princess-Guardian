using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float colorTimer;
    SpriteRenderer sprite;
    float colorTime;
    bool canColor = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0)
        {
            Destroy();
        }
        if(canColor)
        {
        colorRed();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        colorTime = colorTimer;
        canColor = true;
    }
    void colorRed()
    {
        colorTime -= Time.deltaTime;
        sprite.color = Color.red;
        if(colorTime<=0)
        {
            sprite.color = Color.white;
            canColor = false;
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
