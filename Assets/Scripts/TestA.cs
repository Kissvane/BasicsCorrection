using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestA : MonoBehaviour
{
    public TestB other;
    public int value;
    public int result;
    private string message = "I'm A my result is ";

    public void Start()
    {
        ShowMessage();
    }

    public void Calculate()
    {
        result = value + other.value;
    }

    private void ShowMessage()
    {
        Debug.Log(message + value + other.otherMessage);
    }
}
