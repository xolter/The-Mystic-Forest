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
    PlayerStats playerstats;

    void Start()
    {
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        gameOverObject = GameObject.FindGameObjectWithTag("GameOverMenu");
        Debug.Log("playerstats: " + playerstats);
    }
    void Update()
    {
        if (PlayerStats.localPlayer == null)
        {
            gameOverisActive = playerstats.currentHealth <= 0;
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