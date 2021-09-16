using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    private int Score =0;
    private int B_ronze =0;
    private int P_lata =0;
    private int O_ro =0;


    public Text scoreText;
    public Text mBronze;
    public Text mPlata;
    public Text mOro;
    
    
    void Start()
    {
        scoreText.text = " Score: " + Score ;
        mBronze.text = "Monedas_Bronce: " + B_ronze;
        mPlata.text = "Monedas_Plata: " + P_lata;
        mOro.text = "Monedas_Oro: " + O_ro;
    }


    public int GetScore()
    {
        return this.Score;
    }

    public void PlusScore(int score)
    {
        this.Score+= score;  
        scoreText.text = " Score: " + Score ;      
    }

    public void paraBronce(int aumento)
    {
        this.B_ronze+= aumento;   
        mBronze.text = "Monedas Bronce: " + B_ronze;     
    }

    public void  paraPlata(int aumento1)
    {
        this.P_lata+= aumento1;  
        mPlata.text = "Monedas Plata: " + P_lata;
    }

    public void ParaOro(int aumento2)
    {
        this.O_ro+= aumento2;
        Debug.Log(O_ro);
        mOro.text = "Monedas Oro: " + O_ro;       
    }
    
}
