using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemy : Enemy
{
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(0,0, speed);
        if (transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
}
