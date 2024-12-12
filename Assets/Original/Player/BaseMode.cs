using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayMode
{
    void Update();
    void Activate(Player player);
    public void MoveJoystick(Vector2 vector2);
    public void Drag(InputValue input);
    public void PressButton();
}
