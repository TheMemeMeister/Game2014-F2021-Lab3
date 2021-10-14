using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool; // QUE used FIFO structure
    public int bulletNumber;

    //referances
    private BulletFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>(); //creates an empty queue
        factory = GetComponent<BulletFactory>();//gets referance to bullet factory
        
        //BuildBulletPool();
    }


    /// <summary>
    /// This method builds a bullet pool with bulletNumber bullets
    /// </summary>
    private void BuildBulletPool()
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            Addbullet();
        }
    }
    private void Addbullet()
    {
        var temp_bullet = factory.createBullet();
        bulletPool.Enqueue(temp_bullet);
    }

    /// <summary>
    /// this method removes a bullet prefab from the bullet pool 
    /// and returns a referance to it
    /// </summary>
    /// <param name="spawn_position"></param>
    /// <returns></returns>
    public GameObject GetBullet(Vector2 spawn_position)
    {
        if (bulletPool.Count < 1)//nothing in pool
        {
            Addbullet();
            bulletNumber++;
        }
        var temp_bullet = bulletPool.Dequeue();
        temp_bullet.transform.position = spawn_position;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }
    /// <summary>
    /// This method returns a bullet back into the bullet pool
    /// </summary>
    /// <param name="returnedBullet"></param>
    public void ReturnedBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        bulletPool.Enqueue(returnedBullet);
    }
}
