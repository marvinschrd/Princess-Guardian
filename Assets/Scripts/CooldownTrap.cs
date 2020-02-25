using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTrap : MonoBehaviour
{
    [SerializeField] Image CoolDown;
    [SerializeField] float actualCooldown;
    bool isCooldown;

    void Start()
    {
        isCooldown = false;
        CoolDown.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
        {
            CoolDown.fillAmount -= 1 / actualCooldown * Time.deltaTime;
        }
        if (CoolDown.fillAmount <= 0)
        {
            isCooldown = false;
        }
    }
    public void cooldownTrapSpawn()
    {
        Debug.Log("Go!");
        isCooldown = true;
        CoolDown.fillAmount = 1;
    }
}
