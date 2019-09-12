using UnityEngine;

public class Buttons : MonoBehaviour {

    public bool isOn = false;

    public void MouseEnter()
    {
        isOn = true;
    }

    public void MouseExit()
    {
        isOn = false;
    }

}
