using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public static int currentScene
    { get; set; }


    public  void moveToMainMenu()
    {
        SceneManager.LoadScene("StartMenu Experiment");
    }

    public  void moveToFirstLevel()
    {
        SceneManager.LoadScene("Stage001");
    }


    public void exitGame()
    {
        Application.Quit();
    }
}
