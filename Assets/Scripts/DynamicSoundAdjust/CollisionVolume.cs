using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionVolume : MonoBehaviour
{
    TextMeshProUGUI currentCollisionVolume;
    public int collisionVolume;

    void Start() {
        currentCollisionVolume = GetComponent<TextMeshProUGUI> ();
        collisionVolume = 100; // Set default value when start game
        currentCollisionVolume.text = collisionVolume.ToString() + "/100";
    }

    public void textUpdate(float value)
    {
        collisionVolume = Mathf.RoundToInt(value * 100);
        currentCollisionVolume.text = collisionVolume.ToString() + "/100";
    }
}
