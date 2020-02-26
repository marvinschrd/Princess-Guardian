using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameRuler : MonoBehaviour
{
    [SerializeField]InvokerManager invoker;
    [SerializeField] Princess princess;

    int superStrongProbability = 0;
    int strongProbability = 0;
    int fastProbability = 0;

    float timer;

    float princessWanderingTimer = 20f;
    float princessWanderingTime;
    int randomResult = 0;
    int princessProbability = 2;
    // Start is called before the first frame update
    void Start()
    {
        princessWanderingTime = princessWanderingTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer==45)
        {
            invoker.FastProbabilty(fastProbability);
        }
        if(timer==90)
        {
            invoker.StrongProbabilty(strongProbability);
        }
        if(timer==135)
        {
            invoker.SuperStrongProbabilty(superStrongProbability);
            princessProbability = 1;
        }

        princessWanderingTime -= Time.deltaTime;
        if(princessWanderingTime<=0)
        {
            randomResult = Random.Range(0, 2);
            if(randomResult==0)
            {
            princess.WanderingActivation();
            }
            Princess();
        }
    }

    void Princess()
    {
        princessWanderingTime = princessWanderingTimer;
    }
}
