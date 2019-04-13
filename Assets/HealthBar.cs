using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    CharacterController player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var canvasWidth = (transform.parent.transform as RectTransform).rect.width;

        (this.transform as RectTransform).offsetMax = new Vector2(-canvasWidth + canvasWidth * player.GetHealth() / 100, 0) ;
    }


}
