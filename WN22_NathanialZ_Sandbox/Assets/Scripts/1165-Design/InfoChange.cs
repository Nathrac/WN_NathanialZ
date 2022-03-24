using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoChange : MonoBehaviour
{
    public int intToSave;
    public float floatToSave;
    public string stringToSave;
    public bool boolToSave;

    public Slider intSlider, floatSlider;

    public InputField playerName;

    public Text floatText;
    public Text intText;
    public TextMeshProUGUI dataText;

    public void ChangeSlider()
    {
        intToSave = Mathf.RoundToInt(intSlider.value);
        intText.text = intToSave.ToString();
        floatToSave = floatSlider.value;
        floatText.text = floatToSave.ToString();
    }

    public void DisplayInfo()
    {

        intText.text = intToSave.ToString();
        floatText.text = floatToSave.ToString();
        intSlider.value = (float)intToSave;
        floatSlider.value = floatToSave;
    }

    public void UpdateInfo()
    {
        intToSave = Mathf.RoundToInt(intSlider.value);
        floatToSave = floatSlider.value;
        stringToSave = playerName.text;
        dataText.text = stringToSave;
    }

}
