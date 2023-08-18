
using UnityEngine;

public class SoldierPooler : MonoBehaviour
{
    [SerializeField] PlayerUpdateAIController playerUpdateController;
    public GameObject GetNew(Vector3 spawnPos)
    {
        GameObject soldier = ObjectPooler.Instance?.SpawnFromPool("Soldier", spawnPos, Quaternion.Euler(new Vector3(0, 0, 0)));
        playerUpdateController.pooledSoldiersList.Add(soldier);
        soldier.transform.SetParent(transform.GetChild(0));
        return soldier;

    }
    public void ReturnToPool(GameObject soldierObject)
    {
        playerUpdateController.pooledSoldiersList.Remove(soldierObject);
        ObjectPooler.Instance?.Free(soldierObject);
    }
}
