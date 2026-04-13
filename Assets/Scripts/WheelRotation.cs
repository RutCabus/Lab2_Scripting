using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WheelRotation : MonoBehaviour
{
    //Variables
    public Vector3 rotationSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
