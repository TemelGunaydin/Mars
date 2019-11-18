using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataCtrl : MonoBehaviour
{

    public static DataCtrl instance = null;
    public GameData data;

  

    private void Awake()
    {
        if (instance == null)
        
            instance = this;
          
     
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            data.highScore = 0;
            data.highScore_min = 0;
        }


    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Create);


        bf.Serialize(file, data);
        file.Close();



    }

    public void LoadData()
    {
        if(File.Exists(Application.persistentDataPath + "/save.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/save.dat",FileMode.Open);
                data = (GameData)bf.Deserialize(file);
                file.Close();
               

             }

    }


    private void OnEnable()
    {
        LoadData();
    }

    private void OnDisable()
    {
        SaveData();
       
    }

}

[System.Serializable]
public class GameData
{
    public float volume;
    public float highScore;
    public float highScore_min;
   // public float highScore_sec;
}
