using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour
{
    void OnGUI()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (GUI.Button(new Rect(0, 0, 100, 50), "开始"))
            audio.Play();
        if (GUI.Button(new Rect(100, 0, 100, 50), "停止"))
            audio.Stop();
    }
}