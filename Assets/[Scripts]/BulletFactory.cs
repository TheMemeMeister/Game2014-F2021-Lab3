using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// SINGLETON
/// </summary>
[System.Serializable]
public class BulletFactory
{
    //step 1. private static instance.
    private static BulletFactory instance = null;


    // prefab referances
    public GameObject enemyBullet;
    public GameObject playerBullet;

    //game controller refernace
    private GameController gameController;

    private BulletFactory()
    {
        Initialize();
    }
    //step 3. public static creational method for class access
    public static BulletFactory Instance()
    {
        if (instance == null)
        {
            instance = new BulletFactory();
        }
        return instance;
    }
    private void Initialize()
    {
        //step 4. make a resources folder
        //step 5. move our bullet prefabs into resources folder
        enemyBullet = Resources.Load("Prefabs/EnemyBullet") as GameObject;
        playerBullet = Resources.Load("Prefabs/PlayerBullet") as GameObject;

        gameController = GameObject.FindObjectOfType<GameController>();
        //create referances to prefabs here
    }
    public GameObject createBullet(BulletType type = BulletType.ENEMY)//enemy bullet by default
    {
      
        GameObject temp_bullet = null;
        switch (type)
        {
            case BulletType.ENEMY:
                temp_bullet = MonoBehaviour.Instantiate(enemyBullet);
                break;
            case BulletType.PLAYER:
                temp_bullet = MonoBehaviour.Instantiate(playerBullet);
                break;
        }
        temp_bullet.transform.parent = gameController.gameObject.transform;
        temp_bullet.SetActive(false);

        return temp_bullet;
    }



}
