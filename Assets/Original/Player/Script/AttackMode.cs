using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AttackMode : IPlayMode
{
    private Player _player;
    private LaserManager _laserManager;
    private Quaternion _targetRotation;
    private const float rotateSpeed = 3.0f;
    public void Update()
    {
        _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, _targetRotation, rotateSpeed * Time.deltaTime);
    }
    public void Activate(Player player)
    {
        _player = player;
        _laserManager = player.GetComponent<LaserManager>();
    }

    public void MoveJoystick(Vector2 vector2) 
    {
        if (vector2.x <= 0.0f && vector2.y <= 0.0f) return;
        Vector3 directionVec = new Vector3(vector2.x, 0, vector2.y);
        directionVec.Normalize();
        _targetRotation = Quaternion.LookRotation(directionVec);
    }

    public void Drag(InputValue input) { }
    public void PressButton()
    {
        _player.Change();
        _player.Attack();
    }

    public void Change()
    {
        
    }
}
