using Cysharp.Threading.Tasks;

public interface ISceneLoadAdapter
{
    void SceneLoad(string sceneName);
    void SceneLoad(string sceneName ,CarID carID);
    UniTask SceneLoadProgress(string sceneName,string loadSceneName);
    UniTask SceneLoadProgress(string sceneName,string loadSceneName,CarID carID);
    void SceneReLoad();
}
