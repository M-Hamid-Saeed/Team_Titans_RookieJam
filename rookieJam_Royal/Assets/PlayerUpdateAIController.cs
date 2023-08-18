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
    public bool canAimMove = false;
    

    // Update is called once per frame
    void Update()
    {
        if (canAimMove)
            LookRotation();
        foreach (GameObject soldier in pooledSoldiersList)
        {
            if (Input.GetMouseButton(0))
            {
                soldier.GetComponent<fireController>().DoShoot();
                soldier.transform.LookAt(AimpointBullet);
            }

        }
       
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

        Vector3 rot = AimpointBullet.localPosition;
        rot.x = Mathf.Clamp(rot.x, maxRotationX, maxRotationY);
       // rot.y = AimpointBullet.position.y;
        //rot.y = Mathf.Clamp(rot.y, 25, 42);
        AimpointBullet.localPosition = rot;
    }
}
