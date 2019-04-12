using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            // TODO Player take damage
            Destroy(this);
        }
        if( collision.collider.gameObject.tag == "PlayerBullet")
        {
            Destroy(this);
        }
    }

}
