using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    [SerializeField]
    private RaceManager raceManager;
    private AudioManager audioManager;
    private AudioSource audioSource;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        audioSource = GetComponent<AudioSource>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        audioManager.StopBGM();
        audioManager.PlaySFX("Desktop 2024 (mp3cut.net)", audioSource);
        raceManager.RaceGoal();
    }

}
