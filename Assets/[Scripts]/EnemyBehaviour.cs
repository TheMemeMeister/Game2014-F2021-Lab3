using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Movement")]
    public Bounds movementBounds;
    public Bounds startRange;

    [Header("Bullets")]
    public Transform bulletSpawn;
    //public GameObject bulletPrefab;
    public int frameDelay;


    private float startingPoint;
    private float randomSpeed;

    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(movementBounds.min, movementBounds.max);
        startingPoint = Random.Range(startRange.min, startRange.max);
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed)+startingPoint, transform.position.y);
    }
    private void FixedUpdate()
    {
        if(Time.frameCount % frameDelay == 0) //use coroutine later
        {
            

            BulletManager.Instance().GetBullet(bulletSpawn.position);
        }
    }
}

