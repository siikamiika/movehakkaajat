using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float moveSpeed = 1f;
    float killTimer;
    float lifeTime = 2f;

    void Start()
    {
        killTimer = 0;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed);
        killTimer += Time.deltaTime;
        if (killTimer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
