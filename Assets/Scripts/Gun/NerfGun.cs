using UnityEngine;
using System.Collections;

public class NerfGun : MonoBehaviour
{
    //public int currentAmmo = 100;
    [Range(0f, 500f)]
    public float force = 400f;
    [Range(0.02f,1f)]
    public float cooldown = 0.2f;
    public float waitingTimeForCooldown = 0f;
    public Transform bulletSpawnPosition;

    public void Fire()
    {
        if (waitingTimeForCooldown >= 0)
            return;
        Bullet bullet = BulletsManager.GetBullet();
        bullet.transform.position = bulletSpawnPosition.position;
        bullet.transform.rotation = bulletSpawnPosition.rotation;
        bullet._rigidbody.AddForce(transform.forward * force);

        waitingTimeForCooldown = cooldown;
    }

    private void Update()
    {
        if(waitingTimeForCooldown >= 0)
            waitingTimeForCooldown -= Time.deltaTime;
        if (Input.anyKey)
            Fire();
    }

}
