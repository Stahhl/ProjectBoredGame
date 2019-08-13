using UnityEngine;
using TMPro;

public class AreaInfoPanel : _uiElement
{
    public TextMeshProUGUI areaNameText;
    public TextMeshProUGUI areaTypeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewArea(Area newArea)
    {
        //Debug.Log("NewAreaHighlighted! ");
        areaNameText.text = newArea.MyName;
        areaTypeText.text = "Terrain: " + newArea.MyAreaType;
    }
}
