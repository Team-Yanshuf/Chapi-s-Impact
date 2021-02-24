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
        SceneManager.LoadScene("Guy's Stage1");
    }


    public void exitGame()
    {
        Application.Quit();
    }

    public string getCurrentScene()
	{
        return SceneManager.GetActiveScene().name;
	}
}
