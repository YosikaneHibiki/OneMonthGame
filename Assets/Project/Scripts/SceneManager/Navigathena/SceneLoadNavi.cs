using Cysharp.Threading.Tasks;
using MackySoft.Navigathena.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadNavi : ISceneLoadAdapter
{


    public void SceneLoad(string sceneName)
    {
        var identifier = new BuiltInSceneIdentifier(sceneName);
        GlobalSceneNavigator.Instance.Push(identifier);
    }

    public async void SceneLoad(string sceneName, CarID carID)
    {
        var identifier = new BuiltInSceneIdentifier(sceneName);
        var titleIdentifier = new BuiltInSceneIdentifier("TitleScene");
        var handle = titleIdentifier.CreateHandle();
        await GlobalSceneNavigator.Instance.Push(identifier,data : new EntoryPointData(carID.Id));
        await handle.Unload();
    }

    public async UniTask SceneLoadProgress(string sceneName, string loadSceneName)
    {
        var identifier = new BuiltInSceneIdentifier(sceneName);
        var loadIdentifier = new BuiltInSceneIdentifier(loadSceneName);
        await GlobalSceneNavigator.Instance.Push(identifier, new SceneLoadDirector(loadIdentifier));
    }

    public async UniTask SceneLoadProgress(string sceneName, string loadSceneName, EntoryPointData entoryPointData)
    {
        var identifier = new BuiltInSceneIdentifier(sceneName);
        var loadIdentifier = new BuiltInSceneIdentifier(loadSceneName);
        await GlobalSceneNavigator.Instance.Push(identifier, new SceneLoadDirector(loadIdentifier),data: entoryPointData);
    }

    public void SceneReLoad()
    {
        GlobalSceneNavigator.Instance.Reload();
    }
}
