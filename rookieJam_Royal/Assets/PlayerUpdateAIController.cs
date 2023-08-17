using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpdateAIController : MonoBehaviour
{
   public List<GameObject> pooledSoldiersList = new List<GameObject>();
    [SerializeField] Transform MissleAimPoint;
    [SerializeField] Transform MisslespawnLocation;
    [SerializeField] GameObject missle;
    [SerializeField] InputManager input;
    [SerializeField] Transform AimpointBullet;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxRotationX;
    [SerializeField] float maxRotationY;
    [SerializeField] float lerpFactor;
    public bool canAimMove;
    // Update is called once per frame
    void Update()
    {
        foreach(GameObject soldier in pooledSoldiersList)
        {
            soldier.GetComponent<fireController>().DoShoot();
        }
        if(canAimMove)
          LookRotation();
    }
    public void onMissleButtonPressed()
    {
        GameObject mis = Instantiate(missle, new Vector3(MisslespawnLocation.position.x, MisslespawnLocation.position.y, MisslespawnLocation.position.z), Quaternion.identity);
        Vector3 dir = MissleAimPoint.position - mis.transform.position;
        mis.GetComponent<Missile>().SetDirection(dir);

    }
    private void LookRotation()
    {

        float targetLookAmountX = input.Horizontal *moveSpeed;
        float targetLookAmountY = -input.Vertical * moveSpeed;

        targetLookAmountX += AimpointBullet.localPosition.x;
        Vector3 lookDirection = new Vector3(targetLookAmountX,AimpointBullet.position.y, AimpointBullet.position.z);

        // Quaternion rotTarget = Quaternion.LookRotation(lookDirection);
        AimpointBullet.localPosition = Vector3.Lerp(AimpointBullet.position, lookDirection, lerpFactor * Time.deltaTime);

        Quaternion rot = transform.rotation;
        rot.x = Mathf.Clamp(rot.x, -maxRotationX, maxRotationX);
        rot.y = Mathf.Clamp(rot.y, -maxRotationY, maxRotationY);
        transform.rotation = rot;
    }
}
