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

    protected void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

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

    }
}
