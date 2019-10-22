using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    public float speed;
    public bool canHop;
    public bool canFly;
    public Camera thirdPersonCamera;

    private Rigidbody rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 delta = transform.forward * Time.deltaTime * speed;
            transform.position += delta;
            Velocity = rb.velocity.magnitude;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 delta = transform.forward * Time.deltaTime * speed;
            transform.position -= delta;
        } else
        {
            Velocity = 0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -2f, 0);
            thirdPersonCamera.transform.Rotate(0, -2f, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 2f, 0);
            thirdPersonCamera.transform.Rotate(0, 2f, 0);
        }

        float moveJump = Input.GetAxis("Jump");
        if (isGrounded && moveJump != 0 && (canHop || canFly))
        {
            if (canHop)
            {
                isGrounded = false;
            }
            rb.AddForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
        }
    }

    private void LateUpdate()
    {
        thirdPersonCamera.transform.position = transform.position - new Vector3(transform.forward.x * 5, -2, transform.forward.z * 5);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Platform" && !isGrounded)
        {
            isGrounded = true;
        }
    }

    public float Velocity
    {
        get;
        private set;
    }
}
