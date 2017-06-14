using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject menuObject;
	public GameObject optionObject;
    public GameObject SkillsPanelObject;   
	bool optionActive = false;
	bool isActive = false;
    bool skillsActive = false;

    void Update ()
    {    
        if (Input.GetKeyDown(KeyCode.Escape))
		{
            if (optionActive)
            {
                optionActive = !optionActive;
            }
            else if (skillsActive)
            {
                skillsActive = !skillsActive;
            }
            else
            {
                isActive = !isActive;
            }
		}
        if (Input.GetKeyDown(KeyCode.K) && !isActive)
        {
            skillsActive = !skillsActive;
        }
        //menu affiché
        if (isActive)
		{
			menuObject.SetActive (true);
            //L'affichage du curseur est géré par CurseurManager
            //pause
            Time.timeScale = 0;
        }
        else if (skillsActive)
        {
            SkillsPanelObject.SetActive(true);
            Time.timeScale = 0;
        }
		else
		{
			//menu pas affiché
			menuObject.SetActive (false);
            SkillsPanelObject.SetActive(false);
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
