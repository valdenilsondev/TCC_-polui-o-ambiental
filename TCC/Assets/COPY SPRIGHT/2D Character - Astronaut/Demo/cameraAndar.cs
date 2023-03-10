using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAndar : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
