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
        GameManager.manager.Save();
    }

    public void Load()
    {
        GameManager.manager.Load();
    }


}
