using UnityEngine.SceneManagement;
public class SceneService : ISceneService
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
