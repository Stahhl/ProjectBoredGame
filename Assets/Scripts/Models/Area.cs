using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AreaType
{
    NULL,
    Ground,
    Water,
}

public class Area : MonoBehaviour
{
    private Color myColor;

    public string MyName { get; private set; }

    [SerializeField]
    private AreaType myAreaType;
    public AreaType MyAreaType
{
        get { return myAreaType; }
    }

    // Start is called before the first frame update
    void Start()
    {
        MyName = gameObject.name;

        switch(myAreaType)
        {
            case AreaType.NULL:
                myColor = Color.white;
                break;
            case AreaType.Ground:
                myColor = Color.yellow;
                break;
            case AreaType.Water:
                myColor = Color.blue;
                break;
            default:
                throw new UnityException();
        }
        UpdateColor(Color.white);
        UpdateColor(myColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Marked(bool value)
    {
        if (value == true)
            UpdateColor(Color.green);
        if (value == false)
            UpdateColor(myColor);
    }
    void UpdateColor(Color color)
    {
        this.GetComponentInChildren<SpriteRenderer>().color = color;
    }
}
