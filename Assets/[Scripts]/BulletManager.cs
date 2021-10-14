using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> enemyBulletPool; // QUE used FIFO structure
    public Queue<GameObject> playerBulletPool; // QUE used FIFO structure
    public int enemyBulletNumber;
    public int playerBulletNumber;

    //referances
    private BulletFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        enemyBulletPool = new Queue<GameObject>(); //creates an empty queue
        playerBulletPool = new Queue<GameObject>(); //creates an empty queue
        factory = GetComponent<BulletFactory>();//gets referance to bullet factory
        
        //BuildBulletPool();
    }


 
    private void Addbullet(BulletType type = BulletType.ENEMY)
    {
        var temp_bullet = factory.createBullet(type);
        switch (type)
        {
            case BulletType.ENEMY:

                enemyBulletPool.Enqueue(temp_bullet);
                enemyBulletNumber++;
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(temp_bullet);
                playerBulletNumber++;
                break;
        }


        enemyBulletPool.Enqueue(temp_bullet);
        enemyBulletNumber++;
    }

    /// <summary>
    /// this method removes a bullet prefab from the bullet pool 
    /// and returns a referance to it
    /// </summary>
    /// <param name="spawn_position"></param>
    /// <returns></returns>
    public GameObject GetBullet(Vector2 spawn_position, BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        switch (type)
        {
            case BulletType.ENEMY:
                if (enemyBulletPool.Count < 1)//nothing in pool
                {
                    Addbullet();

                }
                temp_bullet = enemyBulletPool.Dequeue();
                temp_bullet.transform.position = spawn_position;
                temp_bullet.SetActive(true);
                break;
            case BulletType.PLAYER:
                Debug.Log("Getting Plyaer Bullet");
                if (playerBulletPool.Count < 1)//nothing in pool
                {
                    Addbullet(BulletType.PLAYER);

                }
                temp_bullet = playerBulletPool.Dequeue();
                temp_bullet.transform.position = spawn_position;
                temp_bullet.SetActive(true);
                break;
        }
       
        return temp_bullet;
    }
    /// <summary>
    /// This method returns a bullet back into the bullet pool
    /// </summary>
    /// <param name="returnedBullet"></param>
    public void ReturnedBullet(GameObject returnedBullet, BulletType type = BulletType.ENEMY)
    {
        returnedBullet.SetActive(false);
        switch (type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(returnedBullet);
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(returnedBullet);
                break;
        }
      
    }
}
