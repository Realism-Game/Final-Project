using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector: MonoBehaviour{
    public bool hasMeat = false;
    public bool hasKey = false;

    public void ReceiveMeat() {
        hasMeat = true;
    }

    public void ReceiveKey() {
        hasKey = true;
    }
}
