using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
	public float moveSpeed = 1.0f;
	public float rotSpeed = 100f;
	public Camera thirdPersonCamera;

	private Animator anim;
	private bool isWalking = false;
	
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
        	anim.SetBool("IsWalk", true);
        	anim.SetBool("IsIdle", false);
        	isWalking = true;
        	transform.position += transform.forward * Time.deltaTime * moveSpeed;
        	thirdPersonCamera.transform.position = transform.position - new Vector3(transform.forward.x * 3, -1.5f, transform.forward.z * 2);
        }
        else if (Input.GetKey(KeyCode.S))
        {
        	anim.SetBool("IsWalk", true);
        	anim.SetBool("IsIdle", false);
        	isWalking = true;
        	transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        	thirdPersonCamera.transform.position = transform.position - new Vector3(transform.forward.x * 3, -1.5f, transform.forward.z * 2);
        } 
        if (Input.GetKey(KeyCode.A))
        {
        	Vector3 rot = transform.up * Time.deltaTime * rotSpeed;
            transform.Rotate(-rot);
            thirdPersonCamera.transform.RotateAround(transform.position, Vector3.up, -rot.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
        	Vector3 rot = transform.up * Time.deltaTime * rotSpeed;
            transform.Rotate(rot);
            thirdPersonCamera.transform.RotateAround(transform.position, Vector3.up, rot.y);
        }
        if (!isWalking)
        {
        	anim.SetBool("IsWalk", false);
        }
        else
        {
        	isWalking = false;
        }
    }
}
