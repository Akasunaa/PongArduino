using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaaaaaa : MonoBehaviour
{
    Rigidbody2D rb2d;
        void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();   
        GoBall();
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(200, -150));
        }
        else
        {
            rb2d.AddForce(new Vector2(-200, -150));
        }
    }

}
