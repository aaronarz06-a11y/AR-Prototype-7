using UnityEngine;
using UnityEngine.UI;

public class PianoKeys : MonoBehaviour
{
    public Image keyA;
    public Image keyS;
    public Image keyD;
    public Image keyF;

    public Color pressedColor = Color.green;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        keyA.color = pressedColor;

        if (Input.GetKeyUp(KeyCode.A))
        keyA.color = Color.white;


        if (Input.GetKeyDown(KeyCode.S))
        keyS.color = pressedColor;

        if (Input.GetKeyUp(KeyCode.S))
        keyS.color = Color.white;


        if (Input.GetKeyDown(KeyCode.D))
        keyD.color = pressedColor;

        if (Input.GetKeyUp(KeyCode.D))
        keyD.color = Color.white;


        if (Input.GetKeyDown(KeyCode.F))
        keyF.color = pressedColor;

        if (Input.GetKeyUp(KeyCode.F))
        keyF.color = Color.white;
    }
}