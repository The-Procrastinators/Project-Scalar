using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bullet behaviour now
public class BulletDecay : MonoBehaviour
{
    public float DecayTime = 2f;
    public float Damage = 20f;

    void Update()
    {
        DecayTime -= Time.deltaTime;

        if (DecayTime <= 0f)
        {
            TimerEnd();
        }
    }

    void TimerEnd()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
