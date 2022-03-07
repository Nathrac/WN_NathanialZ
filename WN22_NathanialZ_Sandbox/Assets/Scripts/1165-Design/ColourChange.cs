using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourChange : MonoBehaviour
{
    [SerializeField] GameObject obj;
    Transform objTransform;
   
    [SerializeField] MeshRenderer objColor;
    [SerializeField] Slider red, green, blue, scaly;

    // Start is called before the first frame update
    void Start()
    {
        objTransform = obj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColour()
    {
        Color color = objColor.material.color;
        color.r = red.value;
        color.g = green.value;
        color.b = blue.value;
        objColor.material.color = color;
        objColor.material.SetColor("Emission", color);
    }

    public void ObjectScale()
    {
        Vector3 newScale = new Vector3(scaly.value, scaly.value, scaly.value);
        objTransform.localScale = newScale;
    }
}
