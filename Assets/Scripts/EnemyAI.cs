using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private Vector3 center = new Vector3(-25f, 0, 25f);
    private Vector3 v;
    private float speed = 100f;

    void Start()
    {
        v = transform.position - center;
    }
    void Update()
    {
        v = Quaternion.AngleAxis(Time.deltaTime * speed, Vector3.up) * v;
        transform.position = center + v;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Rabbit" || collision.gameObject.name == "Bird")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "Deer")
        {
            Destroy(this.gameObject);
        }
    }
}
