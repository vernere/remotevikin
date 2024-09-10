using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void LoadMap()
    {

        SceneManager.LoadScene("Map");

    }


    public void Save()
    {

        Debug.Log("Save pressed");
        GameManager.manager.Save();

    }


    public void Load()
    {

        Debug.Log("Load pressed");
        GameManager.manager.Load();

    }



}
