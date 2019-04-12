using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Vector2 moveVector;
    GameObject sceneCamObj;

    private int health = 100;
    public int GetHealth() => health;

    void Start()
    {
        moveVector = new Vector2(0, 0);
        sceneCamObj = Camera.main.gameObject;
    }

    void Update()
    {
        moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        Move();
    }

    Vector2 getBoundingBox() {
        float orthSize = sceneCamObj.GetComponent<Camera>().orthographicSize;
        float height = orthSize;
        float width = orthSize / Screen.height * Screen.width;
        return new Vector2(width, height);
    }

    void Move()
    {
        Debug.Log(sceneCamObj.GetComponent<Camera>().orthographicSize);
        Vector2 dimensions = getBoundingBox();
        float xNeg = -dimensions.x;
        float xPos = dimensions.x;
        float yNeg = -dimensions.y;
        float yPos = dimensions.y;
        if (
            (moveVector.x >= 0 || (moveVector.x < 0 && transform.position.x > xNeg)) &&
            (moveVector.x <= 0 || (moveVector.x > 0 && transform.position.x < xPos)) &&
            (moveVector.y >= 0 || (moveVector.y < 0 && transform.position.z > yNeg)) &&
            (moveVector.y <= 0 || (moveVector.y > 0 && transform.position.z < yPos))
            ) {
            Vector3 moveDirection = new Vector3(moveVector.x, 0, moveVector.y);
            transform.Translate(moveDirection);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = health <= 0 ? 0 : health;
        if (health == 0)
        {
            // die
        }
    }


}
