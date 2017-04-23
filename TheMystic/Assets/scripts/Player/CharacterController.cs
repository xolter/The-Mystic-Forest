using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [System.Serializable]
    public class MoveSettings
    {
        public float forwardVel = 12;
        public float rotateVel = 100;
        public float jumpvel = 25;
        public float distToGrounded = 0.1f;
        public LayerMask ground;
    }

    [System.Serializable]
    public class PhysSettings
    {
        public float downAccel = 0.75f;
    }

    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizotal";
        public string ROTATE_AXIS = "Mouse X";
        public string JUMP_AXIS = "Jump";
    }

    public MoveSettings moveSettings = new MoveSettings();
    public PhysSettings physSettings = new PhysSettings();
    public InputSettings inputSettings = new InputSettings();

    Vector3 velocity = Vector3.zero;
    Quaternion targetRotation;
    Rigidbody rBody;
    Player_Atk attack;
    public Animator anim;
    private float forwardInput, turnInput, rotateInput, jumpInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, moveSettings.distToGrounded, moveSettings.ground);
    }

    void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("character needs rigidbody");
        anim = GetComponent<Animator>();
        attack = GetComponent<Player_Atk>();
        forwardInput = turnInput = jumpInput = 0;  
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSettings.FORWARD_AXIS);
        turnInput = Input.GetAxis(inputSettings.TURN_AXIS);
        rotateInput = Input.GetAxis(inputSettings.ROTATE_AXIS);
        jumpInput = Input.GetAxisRaw(inputSettings.JUMP_AXIS);
    }

    void Update()
    {
        GetInput();
        Rotate();
    }

    void FixedUpdate()
    {
        //anim.GetCurrentAnimatorStateInfo(0).IsName("Walk");
        if (CanMove())
        {
            Run();
            Turn();
            Jump();
            rBody.velocity = transform.TransformDirection(velocity);
        }
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputSettings.inputDelay)
        {
            //move
            rBody.velocity = transform.forward * forwardInput * moveSettings.forwardVel;
            velocity.z = moveSettings.forwardVel * forwardInput;
        }
        else
        {
            //zero velocity
            rBody.velocity = Vector3.zero;
            velocity.z = 0;
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputSettings.inputDelay)
        {
            //move
            rBody.velocity = transform.right * turnInput * moveSettings.forwardVel;
            velocity.x = moveSettings.forwardVel * turnInput;
        }
        else
        {
            //zero velocity
            rBody.velocity = Vector3.zero;
            velocity.x = 0;
        }
    }

    void Rotate()
    {
        if (Mathf.Abs(rotateInput) > inputSettings.inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(moveSettings.rotateVel * rotateInput * Time.deltaTime, Vector3.up);
        }
            transform.rotation = targetRotation;
        
    }

    void Jump()
	{
		if (jumpInput > 0 && Grounded())
		{
			velocity.y = moveSettings.jumpvel;            
		}
		else if (jumpInput == 0 && Grounded())
		{
			velocity.y = 0;
		}
		else
		{
			velocity.y -= physSettings.downAccel;
		}
	}

    public bool CanMove()
    {
        bool res = !anim.GetCurrentAnimatorStateInfo(0).IsName("Melee1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Melee2");
        for (int i = 0; i <attack.skills.Count; i++)
        {
            res = res && !anim.GetCurrentAnimatorStateInfo(0).IsName(attack.skills[i].name);
        }
        return res;
    }
}
