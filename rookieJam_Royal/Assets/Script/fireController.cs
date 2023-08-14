using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireController : MonoBehaviour
{
    [SerializeField] Shoot shootSystem;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            shootSystem.shoot();
    }
}
