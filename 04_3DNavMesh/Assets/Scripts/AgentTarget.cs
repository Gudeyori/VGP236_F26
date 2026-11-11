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
        // this is += becaust clickAction.performead is an action!
        clickAction.performed += OnMouseClick;
    }

    private void OnEnable()
    {
        input.Enable();
        clickAction.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
        clickAction.Disable();
    }

    void OnMouseClick(InputAction.CallbackContext callbackContext)
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray cameraRay = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(cameraRay, out hitInfo, 100.0f))
        {
            if(hitInfo.collider != null)
            {
                transform.position = hitInfo.point;
            }
        }
    }
}
