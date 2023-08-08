using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyMover : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.forward = Vector3.Slerp(transform.forward, Quaternion.EulerRotation(playerPos.rotation.x,playerPos.rotation.y,playerPos.rotation.z), Time.deltaTime * 100);

        transform.DOMove(playerPos.position, 10); 
    }
}
