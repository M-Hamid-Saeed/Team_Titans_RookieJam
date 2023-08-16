
using UnityEngine;

public class SoldierPooler : MonoBehaviour
{
    public GameObject GetNew(Vector3 spawnPos)
    {
        return ObjectPooler.Instance?.SpawnFromPool("Soldier", spawnPos,Quaternion.Euler(new Vector3(0, 0, 0)));
    }
    public void ReturnToPool(GameObject soldierObject)
    {
        ObjectPooler.Instance?.Free(soldierObject);
    }
}
