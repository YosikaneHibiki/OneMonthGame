using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    [SerializeField]
    private RaceManager RaceManager;

    private void OnTriggerEnter(Collider other)
    {
        RaceManager.GameEnd();
    }

}
