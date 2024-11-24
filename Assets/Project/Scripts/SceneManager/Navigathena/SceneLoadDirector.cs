using Cysharp.Threading.Tasks;
using DG.Tweening;
using MackySoft.Navigathena.SceneManagement;
using MackySoft.Navigathena.SceneManagement.Utilities;
using MackySoft.Navigathena.Transitions;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadDirector : ITransitionDirector
{
    readonly ISceneIdentifier sceneIdentifier;

    public SceneLoadDirector(ISceneIdentifier sceneIdentifier)
    {
        this.sceneIdentifier = sceneIdentifier;
    }

    public ITransitionHandle CreateHandle()
    {
        return new LoadSceneEfect(sceneIdentifier);
    }

    class LoadSceneEfect : ITransitionHandle
    {
        private readonly ISceneIdentifier sceneIdentifier;
        private ISceneHandle sceneHandle;

        public LoadSceneEfect(ISceneIdentifier sceneIdentifier)
        {
            this.sceneIdentifier= sceneIdentifier;
        }
        public async UniTask Start(CancellationToken cancellation = default)
        {
            sceneHandle = sceneIdentifier.CreateHandle();
            Scene loadScene =  await sceneHandle.Load();
        }

        public async UniTask End(CancellationToken cancellation = default)
        {
            await sceneHandle.Unload();
        }

    }
}

