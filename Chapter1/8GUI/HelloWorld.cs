using UnityEngine;
using System.Collections;

public class HelloWorld : MonoBehaviour
{
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 200), "Hello World!");
    }
}