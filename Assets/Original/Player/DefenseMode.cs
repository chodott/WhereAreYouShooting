using UnityEngine;
using UnityEngine.InputSystem;

public class DefenseMode : IPlayMode
{
    private Player _player;
    private Vector3 _moveDirection;
    private Vector2 _moveInput;
    private Vector2 _rotateInput;

    private float _maxSpeed = 1.0f;
    private Vector3 _curVelocity;
    private float _acceleration = 2.0f;
    private float _deceleration = 1.0f;
    private Vector2 _lastInput;

    public void Update()
    {
        Transform characterTransform = _player.transform;
        _moveDirection = characterTransform.forward * _moveInput.y + characterTransform.right * _moveInput.x;

        Vector3 targetVelocity = _moveDirection.normalized * _maxSpeed;

        _curVelocity = Vector3.MoveTowards(
        _curVelocity,
        targetVelocity,
        (targetVelocity.magnitude > _curVelocity.magnitude ? _acceleration : _deceleration) * Time.deltaTime
        );

        // 이동 처리
        Vector3 movement = _curVelocity * Time.deltaTime;
        _player.GetComponent<CharacterController>().Move(movement);

        Vector3 localVelocity = characterTransform.InverseTransformDirection(_curVelocity); 

        Animator animator = _player.GetComponent<Animator>();
        animator.SetFloat("VelocityX", localVelocity.z);
        animator.SetFloat("VelocityZ", localVelocity.x);

        characterTransform.Rotate(characterTransform.up, _rotateInput.x);
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
        //_battleSceneUI.TurnShootMode();
    }

    private void TurnMoveMode()
    {
        //_battleSceneUI.TurnMoveMode();
    }


    //Interface

    public void Activate(Player player) => _player = player;
    public void MoveJoystick(Vector2 vector2) { _moveInput = vector2; }
    public void Drag(InputValue input) { _rotateInput = input.Get<Vector2>(); }
    public void PressButton() { }
}
