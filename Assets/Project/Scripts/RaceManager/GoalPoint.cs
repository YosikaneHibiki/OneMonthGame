using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    private RaceManager RaceManager;

    private void OnTriggerEnter(Collider other)
    {
        RaceManager.GameEnd();
=======
    private RaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        raceManager.RaceGoal();
>>>>>>> gamepresenter
    }

}
