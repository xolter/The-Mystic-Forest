using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour {

    public Player_Health health;
    bool GameOverisActive = false;

    void Start()
    {
        health = GetComponent<Player_Health>();
    }
    void Update()
    {
        /*if (health.current_health <= 0)
        {
            GameOverisActive = true;
        }*/
        if (GameOverisActive)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
}