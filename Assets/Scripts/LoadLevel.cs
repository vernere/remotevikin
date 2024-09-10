using UnityEngine;

public class LoadLevel : MonoBehaviour
{

    public string LevelToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (GameManager.manager.GetType().GetField(LevelToLoad).GetValue(GameManager.manager).ToString() == "True") 
        {
        
            Cleared(true);

        }

    }


    public void Cleared(bool isClear)
    {

        if (isClear)
        {

            GameManager.manager.GetType().GetField(LevelToLoad).SetValue(GameManager.manager, true);

            transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = false;

        }
    }
}
    