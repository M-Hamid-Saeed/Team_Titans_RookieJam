using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] WeaponData firingData;

	private int  bulletDamage;
    [SerializeField] BulletPooler bulletPooler;
	private WaitForSeconds fireRateTime;
    private IEnumerator waitForHold;
	public Transform muzzlePoint;
	public Transform aimPoint;
    private bool canShot = false;
    // Start is called before the fi
	// rst frame update
    void Start()
    {
		InitializeWeapon();
    }

    

	private void InitializeWeapon()
	{
		firingData.bullet.speed = firingData.dataSheet.bulletSpeed;
		bulletDamage = firingData.dataSheet.damage;
		fireRateTime = new WaitForSeconds(firingData.dataSheet.fireRate);
        waitForHold = new WaitUntil(() => canShot);

		StartCoroutine(BulletShoot());
	}

    public void shoot()
    {
        canShot = true;
    }
    private IEnumerator BulletShoot()
    {
        yield return waitForHold;
        while (canShot) // Keep shooting continuously
        {
            GameObject bulletObject = bulletPooler.GetNew(muzzlePoint.position); // Get a bullet GameObject from the pooler

            if (bulletObject == null)
            {
                yield break; // Exit the coroutine if no bullet is available
            }

            // Cast the GameObject to a Bullet instance
            Bullet bulletClone = bulletObject.GetComponent<Bullet>();

           

            Vector3 newSpreadAimPoint = new Vector3(aimPoint.position.x + Random.Range(-1f, 1f), aimPoint.position.y, aimPoint.position.x);
            bulletClone.SetDamage(bulletDamage);
            bulletClone.SetHitPosition(newSpreadAimPoint);
            Vector3 offsetMuzzlePosition = new Vector3(muzzlePoint.position.x - 1f, muzzlePoint.position.y, muzzlePoint.position.z);
            bulletClone.SetDirection(( newSpreadAimPoint- offsetMuzzlePosition).normalized);

            yield return fireRateTime; // Wait for the fire rate before shooting again
            canShot = false;
        }

        yield return BulletShoot();
    }

}
