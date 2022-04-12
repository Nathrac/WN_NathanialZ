using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SaveSerial : MonoBehaviour
{
    InfoChange di;


    private void Awake()
    {
        di = GetComponent<InfoChange>();
    }
    public void SaveGame()
    {
        di.UpdateInfo();
      
        //Constructs a new binary format object
        BinaryFormatter bf = new BinaryFormatter();
        //Constructs a new file stream object
        FileStream file = File.Create(Application.persistentDataPath + "/myData.vxr");
        //Constructs a new SaveData object to access the serializable variables
        SaveData data = new SaveData();
        //Saves local variable values to SaveData vaiables
        data.savedInt = di.intToSave;
        data.savedFloat = di.floatToSave;
        data.savedString = di.stringToSave;
        data.savedBool = di.boolToSave;
        
        bf.Serialize(file, data);
        //Closes file stream
        file.Close();
        di.dataText.text = "Hi "+di.stringToSave +". Your number is " + di.intToSave.ToString();
        Debug.Log("Your game is saved");

    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/myData.vxr"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/myData.vxr", FileMode.Open);

            SaveData data = bf.Deserialize(file) as SaveData;
            file.Close();

            di.intToSave = data.savedInt;
            di.floatToSave = data.savedFloat;
           di.boolToSave = data.savedBool;
            di.stringToSave = data.savedString;

           
            Debug.Log("Your data has been retrieved");
            di.dataText.text = "Hello " + di.stringToSave + ". Your integer was " + di.intToSave.ToString() + " and your float was " + di.floatToSave.ToString();
            di.DisplayInfo();
        }
        else Debug.LogError("There is no saved data!");
    }

    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
                      + "/myData.vxr"))
        {
            File.Delete(Application.persistentDataPath
                              + "/myData.vxr");
           di.intToSave = 0;
            di.floatToSave = 0.0f;
           di.boolToSave = false;
            di.stringToSave = "";
            Debug.Log("Data reset complete!");
            //di.UpdateInfo();
        }
        else
            Debug.LogError("No save data to delete.");
    }

    public void QuitGame()
    {
        SaveGame();
       // UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }
}

[Serializable]

class SaveData
{
    public int savedInt;
    public float savedFloat;
    public string savedString;
    public bool savedBool;
}
