using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public float speed;
    
    Rigidbody rb; 

    float xInput;
    float yInput;

    int score = 0;
    public int winScore;

    public GameObject victoireText;
    public GameObject livesText;    
    public GameObject timerText;    
    public GameObject defaiteText;   
    public int lives = 3;           
    public float timer = 60f;       


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        UpdateLivesText(); 
        UpdateTimerText();
    }

       
    void Update()
    {
    
    timer -= Time.deltaTime;
    UpdateTimerText(); 

    if (timer <= 0)
    {
        timer = 0;
        GameOver();
    }

    
    if(transform.position.y < -5f)
    {
        LoseLife(); 
    }
}

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");


        rb.AddForce(xInput * speed, 0, yInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Piece")
        {
            other.gameObject.SetActive(false);

            score++;

            if(score >= winScore)
            {
                //gamewin
                livesText.SetActive(false); 
                timerText.SetActive(false); 
                Time.timeScale = 0f;     
                victoireText.SetActive(true);
            }

        }   
    }

    private void LoseLife()
{
    lives--;
    UpdateLivesText();

    if (lives <= 0)
    {
        GameOver(); 
    }
    else
    {
        rb.velocity = Vector3.zero; 
        transform.position = new Vector3(0, 1, 0); 
       
    }
}

private void GameOver()
{
    defaiteText.SetActive(true); 
    livesText.SetActive(false); 
    timerText.SetActive(false); 
    Time.timeScale = 0f;      
}

private void UpdateLivesText()
{
    livesText.GetComponent<TextMeshProUGUI>().text = "Vies: " + lives;
}

private void UpdateTimerText()
{
   timerText.GetComponent<TextMeshProUGUI>().text = "Temps: " + Mathf.Round(timer).ToString();
}

}
