using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimationPrefs : MonoBehaviour
{
    [SerializeField] AnimationSaving uiC;
    [SerializeField] AnimationSaving uiO;

    [SerializeField] TextMeshProUGUI tmpC;
    [SerializeField] TextMeshProUGUI tmpO;
    

    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }

 
    //save all int values used to determine bool states of state machine
    public void SaveGame()
    {
        PlayerPrefs.SetInt("characterState", uiC.p);
        PlayerPrefs.SetInt("objectState", uiO.p);
        PlayerPrefs.SetString("csS", uiC.sa);
        PlayerPrefs.SetString("osS", uiO.sa);

        PlayerPrefs.Save();

        Debug.Log("Data Saved");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("characterState"))
        {
            
            uiC.p = PlayerPrefs.GetInt("characterState");
            uiC.sa = PlayerPrefs.GetString("csS");
            tmpC.text = "Your character state save was: " + "\n" + uiC.sa;
            uiC.tmp.text = uiC.sa;
            uiC.LoadA();

            uiO.p = PlayerPrefs.GetInt("objectState");
            uiO.sa = PlayerPrefs.GetString("osS");
            tmpO.text = "Your object state save was: " + "\n" + uiO.sa;
            uiO.tmp.text = uiO.sa;
            uiO.LoadA();

            Debug.Log("Data Loaded");
        }
        else
        {
            Debug.Log("No data to load");
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        
        uiC.p = 1;
        uiC.sa = "";
        uiC.animator.SetBool("isStarted", false);

        uiO.p = 1;
        uiO.sa = "";
        uiO.animator.SetBool("isStarted", false);

        Debug.Log("Data Reset");
    }

    public void QuitGame()
    {
        SaveGame();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
