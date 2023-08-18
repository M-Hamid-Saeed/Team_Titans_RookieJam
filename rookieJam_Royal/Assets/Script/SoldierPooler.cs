
using UnityEngine;

public class SoldierPooler : MonoBehaviour
{
    [SerializeField] PlayerUpdateAIController playerUpdateController;
    public GameObject GetNew(Vector3 spawnPos)
    {
        GameObject soldier = ObjectPooler.Instance?.SpawnFromPool("Soldier", spawnPos, Quaternion.Euler(new Vector3(0, 0, 0)));
        Debug.Log("Soldier Pooling");
        playerUpdateController.pooledSoldiersList.Add(soldier);
        return soldier;

    }
    public void ReturnToPool(GameObject soldierObject)
    {
        playerUpdateController.pooledSoldiersList.Remove(soldierObject);
        ObjectPooler.Instance?.Free(soldierObject);
    }
}
