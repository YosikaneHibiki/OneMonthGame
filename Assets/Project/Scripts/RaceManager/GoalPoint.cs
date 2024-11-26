using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    [SerializeField]
    private RaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.StopBGM();
        raceManager.RaceGoal();
    }

}
