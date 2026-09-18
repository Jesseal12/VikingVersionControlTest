using JetBrains.Annotations;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public string LevelToLoad;
    public bool cleared;
    void Start()
    {

        if (GameManager.manager.GetType().GetField(LevelToLoad).GetValue(GameManager.manager).ToString() == "True")
        {

            Cleared(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Cleared(bool isCleared)
    {
        if (isCleared == true)
        {
            cleared = true;

            GameManager.manager.GetType().GetField(LevelToLoad).SetValue(GameManager.manager, true);
            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = false; 

        }


    }
}
