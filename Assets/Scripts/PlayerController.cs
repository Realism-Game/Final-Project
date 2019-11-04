using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 2;
	public float runSpeed = 6;

	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;

	Animator animator;
	Transform cameraT;

	private bool isWalking = false;
	private float sleepWaitTime = 2.0f;
	private float idleSwap = 0.0f;
	private float timer = 0.0f;
	
	void Start () {
		animator = GetComponent<Animator> ();
		cameraT = Camera.main.transform;
	}

	void Update () {

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 inputDir = input.normalized;

		if (inputDir != Vector2.zero) {
			float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
		}

		bool running = Input.GetKey (KeyCode.LeftShift);
		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

		transform.Translate (transform.forward * currentSpeed * Time.deltaTime, Space.World);

		float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
		animator.SetFloat ("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);


		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
        	animator.SetBool("IsWalk", true);
        	animator.SetBool("IsIdle", false);
        	animator.SetBool("IsSleep", false);
        	isWalking = true;
        	timer = 0.0f;
        }
        if (!isWalking)
        {
	    	animator.SetBool("IsWalk", false);
	    	animator.SetBool("IsIdle", true);
        	timer += Time.deltaTime;
        	
        	if (timer > sleepWaitTime) {
				animator.SetBool("IsSleep", true);
				animator.SetBool("IsIdle", false);
        	}
        }
        else
        {
        	isWalking = false;
        }
	}
}
