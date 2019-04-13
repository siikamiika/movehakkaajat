using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEnemy : Enemy
{
    List<Vector3> lastPositions;
    List<GameObject> tail;
    public GameObject tailPiece;

    void Start()
    {
        lastPositions = new List<Vector3>();
        tail = new List<GameObject>();
        for (int i = 0; i < 8; i++)
        {
            lastPositions.Add(transform.position);
            GameObject tailPart = Instantiate(tailPiece, transform.position, transform.rotation);
            tailPart.GetComponent<SnakeTail>().head = gameObject;
            tail.Add(tailPart);
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < tail.Count; i++)
        {
            if (i * 5 < lastPositions.Count)
            {
                tail[i].transform.position = lastPositions[i * 5];
            }
        }
        lastPositions.Insert(0, transform.position);
        transform.Translate(new Vector3((Mathf.Sin(Time.time)) * 0.1f, 0, -2 * Time.deltaTime));
    }
}
