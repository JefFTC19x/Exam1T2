using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public float velocityx = 6;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = false;
    }

    void Update()
    {
         rb.velocity = new Vector2(velocityx,rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("Limite"))
        {
            rb.velocity = new Vector2(velocityx, rb.velocity.y);
            velocityx *= -1;

            if(sr.flipX == false)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }

        
    }
}