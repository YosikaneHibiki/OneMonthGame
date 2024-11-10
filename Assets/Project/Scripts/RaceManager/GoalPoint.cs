using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    private IRaceInput raceInput;

    public void Inject(IRaceInput raceInput)
    {
        this.raceInput = raceInput;
    }

    private void OnTriggerEnter(Collider other)
    {
        raceInput.GameEnd();
    }

}
