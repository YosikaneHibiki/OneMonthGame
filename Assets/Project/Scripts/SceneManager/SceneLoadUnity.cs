using UnityEngine.SceneManagement;

public class SceneLoadUnity : ISceneLoadAdapter
{
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SceneReLoad()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
