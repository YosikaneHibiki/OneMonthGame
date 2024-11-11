using System.Threading;

public interface IRaceOutput
{
    void RadeyOutput(CancellationToken token);
    void StartOutput(CancellationToken token);
    void GoaleOutput(CancellationToken token);
}
