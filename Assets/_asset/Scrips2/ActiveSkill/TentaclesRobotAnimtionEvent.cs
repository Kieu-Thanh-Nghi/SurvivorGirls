using UnityEngine;

public class TentaclesRobotAnimtionEvent : MonoBehaviour
{
    [SerializeField] ActiveSkill_TentaclesRobot tentaclesRobot;

    public void SetActiveTrue() => tentaclesRobot.SetIsActive(true);
}
