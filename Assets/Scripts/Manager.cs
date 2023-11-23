using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Input input;
    public static void Init(Player myPlayer)
    {
        input = new Input();

        input.InGame.Move.performed += ctx =>
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector2>());
        };

        input.InGame.Jump.performed += ctx =>
        {
            myPlayer.Jump();
        };

        input.InGame.Shoot.performed += ctx =>
        {
            myPlayer.Shoot();
        };
        
    }

    public static void Init2(Bullet myBullet)
    {
        input.InGame.Red.performed += ctx =>
        {
            myBullet.setRed();
        };
        input.InGame.Green.performed += ctx =>
        {
            myBullet.setGreen();
        };
        input.InGame.Blue.performed += ctx =>
        {
            myBullet.setBlue();
        };
    }

    public static void SetGameControls()
    {
        input.InGame.Enable();

    }
}
