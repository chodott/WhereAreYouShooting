using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponScriptableObject _weaponScriptableObject;
    public int WeaponType
    {
        get { return _weaponScriptableObject.type; }
    }

    void Start()
    {
        transform.position = _weaponScriptableObject.spawnPosition;
        transform.rotation = Quaternion.Euler(_weaponScriptableObject.spawnRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 spawnPos, Quaternion rotation)
    {
        Instantiate(_weaponScriptableObject.bulletPrefab, spawnPos, rotation);
    }
}
