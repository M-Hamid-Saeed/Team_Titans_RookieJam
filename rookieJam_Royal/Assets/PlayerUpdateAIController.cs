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
<<<<<<< Updated upstream
    public bool canAimMove = false;
    public Transform lookTarget;
    // Update is called once per frame
    void Update()
    {
        if (canAimMove)
            LookRotation();
        foreach (GameObject soldier in pooledSoldiersList)
        {
            soldier.GetComponent<fireController>().DoShoot();
          
            Vector3 lookAtDirection = (lookTarget.position - soldier.transform.position).normalized;
            float angle = Mathf.Atan2(lookAtDirection.y, lookAtDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f);

            // Apply rotation to the soldier
            Quaternion soldierRotation = soldier.transform.rotation;
            soldierRotation.y = rotation.y;
            soldierRotation.x = rotation.x;
            soldierRotation.z = 0;
=======
    public Transform lookTarget;
    public bool canAimMove;
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject soldier in pooledSoldiersList)
        {
            if (Input.GetMouseButton(0))
            {
                soldier.GetComponent<fireController>().DoShoot();
                Vector3 lookAtDirection = (lookTarget.position - soldier.transform.localPosition).normalized;
                    float angle = Mathf.Atan2(lookAtDirection.y, lookAtDirection.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.Euler(0f, angle, 0f);
                    soldier.transform.localRotation = rotation;
                
            }
>>>>>>> Stashed changes
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

        Vector3 rot = transform.localPosition;
        rot.x = Mathf.Clamp(rot.x, -maxRotationX, maxRotationX);
        rot.y = Mathf.Clamp(rot.y, -maxRotationY, maxRotationY);
        transform.localPosition = rot;
    }
}
