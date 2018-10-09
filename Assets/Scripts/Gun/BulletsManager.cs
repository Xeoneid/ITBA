using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    public static BulletsManager instance { get; private set; }
    public GameObject bulletPrefab;
    public Stack<Bullet> bulletPool = new Stack<Bullet>();
    public int preInstancedBullets = 100;
    [Range(0.5f, 30f)]
    public float bulletsTimeAliveProperty = 5f;
    public static float BulletsTimeAlive {
        get { return instance.bulletsTimeAliveProperty; }
        set { instance.bulletsTimeAliveProperty = value; }
     }

    public static Bullet GetBullet()
    {
        Bullet bullet = instance.bulletPool.Pop();

        bullet.SetActive(true);
        return bullet != null ? bullet : instance.InstantiateBullet();
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is already another " + this.GetType());
            DestroyImmediate(this);
        }
    }

    // Use this for initialization
    void Start()
    {
        // Pre instantiate
        if (bulletPrefab.GetComponent<Bullet>() != null)
        {
            for (int i = 0; i < preInstancedBullets; i++)
            {
                InstantiateBullet();
            }
        }
        else
            Debug.LogError(bulletPrefab.name + " prefab doesn't have IBullet component");
        
    }

    Bullet InstantiateBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform);
        Bullet bulletComponent = newBullet.GetComponent<Bullet>();
        bulletComponent.SetActive(false);
        bulletPool.Push(bulletComponent);

        return bulletComponent;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
