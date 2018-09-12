using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour 
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "切换"))
        {
            Application.LoadLevel("b");
        }
    }
}
