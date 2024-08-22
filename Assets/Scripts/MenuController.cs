using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
{
    Application.Quit();
}

public void ShowCredits()
    {
        SceneManager.LoadScene("Credits"); 
        
    }

 public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
