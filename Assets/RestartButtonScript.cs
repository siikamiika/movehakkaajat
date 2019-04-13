using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<CharacterController>().PlayerDiesEvent.AddListener(delegate 
        {
            gameObject.SetActive(true);
        });
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
