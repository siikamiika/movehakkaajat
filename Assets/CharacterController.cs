using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Vector2 moveVector;
    GameObject sceneCamObj;
    public SensorData sensorData;
    float speed = 5;

    private int health = 100;
    public int GetHealth() => health;

    void Start()
    {
        moveVector = new Vector2(0, 0);
        sceneCamObj = GameObject.Find("Main Camera");
    }

    void Update()
    {
        float moveX = Mathf.Max(Mathf.Min(sensorData.linearAcceleration.y, 9), -9) * speed * Time.deltaTime;
        float moveY = -Mathf.Max(Mathf.Min(sensorData.linearAcceleration.x, 9), -9) * speed * Time.deltaTime;
        moveVector = new Vector2(moveX, moveY);
    }

    void FixedUpdate()
    {
        Move();
    }

    Vector2 getPlayArea() {
        float orthSize = sceneCamObj.GetComponent<Camera>().orthographicSize;
        float height = orthSize;
        float width = orthSize / Screen.height * Screen.width;
        return new Vector2(width, height);
    }

    void Move()
    {
        Debug.Log(sceneCamObj.GetComponent<Camera>().orthographicSize);
        Vector2 dimensions = getPlayArea();
        float xNeg = -dimensions.x;
        float xPos = dimensions.x;
        float yNeg = -dimensions.y;
        float yPos = dimensions.y;
        if ((transform.position.x + moveVector.x < xNeg) || (transform.position.x + moveVector.x > xPos)) {
            moveVector.x = 0;
        }
        if ((transform.position.z + moveVector.y < yNeg) || (transform.position.z + moveVector.y > yPos))
        {
            moveVector.y = 0;
        }
        Vector3 moveDirection = new Vector3(moveVector.x, 0, moveVector.y);
        transform.Translate(moveDirection);
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
