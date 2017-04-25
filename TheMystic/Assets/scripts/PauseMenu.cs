using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject menuObject;
	public GameObject optionObjet;
    public GameOverScene goScene;    
	bool optionActive = false;
	bool isActive = false;

    void Start()
    {
        goScene = GetComponent<GameOverScene>();
    }
    // Update is called once per frame
    void Update ()
    {
		//menu affiché
		if (isActive)
		{
			menuObject.SetActive (true);
			//on affiche le curseur
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
            //pause
            Time.timeScale = 0;
		}
		else
		{
			//menu pas affiché
			menuObject.SetActive (false);
			//on affiche plus curseur
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			//pause
			Time.timeScale = 1;
		}

		if (optionActive)
		{
			optionObjet.SetActive (true);
		} 
		else
		{
			optionObjet.SetActive (false);
		}
        if (!goScene.GameOverisActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && optionActive)
            {
                optionActive = !optionActive;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                isActive = !isActive;
            }
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
