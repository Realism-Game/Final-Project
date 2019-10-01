using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool IsSet { private set; get; }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Button_trigger")
        {
            IsSet = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Button_trigger")
        {
            IsSet = true;
        }
    }
}
