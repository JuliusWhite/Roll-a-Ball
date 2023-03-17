using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
     public float rotationSpeed = 50.0f; // velocidad de rotación

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }
}
