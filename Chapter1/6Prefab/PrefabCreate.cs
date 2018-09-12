using UnityEngine;
using System.Collections;

public class PrefabCreate : MonoBehaviour
{
    public GameObject prefab;

    void Update()
    {
        //位置
        float x = Random.Range(-10, 10);
        float y = Random.Range(-10, 10);
        float z = Random.Range(-10, 10);
        Vector3 pos = new Vector3(x, y, z);
        //实例化
        Instantiate(prefab, pos, Quaternion.identity);
    }
}