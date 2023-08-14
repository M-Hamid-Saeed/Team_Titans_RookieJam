
using UnityEngine;



[CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObjects/WeaponData")]
public class WeaponData : ScriptableObject
{
    #region Data Container Defination


    [System.Serializable]
    public struct Data
    {
        public float fireRate;
        public int damage;
        public float bulletSpeed;
    }

    #endregion

    [Header("----- Weapons Data ---------")]

    [Space]
    public Bullet bullet;

    [Space]
    public Data dataSheet;





}
