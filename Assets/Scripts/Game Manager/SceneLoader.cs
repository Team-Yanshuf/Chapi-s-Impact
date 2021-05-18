using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public static int currentScene
    { get {   return SceneManager.GetActiveScene().buildIndex;	}  }

    public  void moveToMainMenu()
    {
        SceneManager.LoadScene("Guy StartMenu");
    }

    public  void moveToFirstLevel()
    {
        SceneManager.LoadScene("Yinon'sStage001");
    }


    public void exitGame()
    {
        Application.Quit();
    }

    public string getCurrentScene()
	{
        return SceneManager.GetActiveScene().name;
	}

    public string[] getSceneListInBuild()
	{
        int sceneCount = SceneManager.sceneCount;
        string[] sceneNames = new string[sceneCount];
        for (int i=0; i<sceneNames.Length; i++)
		{
            sceneNames[i]=SceneManager.GetSceneAt(i).name;
		}
        return sceneNames;
	}

	internal void moveToNextLevel()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void moveToWinScene()
	{
        SceneManager.LoadScene("Win Scene");
	}
}
