using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Vector2 moveVector;

    void Start()
    {
        moveVector = new Vector2(0, 0);
    }

    void Update()
    {
        moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveDirection = new Vector3(moveVector.x, 0, moveVector.y);
        transform.Translate(moveDirection);
    }
}
