using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestiPalikka : MonoBehaviour
{
    public SensorData sData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = sData.linearAcceleration;
        this.transform.rotation = Quaternion.Euler(sData.angularVelocity);
    }
}
