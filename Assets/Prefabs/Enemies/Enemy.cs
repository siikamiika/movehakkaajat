﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int score;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<CharacterController>()?.TakeDamage(10);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "PlayerBullet")
        {
            print("Bullet hit");
            FindObjectOfType<CharacterController>()?.AddScore(score);
            Destroy(gameObject);
        }
    }

}
