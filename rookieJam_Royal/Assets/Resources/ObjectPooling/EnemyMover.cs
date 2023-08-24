using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    public float movementDuration = 10.0f; // Time it takes for enemy to reach player

    void Start()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Move the enemy towards the player's position using DOTween
        transform.DOMove(playerPos.position, movementDuration).OnComplete(DestroyEnemy);
    }

    void DestroyEnemy()
    {
        // Return the enemy to the pool or destroy it as needed
        ObjectPooler.Instance.Free(gameObject);
    }
   
}
