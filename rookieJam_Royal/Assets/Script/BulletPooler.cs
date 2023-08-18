using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
    [SerializeField] Bullet bullet;



    public GameObject GetNew(Vector3 spawnPos)
    {
        return ObjectPooler.Instance?.SpawnFromPool("Bullet", spawnPos,Quaternion.Euler(new Vector3(0, 0, 0)));
    }
    public void ReturnToPool(GameObject bulletObject)
    {
        Debug.Log("BULLET POOLED");
        ObjectPooler.Instance?.Free(bulletObject);
    }
}
