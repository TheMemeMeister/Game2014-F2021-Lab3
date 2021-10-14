using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBehaviour : MonoBehaviour
{
    public BulletType type;
    [Header("Bullet Movement")]
    //variables
    [Range(0.0f, 0.5f)]
    public float speed;
    public Bounds bulletBounds;
    public BulletDirection direction;

    //private BulletManager bulletManager;
    public Vector3 bulletVelocity;

    void Start()
    {
        //bulletManager = GameObject.FindObjectOfType<BulletManager>();
        switch (direction)
        {
            case BulletDirection.UP:
                bulletVelocity = new Vector3(0.0f, speed, 0.0f);
                break;
            case BulletDirection.RIGHT:
                bulletVelocity = new Vector3(speed, 0.0f, 0.0f);
                break;
            case BulletDirection.DOWN:
                bulletVelocity = new Vector3(0.0f, -speed, 0.0f);
                break;
            case BulletDirection.LEFT:
                bulletVelocity = new Vector3(-speed, 0.0f, 0.0f);
                break;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }
    private void Move()
    {

        transform.position += bulletVelocity;
    }
    protected virtual void CheckBounds()
    {
        //check bottom bounds
        if(transform.position.y < bulletBounds.max)
        {
            //Destroy(this.gameObject);
            BulletManager.Instance().ReturnedBullet(this.gameObject, type);
        }
        //check top bound
        if (transform.position.y > bulletBounds.min)
        {
            //Destroy(this.gameObject);S
            BulletManager.Instance().ReturnedBullet(this.gameObject, type);
        }
    }
}
