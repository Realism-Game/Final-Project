using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingSpot : MonoBehaviour
{

    public LayerMask targetMask;
    public float sphereRadius = 0.5f;
    public bool isHidden = false;
    public Text enterText;
    public Text exitText;
    private UnityEngine.AI.NavMeshObstacle obstacle;

    // Start is called before the first frame update
    void Start()
    {
        enterText.enabled = false;
        exitText.enabled = false;
        obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, sphereRadius, targetMask);
        if (targetsInViewRadius.Length == 1) {
            GameObject bear = targetsInViewRadius[0].transform.gameObject;
            Animator anim = bear.GetComponent<Animator>();
            PlayerController bearController = bear.GetComponent<PlayerController>();
            if (!bearController.chased) {
                obstacle.enabled = true;
                bearController.hidden = isHidden;
                if (!isHidden) {
                    anim.SetBool("IsSleep", false);
                    enterText.enabled = true;
                    exitText.enabled = false;
                } else if (isHidden) {
                    anim.SetBool("IsSleep", true);
                    exitText.enabled = true;
                    enterText.enabled = false;
                }
                
                if (Input.GetKeyUp(KeyCode.Q) && !isHidden) {
                    isHidden = true;
                    enterText.enabled = false;
                    bearController.walkSpeed = 0.0f;
                    bearController.runSpeed = 0.0f;
                } else if (Input.GetKeyUp(KeyCode.Q) && isHidden) {
                    isHidden = false;
                    exitText.enabled = false;
                    bearController.walkSpeed = 1.2f;
                    bearController.runSpeed = 2.0f;
                }
            } else {
                obstacle.enabled = false;
            }
        } else {
            enterText.enabled = false;
            exitText.enabled = false;
            isHidden = false;
        }
    }
}
