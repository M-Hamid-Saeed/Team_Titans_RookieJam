using System.Collections.Generic;
using UnityEngine;

public class SoldierPooler : MonoBehaviour
{
    [SerializeField] PlayerUpdateAIController playerUpdateController;
    private Dictionary<int, GameObject> activeSoldiers = new Dictionary<int, GameObject>();
    private int uniqueIDCounter = 0;

    public GameObject GetNew(Vector3 spawnPos)
    {
        GameObject soldier = ObjectPooler.Instance?.SpawnFromPool("Soldier", spawnPos, Quaternion.Euler(new Vector3(0, 0, 0)));
        Debug.Log("Soldier Pooling");

        int uniqueID = uniqueIDCounter++; // Generate a unique identifier
        activeSoldiers.Add(uniqueID, soldier); // Store the reference in the dictionary

        // Add the soldier to the dictionary in PlayerUpdateAIController
        playerUpdateController.AddSoldierToDictionary(uniqueID, soldier);

        return soldier;
    }

    public void ReturnToPool(GameObject soldierObject)
    {
        ObjectPooler.Instance?.Free(soldierObject);

        // Find the soldier's unique identifier and remove it from the dictionary
        foreach (var pair in activeSoldiers)
        {
            if (pair.Value == soldierObject)
            {
                activeSoldiers.Remove(pair.Key);

                // Remove the soldier from the dictionary in PlayerUpdateAIController
                playerUpdateController.RemoveSoldierFromDictionary(pair.Key);

                break;
            }
        }
    }
}
