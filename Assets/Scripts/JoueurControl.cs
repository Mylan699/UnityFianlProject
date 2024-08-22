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
    public GameObject livesText;    // GameObject pour afficher les vies
    public GameObject timerText;    // GameObject pour afficher le compte à rebours
    public GameObject defaiteText;   // GameObject de défaite
    public int lives = 3;           // Nombre de vies du joueur
    public float timer = 60f;       // Temps du compte à rebours


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        UpdateLivesText(); // Initialiser le texte des vies
        UpdateTimerText();
    }

       // Update is called once per frame
    void Update()
    {
    // Compte à rebours
    timer -= Time.deltaTime;
    UpdateTimerText(); 

    if (timer <= 0)
    {
        timer = 0;
        GameOver();
    }

    // Vérifier si le joueur est tombé
    if(transform.position.y < -5f)
    {
        LoseLife(); // Appelle la méthode pour gérer la perte de vie et la réinitialisation de la position
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
                livesText.SetActive(false); // Masquer le texte des vies
                timerText.SetActive(false); // Masquer le texte du timer
                Time.timeScale = 0f;      // Arrêter le temps de jeu
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
        GameOver(); // Défaite si plus de vies
    }
    else
    {
        rb.velocity = Vector3.zero; // Remettre la vitesse à zéro
        transform.position = new Vector3(0, 1, 0); // Replace la balle au centre (ou ajustez selon votre besoin)
        // Assurez-vous que cette position est le point de spawn initial de votre balle
    }
}

private void GameOver()
{
    defaiteText.SetActive(true); // Afficher le message de défaite
    livesText.SetActive(false); // Masquer le texte des vies
    timerText.SetActive(false); // Masquer le texte du timer
    Time.timeScale = 0f;      // Arrêter le temps de jeu
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
