using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizotal";
        public string ROTATE_AXIS = "Mouse X";
        public string JUMP_AXIS = "Jump";
    }

    public InputSettings inputSettings = new InputSettings();
    public Animator anim;
    float forwardInput, turnInput, rotateInput, jumpInput;


    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	
	void Update ()
    {
        //GetInput();
        //Animations();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.Play("Forward", -1, 0f);
        }
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSettings.FORWARD_AXIS);
        turnInput = Input.GetAxis(inputSettings.TURN_AXIS);
        rotateInput = Input.GetAxis(inputSettings.ROTATE_AXIS);
        jumpInput = Input.GetAxisRaw(inputSettings.JUMP_AXIS);
    }

    void Animations()
    {
        if (forwardInput > 0)
        {
            anim.Play("Forward", -1, 0f);
        }
    }
}
