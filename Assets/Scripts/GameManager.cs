using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{

    public static GameManager manager;


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
}
