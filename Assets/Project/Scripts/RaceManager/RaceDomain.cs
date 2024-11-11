using System.Threading;
using UnityEngine;

public class RaceDomain : IRaceInput
{
    private GameType gameType;
    private IRaceOutput output;

    private CancellationToken token;

    public RaceDomain(CancellationToken token, IRaceOutput raceOutput)
    {
        this.output = raceOutput;
        this.token = token;
    }

    public void GameRadey()
    {
        Debug.Log("Radey");
        output.RadeyOutput(token);
    }

    public void GameStart()
    {
        Debug.Log("Start");
        output.StartOutput(token);
    }

    public void GameEnd()
    {
        Debug.Log("GameEnd‚©‚©‚Á‚½ŽžŠÔ‚Í");
        output.GoaleOutput(token);
    }

}
