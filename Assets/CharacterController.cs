using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    public UnityEvent PlayerDiesEvent; 

    Vector2 moveVector;
    GameObject sceneCamObj;
    public SensorData sensorData;
    float speed = 5;
    public GameObject bullet;

    private int health = 100;
    public int GetHealth() => health;
    private float lastBlastRecharge = 0;
    private float lastBlast = 0;
    private int blastCount = 10;

    private int score = 0;
    public int GetScore() => score;
    public void AddScore(int score)
    {
        this.score += score;
    }

    private bool playerAlive = true;

    void Start()
    {
        moveVector = new Vector2(0, 0);
        sceneCamObj = Camera.main.gameObject;
    }

    void Update()
    {
        if (!playerAlive)
        {
            return;
        }
        float moveX = Mathf.Max(Mathf.Min(sensorData.linearAcceleration.y, 9), -9) * speed * Time.deltaTime;
        float moveY = -Mathf.Max(Mathf.Min(sensorData.linearAcceleration.x, 9), -9) * speed * Time.deltaTime;
        moveVector = new Vector2(moveX, moveY);
        // recharge blast
        if (Time.time - lastBlastRecharge > 1)
        {
            lastBlastRecharge = Time.time;
            if (blastCount < 10)
            {
                blastCount += 1;
            }
        }
        // activate blast
        if (sensorData.linearAcceleration.z > 15)
        {
            Blast();
        }
    }

    void FixedUpdate()
    {
        if (playerAlive)
        {
            Move();
            score++;
        }
    }

    Vector2 getPlayArea() {
        float orthSize = sceneCamObj.GetComponent<Camera>().orthographicSize;
        float height = orthSize;
        float width = orthSize / Screen.height * Screen.width;
        return new Vector2(width, height);
    }

    void Blast()
    {
        if (blastCount <= 0 || Time.time - lastBlast < 0.02)
        {
            return;
        }
        blastCount -= 1;
        lastBlast = Time.time;
        for (int i = 0; i <= 50; i++)
        {
            float val = 360 / 50 * i;
            Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, val, 0)));
        }
    }

    void Move()
    {
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
            OnPlayrDies();
        }
    }

    void OnPlayrDies()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        playerAlive = false;
        PlayerDiesEvent?.Invoke();
    }
}
