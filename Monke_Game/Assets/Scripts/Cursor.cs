using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 convertedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        convertedPos.z = 0;

        transform.position = convertedPos;
    }
}
