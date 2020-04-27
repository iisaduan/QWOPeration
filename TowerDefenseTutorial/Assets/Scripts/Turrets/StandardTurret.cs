using UnityEngine;

public class StandardTurret : Turret
{

    [Header("Use Bullets")]

    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;


    public override void Update()
    {
        base.Update();
        // determines if/ when to shoot
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

   /* Shoot()
    *
    * shoots a bullet towards target
    *
    */
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // kind of annoying - havce to do this for every GO soooo
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        Missile missile = bulletGO.GetComponent<Missile>();
        PoisonBullet poisBullet = bulletGO.GetComponent<PoisonBullet>();
        Destroy(bullet, 5f);
        Destroy(missile, 5f);
        Destroy(poisBullet, 5f);
        if (bullet != null)
        {
            bullet.Seek(target);

        }
        if (missile != null)
        {
            missile.Seek(target);

        }
        if (poisBullet != null)
        {
            poisBullet.Seek(target);
        }
    }
}
