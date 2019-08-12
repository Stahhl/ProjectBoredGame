using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseController : MonoBehaviour
{
    //Fields
    private PlayerController pC;
    [SerializeField]
    private LayerMask LayerAreaId;
    private Area lastAreaUnderMouse = null;
    Event currentEvent;
    // Camera Dragging bookkeeping variables
    Vector3 lastMouseGroundPlanePosition;
    Vector3 cameraTargetOffset;

    Vector3 currentMousePosition;
    Vector3? mouseDragStart;

    //Properties
    public Area AreaUnderMouse { get; private set; }

    void Start()
    {
        pC = GetComponentInParent<PlayerController>();
        mouseDragStart = null;
    }

    // Update is called once per frame
    void Update()
    {
        AreaUnderMouse = MouseToArea();
        currentMousePosition = Input.mousePosition;

        UpdateDrag();
        UpdateScroll();

        if (AreaUnderMouse != lastAreaUnderMouse)
            UpdateArea();
    }
    void UpdateDrag()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseDragStart = currentMousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            mouseDragStart = null;
        }
        if(mouseDragStart != null)
        {
            float dist = Vector3.Distance(currentMousePosition, (Vector3)mouseDragStart);

            if(dist >= 1)
            {
                Vector3 dir = pC.MainCamera.ScreenToViewportPoint((Vector3)mouseDragStart - currentMousePosition);

                // update x and y but not z
                Vector3 move = new Vector3(dir.x * 10, dir.y * 10, 0);

                pC.MainCameraObj.transform.Translate(move, Space.World);
                mouseDragStart = currentMousePosition;
            }
        }
    }
    void UpdateArea()
    {
        if (AreaUnderMouse != null)
            AreaUnderMouse.Marked(true);
        if (lastAreaUnderMouse != null)
            lastAreaUnderMouse.Marked(false);

        lastAreaUnderMouse = AreaUnderMouse;
    }
    Area MouseToArea()
    {
        Ray mouserRay = pC.MainCamera.ScreenPointToRay(currentMousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(mouserRay, out hitInfo, Mathf.Infinity, LayerAreaId.value))
        {
            GameObject areaGo = hitInfo.rigidbody.gameObject;
            return areaGo != null ? areaGo.GetComponent<Area>() : null;
        }

        return null;
    }

    void UpdateScroll()
    {
        float scrollAmount = Input.GetAxis("Mouse ScrollWheel");

        if (scrollAmount == 0)
            return;


        Vector3 oldPos = pC.MainCameraObj.transform.position;

        if ((oldPos.z >= 5 && scrollAmount > 0) || 
            (oldPos.z <= -5 && scrollAmount < 0))
        {
            return;
        }

        scrollAmount = scrollAmount * 10;
        Vector3 newPos = new Vector3(oldPos.x, oldPos.y, oldPos.z + scrollAmount);

        pC.MainCameraObj.transform.position = newPos;
    }
}
