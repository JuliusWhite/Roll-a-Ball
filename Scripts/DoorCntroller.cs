using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCntroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.coinCount/2 >= 3)
        {
            gameObject.SetActive(false);
        }
    }
}
