using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class StartMenu : MonoBehaviour
{

    public static StartMenu startMenu;

    public InputField inputField;
    public string inputText;
    public string topNameText;
    public int trueTopScore;


    private void Awake()
    {
        if (startMenu == null)
        {
            LoadTest();
            startMenu = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }





    public void ReadStringInputTest()
    {
        inputText = inputField.text;
        
        SceneManager.LoadScene("main");
    }



    [System.Serializable]
    class SaveData
    {
        //public Color TeamColor;
        public string topNameText;
        public int trueTopScore;
    }

    public void SaveTest()
    {
        SaveData data = new SaveData();
        //data.TeamColor = TeamColor;
        data.topNameText = topNameText;
        data.trueTopScore = trueTopScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadTest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //TeamColor = data.TeamColor;
            topNameText = data.topNameText;
            trueTopScore = data.trueTopScore;
        }
    }










}
