using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text scoreText;
    private CharacterController player;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        player = FindObjectOfType<CharacterController>();
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.GetScore().ToString();
    }
}
