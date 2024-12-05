using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "Scriptable Objects/WeaponScriptableObject")]
public class WeaponScriptableObject : ScriptableObject
{
    public GameObject bulletPrefab;
    public string weaponName;
    public Vector3 spawnPosition;
    public Vector3 spawnRotation;
    public float power;
    public float bulletCount;

}
