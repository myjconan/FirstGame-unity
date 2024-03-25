using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public static Interact InteractBtn;
    public bool IsInteractBtnPressed;
    private void Awake()
    {
        InteractBtn = this;
    }
    public void InteractBtnPressed()
    {
        IsInteractBtnPressed = true;
        Invoke("InteractBtnReturn", 0.3f);
    }
    public void InteractBtnReturn()
    {
        IsInteractBtnPressed = false;
    }
    public bool GetInteractBtn()
    {
        return IsInteractBtnPressed;
    }
}
