using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _animator;
    [SerializeField] private Weapon _equippedWeapon;

    private DefenseMode _defenseMode;
    private AttackMode _attackMode;
    private ModeManager _modeManager;
    private LaserManager _laserManager;

    protected void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _laserManager = GetComponent<LaserManager>();

        _defenseMode = new DefenseMode();
        _attackMode = new AttackMode();
        _modeManager = gameObject.AddComponent<ModeManager>();
    }

    protected void Start()
    {
        _modeManager.Initialize(this);
        _modeManager.ChangeMode(_attackMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void FixedUpdate()
    {
        _modeManager.Update();
    }
    public void Attack()
    {
        if (_equippedWeapon == null) return;
        Vector3 bulletSpawnPosition = transform.position + transform.forward * 2 + transform.up;
        _equippedWeapon.Shoot(bulletSpawnPosition, transform.rotation);
    }

    private void EquipWeapon(Weapon weapon)
    {
        _equippedWeapon = weapon;
        _animator.SetInteger("WeaponType", weapon.WeaponType);
        weapon.transform.SetParent(transform, false);
    }

    public void Change()
    {
        Weapon[] weapons = FindObjectsByType<Weapon>(FindObjectsSortMode.None);
        int type = _equippedWeapon.WeaponType + 1;
        type %= 6;
        foreach (var weapon in weapons)
        {
            if(type == weapon.WeaponType) EquipWeapon(weapon);
        }
    }
}
