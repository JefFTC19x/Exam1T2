using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGato : MonoBehaviour
{
    public float velocityx = 10;
    public float Salto = 20; 
    public int VecesSalta = 0;   

    private Contador contador;


    private const string Moneda_1 = "MBronze";
    private const string Moneda_2 = "MPlata";
    private const string Moneda_3 = "MOro";



    public GameObject  Bala;
    public GameObject  Bala2;

    private SpriteRenderer sr;    
    private Animator animator;
    private Rigidbody2D rb;
      
    // Variables de Estado
    private const int INI= 0;
    private const int JUMP= 1;    
    private const int RUN= 2;
    private const int SLIDE= 3;
    
     
    private bool Muerto = false;    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator =GetComponent<Animator>();
        changeAnimation(INI);
        contador= FindObjectOfType<Contador>();
    }

    // Update is called once per frame
    void Update()
    {  
        changeAnimation(INI);        
        sr.flipX = false;         
         if(VecesSalta < 2)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                //Saltar
                rb.AddForce(Vector2.up*Salto,ForceMode2D.Impulse); //Salto
                changeAnimation(JUMP);
                VecesSalta +=1;                
            }
        }
        
         if(Input.GetKey(KeyCode.A))
        { 
              //Correr en Reversa
              rb.velocity = new Vector2(-velocityx, rb.velocity.y); 
              sr.flipX = true;
              changeAnimation(RUN);
         }
        if(Input.GetKey(KeyCode.D))
        { 
              //Correr 
              rb.velocity = new Vector2(velocityx, rb.velocity.y); 
              sr.flipX = false;
              changeAnimation(RUN);
        }
        if(Input.GetKey(KeyCode.S))
        { 
              //Slide
              rb.velocity = new Vector2(velocityx, rb.velocity.y); 
              sr.flipX = false;
              changeAnimation(SLIDE);
        }
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        { 
              //Slide
              rb.velocity = new Vector2(-velocityx, rb.velocity.y); 
              sr.flipX = true;
              changeAnimation(SLIDE);
        }      
        if (Input.GetKeyDown(KeyCode.F))
        {
            var bullet = sr.flipX ? Bala2 : Bala;
            var position = new Vector2(transform.position.x,transform.position.y);
            var rotation = Bala.transform.rotation;
            Instantiate(bullet,position,rotation);
        }              
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MBronze"))
        {            
            Destroy(other.gameObject);
            contador.paraBronce(10);
        }
        if(other.gameObject.CompareTag("MPlata"))
        {            
            Destroy(other.gameObject);
            contador.paraPlata(10);
        }
        if(other.gameObject.CompareTag("MOro"))
        {           
            Destroy(other.gameObject);
            contador.ParaOro(10);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Zombi"))
        {            
            velocityx*=0;
             Destroy(this.gameObject);                                   
        }
        if(other.gameObject.CompareTag("suelo"))
        {            
            if(VecesSalta == 2)
            {
                VecesSalta =0;
            }                        
        }  
        if(other.gameObject.CompareTag("Finish"))
        {
            velocityx = 0;
            changeAnimation(INI);
            
        }
    }  
    
    

    private void changeAnimation(int animation)
    {
        animator.SetInteger("CambioM", animation);
    }
}
