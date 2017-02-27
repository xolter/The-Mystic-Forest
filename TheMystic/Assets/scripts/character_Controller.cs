using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	[System.Serializable]
	public class MoveSettings
	{
		public float forwardVel = 12;
		public float rotateVel = 100;
		public float jumpvel = 25;
		public float distToGrounded = 0.5f;
		public LayerMask ground;
	}

	[System.Serializable]
	public class PhysSettings
	{
		public float downAccel = 0.75f;
		public string FORWARD_AXIS = "Vertical";
		public string TURN_AXIS = "Horizontal";
		public string JUMP_AXIS = "Jump";
	}

	[System.Serializable]
	public class InputSettings
	{
		public float inputDelay = 0.1f;
	}

	public MoveSettings movesettings = new MoveSettings();
	public PhysSettings physsettings = new PhysSettings();
	public InputSettings inputsettings = new InputSettings();

	Vector3 velocity = Vector3.zero;
	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, turnInput;

	public Quaternion TargetRotation
	{
		get{ return targetRotation; }
	}

	bool Grounded()
	{
		return Physics.Raycast (transform.position, Vector3.down, movesettings.distToGrounded, movesettings.ground);
	}

	void Start ()
	{
		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody> ())
			rBody = GetComponent<Rigidbody> ();
		else
			Debug.LogError ("character needs rigidbody");
		forwardInput = 0;
		turnInput = 0;
	}

	void GetInput()
	{
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}

	void Update ()
	{
		GetInput ();
		Turn ();

	}

	void FixedUpdate()
	{
		Run ();	
	}

	void Run()
	{
		if (Mathf.Abs(forwardInput) > inputsettings.inputDelay)
		{
			//move
			rBody.velocity = transform.forward * forwardInput * movesettings.forwardVel;
		}
		else
		{
			//zero velocity
			rBody.velocity = Vector3.zero;
		}
	}

	void Turn()
	{
		if (Mathf.Abs (turnInput) > inputsettings.inputDelay)
		{
			targetRotation *= Quaternion.AngleAxis (movesettings.rotateVel * turnInput * Time.deltaTime, Vector3.up);
			transform.rotation = targetRotation;
		}
	}
}
