using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public GameObject head;

    void Update()
    {
        if (head == null)
        {
            Destroy(gameObject);
        }
    }
}
