using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputController : MonoBehaviour
{
    private PlayerInput playerInput;

    // 테스트
    private InputAction interact;


    private InputAction moveAction;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        if (TryGetComponent(out playerInput))
        {
            BindKey();
        }
    }

    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Debug.Log(moveValue.ToString());


        if (interact != null)
        {
            Debug.Log($"Interact Phase: {interact.phase}");

            if (interact.IsPressed())
            {
                Debug.Log("🔹 Interact WasPerformed");
            }

            if (interact.WasCompletedThisFrame())
            {
                Debug.Log("🔸 Interact WasCompleted");
            }
        }
    }

    private void BindKey()
    {
        interact = playerInput.actions.FindAction("Interact");

        if (interact == null)
        {
            Debug.LogError("❌ 'Interact' 액션을 찾지 못했습니다.");
            return;
        }

        interact.Enable(); // 명시적으로 Enable
    }
}