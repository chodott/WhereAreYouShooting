using Unity.Cinemachine;
using UnityEngine;

public class BattleSceneUI : MonoBehaviour
{
    private GameObject _moveJoystick;
    private GameObject _shootButton;
    [SerializeField] private CinemachineCamera _topViewCinemachineCamera;
    [SerializeField] private CinemachineCamera _firstViewCinemachineCamera;
    void Start()
    {
        _moveJoystick = transform.Find("MoveJoystickArea").gameObject;
        _shootButton = transform.Find("ShootButton").gameObject;
    
    }

    public void TurnMoveMode()
    {
        _moveJoystick.SetActive(true);
        _shootButton.SetActive(false);
        _topViewCinemachineCamera.Priority = 0;
        _firstViewCinemachineCamera.Priority = 1;
    }

    public void TurnShootMode()
    {
        _moveJoystick.SetActive(false);
        _shootButton.SetActive(true);
        _topViewCinemachineCamera.Priority = 1;
        _firstViewCinemachineCamera.Priority = 0;

    }
}
