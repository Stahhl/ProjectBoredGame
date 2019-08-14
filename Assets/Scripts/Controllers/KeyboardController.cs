using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    //Fields
    private PlayerController pC;
    private float moveSpeed;
    private float roatateSpeed;
    private float rotZ;

    // Start is called before the first frame update
    void Start()
    {
        pC = GetComponentInParent<PlayerController>();
        moveSpeed = 5f;
        roatateSpeed = 35f;
        rotZ = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGeneralButtons();
        UpdateCameraButtons();
        UpdateGameplayButtons();
    }
    void UpdateGeneralButtons()
    {

    }
    void UpdateCameraButtons()
    {
        //Move forward
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            pC.MainCameraObj.transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        }
        //Move backward
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            pC.MainCameraObj.transform.Translate(new Vector3(0, -moveSpeed * Time.deltaTime, 0));
        }
        //Move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            pC.MainCameraObj.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
        }
        //Move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            pC.MainCameraObj.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
        }
        //Rotate left
        if (Input.GetKey(KeyCode.Q))
        {
            rotZ += Time.deltaTime * roatateSpeed;
            Quaternion localRotation = Quaternion.Euler(0.0f, 0.0f, rotZ);
            pC.MainCameraObj.transform.rotation = localRotation;
        }
        //Rotate right
        if (Input.GetKey(KeyCode.E))
        {
            rotZ -= Time.deltaTime * roatateSpeed;
            Quaternion localRotation = Quaternion.Euler(0.0f, 0.0f, rotZ);
            pC.MainCameraObj.transform.rotation = localRotation;
        }
        //Reset position
        if (Input.GetKeyDown(KeyCode.Home))
        {
            pC.ResetCameraPos();
            rotZ = 0f;
        }
    }
    void UpdateGameplayButtons()
    {

    }
}
