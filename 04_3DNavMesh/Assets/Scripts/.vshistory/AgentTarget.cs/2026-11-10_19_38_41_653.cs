using UnityEngine;
using UnityEngine.InputSystem;

public class AgentTarget : MonoBehaviour
{
    private PlayerInput input = null;
    private InputAction clickAction = null;


    private void Awake()
    {
        input = new PlayerInput();
        clickAction = input.Player.Attack;
    }

    private void OnEnable()
    {
        input.Enable();
        clickAction.Enable();
    }

    void OnMouseClick(InputAction.CallbackContext callbackContext)
    {

    }
}
