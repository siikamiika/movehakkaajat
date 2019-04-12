﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    float shootTimer;
    float shootInterval = 1f;
    public GameObject bullet;
    GameObject player;

    void Start()
    {
        shootTimer = 0;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer > shootInterval)
        {
            shootTimer -= shootInterval;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, player.transform.position, player.transform.rotation);
    }
}
