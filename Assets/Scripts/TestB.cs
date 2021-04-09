using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestB : MonoBehaviour
{
    public TestA other;
    public int value;
    public int result;
    private string message = "I'm B my result is ";
    public string otherMessage = "This is the end !";

    public void Calculate()
    {
        result = value * other.value;
    }

    public void ShowMessage()
    {
        Debug.Log(message + value);
    }
}
