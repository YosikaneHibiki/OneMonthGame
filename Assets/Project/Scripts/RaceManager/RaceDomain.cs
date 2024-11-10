using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

public class RaceDomain : IRaceInput
{
    private IRaceOutput output;

    private CancellationToken token;

    public RaceDomain(CancellationToken token,IRaceOutput raceOutput)
    {
        this.output = raceOutput;
        this.token = token;
    }

    public async void GameRadey()
    {
        Debug.Log("Radey");
        await UniTask.Delay(TimeSpan.FromSeconds(3),cancellationToken: token);
        GameStart();
    }

    public void GameStart()
    {
        Debug.Log("Start");
    }

    public void GameEnd()
    {
        Debug.Log("GameEnd‚©‚©‚Á‚½ŽžŠÔ‚Í");
    }

}
