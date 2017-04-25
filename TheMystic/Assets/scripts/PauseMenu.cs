using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject menuObject;
	public GameObject optionObject;
    //GameOverScene goScene;    
	bool optionActive = false;
	bool isActive = false;

    /*void Start()
    {
        goScene = GetComponent<GameOverScene>();
    }*/
    // Update is called once per frame
    void Update ()
    {
		//menu affiché
		if (isActive)
		{
			menuObject.SetActive (true);
            //L'affichage du curseur est géré par CurseurManager
            //pause
            Time.timeScale = 0;
        }
		else
		{
			//menu pas affiché
			menuObject.SetActive (false);
            //L'affichage du curseur est géré par CurseurManager
			//pause
			Time.timeScale = 1;
		}
        if (optionActive)
        {
            optionObject.SetActive(true);
        }
        else
        {
            optionObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && optionActive)
		{
			optionActive = !optionActive;
		}
        else if (Input.GetKeyDown(KeyCode.Escape))
		{
			isActive = !isActive;
		}
	}
	public void RESUME_BUTTON()
	{
		isActive = !isActive;
	}
	public void OPTION_SETTINGS_OPEN_CLOSE()
	{
        optionActive = !optionActive;
	}
}
