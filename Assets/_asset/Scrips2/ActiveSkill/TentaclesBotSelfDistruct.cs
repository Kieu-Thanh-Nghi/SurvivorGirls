using UnityEngine;

public class TentaclesBotSelfDistruct : MonoBehaviour
{
    [SerializeField] ActiveSkill_TentaclesRobot tentaclesRobot;

    private void OnParticleSystemStopped()
    {
        tentaclesRobot.SetIsActive(false);
    }
}