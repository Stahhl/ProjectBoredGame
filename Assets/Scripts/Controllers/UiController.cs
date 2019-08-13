using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private GameObject areaInfoPanelObj;
    private AreaInfoPanel areaInfoPanel;

    // Start is called before the first frame update
    void Start()
    {
        areaInfoPanel = this.GetComponent<AreaInfoPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewAreaHighlighted(Area newArea)
    {
        if (newArea == null)
        {
            areaInfoPanelObj.SetActive(false);
        }
        else
        {
            areaInfoPanelObj.SetActive(true);
            areaInfoPanel.NewArea(newArea);
        }
    }
}
