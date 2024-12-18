using UnityEngine;
using UnityEngine.InputSystem;

public class ModeManager : MonoBehaviour
{
    private Player _player;
    public IPlayMode _curMode;

    public void Initialize(Player player) => _player = player;
    public void ChangeMode(IPlayMode mode)
    {
        _curMode = mode;
        _curMode.Activate(_player);
    }

    public void Update()
    {
        if (_curMode == null) return;
        _curMode.Update();
    }
    public void OnMove(InputValue input) => _curMode.MoveJoystick(input.Get<Vector2>());
    public void OnCameraRotate(InputValue input) => _curMode.Drag(input);
    public void OnAttack(InputValue input) => _curMode.PressButton();
    //public void OnTurnShotMode(InputValue input) => TurnShotMode();
    //public void OnTurnMoveMode(InputValue input) => TurnMoveMode();
}
