using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Networking;

public class GameOverScene : MonoBehaviour//NetworkBehaviour
{

    //Player_Health health;
    GameObject gameOverObject;
    private bool gameOverisActive = false;
    public AudioSource Mainmusic;
    public AudioSource DeathMusic;
    bool already_played = false;    

    void Start()
    {        
        gameOverObject = GameObject.FindGameObjectWithTag("GameOverMenu");         
    }
    void Update()
    {
        if (PlayerStats.localPlayer != null)
        {
            gameOverisActive = PlayerStats.localPlayer.currentHealth <= 0;
            if (gameOverisActive)
            {
                gameOverObject.SetActive(true);
                Mainmusic.mute = true;
                if (!already_played)
                {
                    DeathMusic.Play();
                    already_played = true;
                }
            }
            else
            {
                gameOverObject.SetActive(false);                
            }
        }
        //L'affichage du curseur est géré par CurseurManager
    }

}