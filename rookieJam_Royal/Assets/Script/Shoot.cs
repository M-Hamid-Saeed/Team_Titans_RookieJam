using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    ObjectPooler OP;
    public GameObject bullet;
    public bool isDown = false;
    // Start is called before the first frame update
    void Start()
    {
        OP = ObjectPooler.Instance;
        InvokeRepeating("SpawnBullets", 0.1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBullets()
    {
        OP.SpawnFromPool("Bullet", transform.position, bullet.transform.rotation);
    }
}
