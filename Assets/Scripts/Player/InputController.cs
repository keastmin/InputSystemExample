using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputController : MonoBehaviour
{
    private PlayerInput playerInput;

    // 테스트
    private InputAction interact;

    void Start()
    {
        if (TryGetComponent(out playerInput))
        {
            BindKey();
        }
    }

    void Update()
    {
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
        interact = playerInput.actions.FindAction("Interaction");
    }
}