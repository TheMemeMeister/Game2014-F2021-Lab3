using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// SINGLETON
/// </summary>
[System.Serializable]
public class BulletManager : MonoBehaviour
{
    private static BulletManager instance = null;

    private BulletManager ()
    {
        Initialize();
    }

    public static BulletManager Instance()
    {
        if (instance == null)
        {
            instance = new BulletManager();
        }
        return instance;
    }

    public List<Queue<GameObject>> bulletPools;



    //referances
  
    // Start is called before the first frame update
    private void Initialize()
    {
        bulletPools = new List<Queue<GameObject>>();

        //TODO: need to instantiate new queue collections
        for (int i = 0; i < (int)(BulletType.NUMBER_OF_BULLET_TYPES); i++)
        {
            bulletPools.Add(new Queue<GameObject>());
        }
     
    }


 
    private void Addbullet(BulletType type = BulletType.ENEMY)
    {
        var temp_bullet = BulletFactory.Instance().createBullet(type);
        bulletPools[(int)type].Enqueue(temp_bullet);
        
        
        
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
      
           
                if (bulletPools[(int)type].Count < 1)//nothing in pool
                {
                    Addbullet(type);

                }
                temp_bullet = bulletPools[(int)type].Dequeue();
               
           
                temp_bullet.transform.position = spawn_position;
                temp_bullet.SetActive(true);
              
       
        return temp_bullet;
    }
    /// <summary>
    /// This method returns a bullet back into the bullet pool
    /// </summary>
    /// <param name="returnedBullet"></param>
    public void ReturnedBullet(GameObject returnedBullet, BulletType type = BulletType.ENEMY)
    {
        returnedBullet.SetActive(false);
        bulletPools[(int)type].Enqueue(returnedBullet);


    }
}
