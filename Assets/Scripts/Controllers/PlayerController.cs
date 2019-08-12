using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject MainCameraObj { get; private set; }
    public Camera MainCamera { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        MainCameraObj = MainCamera.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
