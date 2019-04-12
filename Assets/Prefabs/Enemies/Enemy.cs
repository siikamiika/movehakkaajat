using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            FindObjectOfType<CharacterController>()?.TakeDamage(10);
            Destroy(gameObject);
        }
        if( collision.collider.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
    }

}
