using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapCharacter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    void Start()
    {
        
        if (GameManager.manager.currentLevel != "")
        {
            GameObject.Find(GameManager.manager.currentLevel).GetComponent<LoadScene>().Cleared(true);

            transform.position = GameObject.Find(GameManager.manager.currentLevel).transform.GetChild(0).transform.position;

        }


    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Vertical")*speed * Time.deltaTime;
        transform.Translate(horizontalMove, verticalMove, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("LevelTrigger"))
        {
           
            GameManager.manager.currentLevel = collision.gameObject.name;

            SceneManager.LoadScene(collision.gameObject.GetComponent<LoadScene>().LevelToLoad);


        }
    }

    
    

}