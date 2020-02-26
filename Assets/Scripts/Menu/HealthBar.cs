using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxHealth;

    public Image healthBarImage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBarImage.fillAmount = health / maxHealth;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health < 0)
        {
            health = 0;
        }
    }
    public void HealthAmount()
    {
        health--;
    }
}
