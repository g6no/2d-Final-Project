using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //SerializedFields
    [SerializeField] float moveSpeed = 4f;

    Rigidbody2D rb;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     //   movement.x = Input.GetAxis("Horizontal");
     //   movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        TdMovement();
        
    }

    void TdMovement()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");
        if (xThrow != 0)
        {
            transform.Translate(new Vector2(xThrow, 0) * moveSpeed);
        }
        if (yThrow != 0 && xThrow == 0)
        {
            transform.Translate(new Vector2(0, yThrow) * moveSpeed);
        }
    }
}
