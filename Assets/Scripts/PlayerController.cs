using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  	private float walkSpeed = 0.55f;
	private float runSpeed = 1;

	private float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	private float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;

	Animator animator;
	Transform cameraT;

	private bool isWalking = false;
	private float sleepWaitTime = 2.0f;
	private float idleSwap = 0.0f;
	private float timer = 0.0f;

	private float stamina = 2.0f;
	private float maxStamina = 2.0f;

	public Slider staminaBar;
	
	void Start () {
		animator = GetComponent<Animator> ();
		cameraT = Camera.main.transform;
		maxStamina = 2.0f;
		stamina = 2.0f;
		staminaBar.value = stamina;
	}

	
	void Update () {

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 inputDir = input.normalized;

		if (inputDir != Vector2.zero) {
			float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
		}

		bool running = Input.GetKey (KeyCode.LeftShift);
		if ((stamina > 0) && (running == true)) {
			float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
			currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
			animator.SetBool("IsRun", true);
			stamina -= Time.deltaTime;
			staminaBar.value = stamina;
		} else {
			running = false;
			float targetSpeed = walkSpeed * inputDir.magnitude;
			currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
			animator.SetBool("IsRun", false);
		}
		
		//stamina
		if(!running)
		{
			if(stamina < 0)
			{
				stamina = 0;
				staminaBar.value = stamina;
				running = false;
				animator.SetBool("IsRun", false);
			}else if (stamina < maxStamina)
			{
				stamina += Time.deltaTime/6;
				staminaBar.value = stamina;
			}
		}
		
		
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
