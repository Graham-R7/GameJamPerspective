using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        onFoot.Jumping.performed += ctx => motor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProccessMove(onFoot.Walking.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
