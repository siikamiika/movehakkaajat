using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        print("collision hit");
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<CharacterController>()?.TakeDamage(10);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
    }

}
