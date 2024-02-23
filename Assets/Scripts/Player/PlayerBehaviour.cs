using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float velocity;

    private Vector3 moveDirection;
    private GameControls playerInput;
    
    public static PlayerBehaviour instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        playerInput = new GameControls();
        playerInput.Enable();
        SetupInputs();
    }

    private void Update()
    {
        transform.Translate(moveDirection * (velocity * Time.deltaTime));
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
        Vector2 InputDirection = context.ReadValue<Vector2>();

        moveDirection.x = InputDirection.x;
        moveDirection.y = 0f;
        moveDirection.z = InputDirection.y;
    }

    public void DisableInput()
    {
        playerInput.Player.Move.Disable();
    }
    private void SetupInputs()
    {
        playerInput.Player.Move.started += MovePlayer;
        playerInput.Player.Move.performed += MovePlayer;
        playerInput.Player.Move.canceled += MovePlayer;
        playerInput.Player.RestartGame.started += RestartScene;
    }

    private void RestartScene(InputAction.CallbackContext context)
    {
        SceneManage.instance.RestartGame();
    }

    private void OnDisable()
    {
        playerInput.Player.Move.started -= MovePlayer;
        playerInput.Player.Move.performed -= MovePlayer;
        playerInput.Player.Move.canceled -= MovePlayer;
        DisableInput();
    }
}
