using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public Animator animator;
    public Rigidbody2D rb2D;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public bool isGrounded;

    public Image filler;
 

    public float counter;
    public float maxCounter;


    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer))
        {

            isGrounded = true;

        }
        else
        {

            isGrounded = false;

        }


        transform.Translate(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("walk", true);

        }
        else
        {

            animator.SetBool("walk", false);

        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {

            rb2D.velocity = new Vector2(0, jumpForce);
            animator.SetTrigger("jump");

        }

        if(counter > maxCounter)
        {

            GameManager.manager.previousHealth = GameManager.manager.health;
            counter = 0;

        }
        else
        {

            counter += Time.deltaTime;

        }

        filler.fillAmount = Mathf.Lerp(GameManager.manager.previousHealth / GameManager.manager.maxHealth, GameManager.manager.health / GameManager.manager.maxHealth, counter / maxCounter);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Trap"))
        {

            Debug.Log("Trap");
            TakeDamage(10);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("AddHealth"))
        {
            Destroy(collision.gameObject);
            Heal(20);
        }
        if (collision.gameObject.CompareTag("AddMaxHealth"))
        {
            Destroy(collision.gameObject);
            AddMaxHealth(50);
        }
        if (collision.CompareTag("LevelEnd"))
        {

            SceneManager.LoadScene("Map");

        }
    }


    void AddMaxHealth(float amt)
    {

        GameManager.manager.maxHealth += amt;

    }

    void Heal(float amt)
    {

        GameManager.manager.previousHealth = filler.fillAmount * GameManager.manager.maxHealth;
        counter = 0;
        GameManager.manager.health += amt;
        if(GameManager.manager.health > GameManager.manager.maxHealth)
        {

            GameManager.manager.health = GameManager.manager.maxHealth;

        }

    }

    void TakeDamage(float dmg)
    {

        GameManager.manager.previousHealth = filler.fillAmount * GameManager.manager.maxHealth;
        counter = 0;
        GameManager.manager.health -= dmg;

    }

}
