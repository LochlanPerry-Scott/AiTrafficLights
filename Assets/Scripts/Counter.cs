using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int horizontalCount = 0;
    public int verticalCount = 0;
    public Text textv;
    public Text texth;

    private void Update()
    {
        textv.text = "Vertical count is: " + verticalCount;
        texth.text = "Horizontal count is: " + horizontalCount;
    }
}
