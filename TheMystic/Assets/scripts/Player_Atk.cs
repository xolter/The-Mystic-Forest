using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Atk : MonoBehaviour
{
    public Image spell_1;
    public Image spell_2;
    public Image spell_3;
    public Image spell_4;
    public bool CoolingDown_1;
    public bool CoolingDown_2;
    public bool CoolingDown_3;
    public bool CoolingDown_4;
    public float waitTime_1 = 5.0f;
    public float waitTime_2 = 10.0f;
    public float waitTime_3 = 15.0f;
    public float waitTime_4 = 20.0f;
    // Use this for initialization
    void Start()
    {
        CoolingDown_1 = false;
        CoolingDown_2 = false;
        CoolingDown_3 = false;
        CoolingDown_4 = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.A) && !CoolingDown_1)
        {
            spell_1.fillAmount = 0;
        }
        if (Input.GetKeyUp(KeyCode.E) && !CoolingDown_2)
        {
            spell_2.fillAmount = 0;
        }
        if (Input.GetKeyUp(KeyCode.R) && !CoolingDown_3)
        {
            spell_3.fillAmount = 0;
        }
        if (Input.GetKeyUp(KeyCode.F) && !CoolingDown_4)
        {
            spell_4.fillAmount = 0;
        }
        if(CoolingDown_1)
        {
            spell_1.fillAmount += 1.0f / waitTime_1 * Time.deltaTime;
        }
        if (CoolingDown_2)
        {
            spell_2.fillAmount += 1.0f / waitTime_2 * Time.deltaTime;
        }
        if (CoolingDown_3)
        {
            spell_3.fillAmount += 1.0f / waitTime_3 * Time.deltaTime;
        }
        if (CoolingDown_4)
        {
            spell_4.fillAmount += 1.0f / waitTime_4 * Time.deltaTime;
        }
    }
}