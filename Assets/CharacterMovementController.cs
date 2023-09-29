using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public VariableJoystick joystick;
    public CharacterController controller;
    public Canvas inputCanvas;
    public bool isJoystick;

    public void Start()
    {
        EnableJoystickInput();
    }

    public void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (isJoystick)
        {
            var movementDirection = new Vector2(joystick.Direction.x,joystick.Direction.y);
            
        }
    }
}
