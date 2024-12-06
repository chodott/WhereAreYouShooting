using Unity.Notifications.iOS;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MoveController : BaseMode
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private CharacterController _characterController;
    private Animator _animator;
    [SerializeField] private Weapon _equippedWeapon;

    private Vector3 _moveDirection;
    private Vector2 _moveInput;
    private Vector2 _rotateInput;

    private float _maxSpeed = 1.0f;
    private Vector3 _curVelocity;
    private float _acceleration = 2.0f;
    private float _deceleration = 1.0f;
    private Vector2 _lastInput;

    protected void Awake()
    {
        base.Awake();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    protected void FixedUpdate()
    {
        // 입력값 가져오기
        _moveDirection = transform.forward * _moveInput.y + transform.right * _moveInput.x;

        // 목표 속도 계산
        Vector3 targetVelocity = _moveDirection.normalized * _maxSpeed;

        // 현재 속도와 목표 속도 간 가속/감속 처리
        _curVelocity = Vector3.MoveTowards(
            _curVelocity,
            targetVelocity,
            (targetVelocity.magnitude > _curVelocity.magnitude ? _acceleration : _deceleration) * Time.deltaTime
        );

        // 이동 처리
        Vector3 movement = _curVelocity * Time.deltaTime;
        _characterController.Move(movement);

        Vector3 localVelocity = transform.InverseTransformDirection(_curVelocity); // 월드 속도를 로컬 속도로 변환

        _animator.SetFloat("VelocityX", localVelocity.z);
        _animator.SetFloat("VelocityZ", localVelocity.x);

        transform.Rotate(transform.up, _rotateInput.x);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(other is SphereCollider)
        {
            TurnShotMode();
        }
    }

    private void TurnShotMode()
    {
        _battleSceneUI.TurnShootMode();
    }

    private void TurnMoveMode()
    {
        _battleSceneUI.TurnMoveMode();
    }

    private void Attack()
    {
        if (_equippedWeapon == null) return;

        Vector3 bulletSpawnPosition = transform.position + transform.forward * 2 + transform.up;
        _equippedWeapon.Shoot(bulletSpawnPosition, transform.rotation);
    }

    private void EquipWeapon(Weapon weapon)
    {
        
    }


    public void OnMove(InputValue input) =>_moveInput = input.Get<Vector2>();
    public void OnCameraRotate(InputValue input) => _rotateInput = input.Get<Vector2>();

    public void OnAttack(InputValue input) => Attack();

    public void OnTurnShotMode(InputValue input) => TurnShotMode();
    public void OnTurnMoveMode(InputValue input) => TurnMoveMode();
}
