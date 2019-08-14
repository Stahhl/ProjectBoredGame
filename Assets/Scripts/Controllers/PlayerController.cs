using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Properties
    public GameObject MainCameraObj { get; private set; }
    public Camera MainCamera { get; private set; }

    //Controllers - controllers are only cached in PlayerController
    //All other classes calls controllers through PlayerController
    //example: playerController.mouseController
    public MouseController mouseController { get; private set; }
    public UiController uiController { get; private set; }

    //SerializeField
    //Set in inspector
    [SerializeField]
    private GameObject uiControllerObj;

    //Fields
    //Set in code
    private Vector3 originalCameraPos;
    private Quaternion originalCameraRot;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        MainCameraObj = MainCamera.transform.parent.gameObject;

        originalCameraPos = MainCameraObj.transform.position;
        originalCameraRot = MainCameraObj.transform.rotation;

        mouseController = this.GetComponent<MouseController>();
        uiController = uiControllerObj.GetComponent<UiController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewAreaHighlighted(Area newArea)
    {
        uiController.NewAreaHighlighted(newArea);
    }
    public void ResetCameraPos()
    {
        Debug.Log("ResetCameraPos: " + MainCameraObj.transform.position + " " + originalCameraPos);
        MainCameraObj.transform.position = originalCameraPos;
        MainCameraObj.transform.rotation = originalCameraRot;
    } 
}
