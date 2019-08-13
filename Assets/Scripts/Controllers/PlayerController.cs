using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject MainCameraObj { get; private set; }
    public Camera MainCamera { get; private set; }

    public MouseController mouseController { get; private set; }
    public UiController uiController { get; private set; }

    [SerializeField]
    private GameObject uiControllerObj;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        MainCameraObj = MainCamera.transform.parent.gameObject;

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
}
