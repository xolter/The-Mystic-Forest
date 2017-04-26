using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{

    Player_Health health;
    GameObject gameOverObject;
    private bool gameOverisActive = false;
    public AudioSource music;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
        gameOverObject = GameObject.FindGameObjectWithTag("GameOverMenu");
    }
    void Update()
    {
        gameOverisActive = health.current_health <= 0;
        if (gameOverisActive)
        {
            gameOverObject.SetActive(true);
            music.mute = true;
        }
        else
        {
            gameOverObject.SetActive(false);           
        }
        //L'affichage du curseur est géré par CurseurManager
    }

}