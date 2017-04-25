using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{

    public Player_Health health;
    public GameObject gameOverObjet;
    private bool gameOverisActive;
    public bool GameOverisActive { get { return gameOverisActive; } }
    private bool trigger;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
        gameOverObjet = GameObject.FindGameObjectWithTag("GameOverMenu");
        gameOverisActive = false;
        trigger = true;
    }
    void Update()
    {
        gameOverisActive = health.current_health <= 0;
        if (gameOverisActive)
        {
            if (trigger)
            {
                gameOverObjet.SetActive(true);                
                trigger = false;
            }            
        }
        else
        {
            gameOverObjet.SetActive(false);           
        }
        CursorPreset();
    }

    void CursorPreset()
    {
        if (GameOverisActive)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}