using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsPanel : MonoBehaviour {

    public GameObject skillPanel;
    bool isactive = false;

	// Update is called once per frame
	void Update () {
        if (isactive)
        {
            skillPanel.SetActive(true);
        }
        else
        {
            skillPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            isactive = !isactive;
        }
	}
}
