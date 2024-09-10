using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameManager : MonoBehaviour

{

    public static GameManager manager;

    public string currentLevel;

    public float health;
    public float previousHealth;
    public float maxHealth;


    public bool Level1;
    public bool Level2;
    public bool Level3;

    private void Awake()
    {
        
        if (manager == null)
        {

            DontDestroyOnLoad(gameObject);
            manager = this;

        }
        else 
        {
            
            Destroy(gameObject);

        }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.M))
        {

            SceneManager.LoadScene("MainMenu");

        }
        
    }

    public void Save()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");
        PlayerData data = new PlayerData();
        data.health = health;
        data.previousHealth = previousHealth;
        data.maxHealth = maxHealth;
        data.currentlevel = currentLevel;
        data.Level1 = Level1;
        data.Level2 = Level2;
        data.Level3 = Level3;

        bf.Serialize(file, data);
        file.Close();

    }

    public void Load()
    {

        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            previousHealth = data.previousHealth;   
            maxHealth = data.maxHealth;
            currentLevel = data.currentlevel;
            Level1 = data.Level1;
            Level2 = data.Level2;
            Level3 = data.Level3;
        }

    }

}

[Serializable]
class PlayerData
{

    public string currentlevel;
    public float health;
    public float previousHealth;
    public float maxHealth;
    public bool Level1;
    public bool Level2;
    public bool Level3;

}