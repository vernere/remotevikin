using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapCharacter : MonoBehaviour
{

    public float speed;
    public LoadLevel level;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameObject trigger = GameObject.Find("LevelTrigger");
        level = trigger.GetComponent<LoadLevel>();

    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontalMove, verticalMove, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("LevelTrigger")) 
        {
           
            SceneManager.LoadScene(level.LevelToLoad);

        }

    }

}
