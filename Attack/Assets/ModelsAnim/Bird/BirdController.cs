using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Animator animator;
    //private Rigidbody rb;

    float flySpeed = 10.0f;
    float rotationSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        MovementManager(h, v);
    }

    void MovementManager (float horizontal, float vertical)
    {
        if (horizontal != 0f || vertical != 0f || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
        {
            animator.SetFloat("speed", flySpeed);

            //Up arrow/W moves forward
            if(Input.GetAxis("Vertical") == 1)
            {
                this.transform.Translate(new Vector3(0, 0, flySpeed * Time.deltaTime), this.transform);
            }
            //Down arrow/S moves backward
            if (Input.GetAxis("Vertical") == -1)
            {
                this.transform.Translate(new Vector3(0, 0, -1 * flySpeed * Time.deltaTime), this.transform);
            }
            //Left arrow/A moves left
            if (Input.GetAxis("Horizontal") == -1)
            {
                this.transform.Translate(new Vector3(-1 * flySpeed * Time.deltaTime, 0, 0), this.transform);
            }
            //Right arrow/D moves right
            if (Input.GetAxis("Horizontal") == 1)
            {
                this.transform.Translate(new Vector3(Time.deltaTime * flySpeed, 0, 0), this.transform);
            }
            //Q moves up
            if (Input.GetKey(KeyCode.Q))
            {
                this.transform.Translate(new Vector3(0, Time.deltaTime * flySpeed, 0), this.transform);
            }
            //E moves down
            if (Input.GetKey(KeyCode.E))
            {
                this.transform.Translate(new Vector3(0, -1 * Time.deltaTime * flySpeed, 0), this.transform);
            }


        }
        else
        {
            animator.SetFloat("speed", 0f);
            animator.transform.position = this.transform.position;
        }
    }
}

