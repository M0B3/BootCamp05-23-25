using UnityEngine;
using UnityEngine.InputSystem;

public class testinput : MonoBehaviour
{
    public void TirEnnemy(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
            Debug.Log("tir ennemy");
    }

    public void useItemA(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            Debug.Log("UseItemA");
    }


    public void selfshoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            Debug.Log("Selfshoot");

    }

    public void UseItemB(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            Debug.Log("UseItemB");

    }

}