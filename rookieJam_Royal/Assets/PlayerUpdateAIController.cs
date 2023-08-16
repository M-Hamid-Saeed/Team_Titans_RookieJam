using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpdateAIController : MonoBehaviour
{
   public List<GameObject> pooledSoldiersList = new List<GameObject>();
    [SerializeField] Transform MissleAimPoint;
    [SerializeField] Transform MisslespawnLocation;
    [SerializeField] GameObject missle;
    // Update is called once per frame
    void Update()
    {
        foreach(GameObject soldier in pooledSoldiersList)
        {
            soldier.GetComponent<fireController>().DoShoot();
        }
    }
    public void onMissleButtonPressed()
    {
        GameObject mis = Instantiate(missle, new Vector3(MisslespawnLocation.position.x, MisslespawnLocation.position.y, MisslespawnLocation.position.z), Quaternion.identity);
        Vector3 dir = MissleAimPoint.position - mis.transform.position;
        mis.GetComponent<Missile>().SetDirection(dir);

       

    }

}
