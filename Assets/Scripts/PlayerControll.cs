using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerControll : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce=30f;
    public Animator animator;
    public Rigidbody2D rb2d;
    
    public float obstacleDamage = 20f;

    public bool  isGrounded= false;
    public bool  doubleJumpUsed = false;
   

    public Image filler; 
    [SerializeField]
     float counter;
    
    [SerializeField]
    float maxCounter;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);

            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            

            animator.SetBool("Walk", true);

        }

        else { 
          
          animator.SetBool("Walk",false);
        
        
        }
        if (Input.GetButtonDown("Jump")){

            if ((isGrounded) || (doubleJumpUsed == false))
            {

                rb2d.linearVelocity = new Vector2(0, jumpForce);

                animator.SetTrigger("Jump");
                if (isGrounded ==false)
                {
                    doubleJumpUsed = true;
                }

                else
                {
                    isGrounded = false;
                }

            }

            



        }
        if (counter > maxCounter) {
            GameManager.manager.previousHealth = GameManager.manager.health;
            counter = 0;
        
        }

        else
        {

            counter += Time.deltaTime;
        }


        filler.fillAmount = Mathf.Lerp(GameManager.manager.previousHealth/ GameManager.manager.maxHealth, GameManager.manager.health / GameManager.manager.maxHealth,counter/maxCounter);
        if (rb2d.linearVelocityY == 0) {

            isGrounded = true;
            doubleJumpUsed = false;



        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            TakeDamage(obstacleDamage);

        }


        
       
       

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MaxHP"))
        {
            Destroy(collision.gameObject);
            GameManager.manager.maxHealth += 20f;

        }
        if (collision.gameObject.CompareTag("HP"))
        {
            Destroy(collision.gameObject);
            heal(10);

        }


        if (collision.gameObject.CompareTag("LevelEnd"))
        {

            SceneManager.LoadScene("Map");
        }



    }

    public void heal(float amount)
    {
        GameManager.manager.previousHealth = filler.fillAmount * GameManager.manager.maxHealth;
        counter = 0;
        GameManager.manager.health += amount;
        if (GameManager.manager.health > GameManager.manager.maxHealth) { 
          GameManager.manager.health = GameManager.manager.maxHealth;
        
        
        
        }


    }
    public void TakeDamage(float damage)
    {
        GameManager.manager.previousHealth = filler.fillAmount * GameManager.manager.maxHealth;
        counter = 0;
        GameManager.manager.health -= damage;


    }


}
