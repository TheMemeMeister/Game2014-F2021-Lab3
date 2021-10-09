using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")]
    //variables
    [Range(0.0f, 100.0f)]
    public float horizontalForce;
    [Range(0.0f, 1.0f)]
    public float decayValue;

    //referances
    private Rigidbody2D shiprb;
    public Bounds bounds; //not sure if this is a ref or var

    // Start is called before the first frame update
    void Start()
    {
        shiprb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }
    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");
        shiprb.AddForce(new Vector2(x * horizontalForce, 0.0f), 0.0f);
        shiprb.velocity *= (1.0f - decayValue); //linear drag on ship 
    }
    private void CheckBounds()
    {
        //Left Bound
        if(transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }
        //Right Bound
        if (transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }
}
