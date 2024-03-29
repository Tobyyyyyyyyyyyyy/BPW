using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Player_Controls player_controls;
    public Vector2 movement_input;

    private void OnEnable()
    {
        if (player_controls == null)
        {
            player_controls = new Player_Controls();
            player_controls.Playermovement.Movement.performed += i => movement_input = i.ReadValue<Vector2>();
        }

        player_controls.Enable();
    }

    private void OnDisable()
    {
        player_controls.Disable();
    }
}
