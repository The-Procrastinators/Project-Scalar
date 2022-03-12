using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
    //floats
    public float GrenadeFuse;
    public float Damage;
    public float TravelTime;

    void Start()
    {
        GrenadeFuse = 3f;
        TravelTime = 0.25f;
    }

    void Update()
    {
        FuseTimer();
        TravelTimer();
    }

    //Fuse lasts for 3 seconds
    void FuseTimer()
    {
        GrenadeFuse -= Time.deltaTime;
        if (GrenadeFuse <= 0f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Debug.Log("Exploded");
        Destroy(gameObject);
    }

    void TravelTimer()
    {
        TravelTime -= Time.deltaTime;
        if (TravelTime <= 0f)
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero; rb.angularVelocity = 0;
        }
    }
}
