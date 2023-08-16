using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireController : MonoBehaviour
{
    [SerializeField] Shoot shootSystem;
   
   public void DoShoot()
    {
            shootSystem.shoot();
    }
 
}
