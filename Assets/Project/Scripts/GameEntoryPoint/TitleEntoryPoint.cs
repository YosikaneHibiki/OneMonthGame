using Cysharp.Threading.Tasks;
using MackySoft.Navigathena;
using MackySoft.Navigathena.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TitleEntoryPoint : SceneEntryPointBase
{
    [SerializeField]
    private TitleDIScope scope;

    protected override UniTask OnExit(ISceneDataWriter writer, CancellationToken cancellationToken)
    {
        scope.Disable();
        return base.OnExit(writer, cancellationToken);
    }

    protected override UniTask OnInitialize(ISceneDataReader reader, IProgress<IProgressDataStore> progress, CancellationToken cancellationToken)
    {
        return base.OnInitialize(reader, progress, cancellationToken);
    }
}
