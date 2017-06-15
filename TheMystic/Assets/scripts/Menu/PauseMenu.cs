using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject menuObject;
	public GameObject optionObject;
    public GameObject SkillsPanelObject;
    public GameObject InventoryObject;
    bool optionActive = false;
	bool isActive = false;
    bool skillsActive = false;
    bool InventoryActive = false;

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
            else if (InventoryActive)
            {
                InventoryActive = !InventoryActive;
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryActive = !InventoryActive;
        }
        //menu affiché
        if (isActive)
		{
			menuObject.SetActive (true);
            //L'affichage du curseur est géré par CurseurManager
            //pause
            if (PlayerStats.players.Count > 1)
                return;
            Time.timeScale = 0;
        }
        else if (skillsActive)
        {
            SkillsPanelObject.SetActive(true);
            if (PlayerStats.players.Count > 1)
                return;
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
        if (InventoryActive)
        {
            InventoryObject.SetActive(true);
        }
        else
        {
            InventoryObject.SetActive(false);
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
