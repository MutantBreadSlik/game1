using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D rb;
    [SerializeField] private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    { 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.R)){
            transform.position = Vector3.zero;
        }
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * movementSpeed * Time.deltaTime,movement.y * movementSpeed * Time.deltaTime);


    }
}
