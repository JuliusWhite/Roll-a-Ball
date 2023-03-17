using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;

    private Rigidbody rb;

    private float movementX;
    private float movementY;
    private float movementZ;
    
    public static int coinCount;

    public TextMeshProUGUI coinCountText;

    // Start is called before the first frame update
    void Start()
    {
        // instanciando el objeto que contiene este script
        // la bola
        rb = GetComponent<Rigidbody>();
        coinCount = 0;
        Debug.Log(coinCount);
        coinCountText.text = "Coins: " + coinCount;
    }

    /**
     *  Evento Input System
     **/
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        // mensaje para la consola del Unity
        // Debug.Log("Estoy en OnMove ");
    }

    private void FixedUpdate()
    {
        // para el teclado
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        // recogemos los datos del acelerometro
        Vector3 dir = Vector3.zero;
        dir.x = -Input.acceleration.y;
        dir.z = Input.acceleration.x;
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        
        dir *= Time.deltaTime;
        transform.Translate(dir * speed);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            coinCount++;
            coinCountText.text = "Coins: " + coinCount/2;
            other.gameObject.SetActive(false);
            Debug.Log(coinCount/2);

            if (coinCount/2 == 6)
            {
                speed = 20;
            }
            else if (coinCount/2 == 12)
            {
                coinCountText.text = "Finished!";
                Time.timeScale = 0;
            }
        }
    }

}