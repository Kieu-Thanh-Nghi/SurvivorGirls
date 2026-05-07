using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChipRewardShower : RewardShower<int>{}

public class RewardShower<T> : MonoBehaviour
{
    [SerializeField] Claim_Reward<T> reward;
    [SerializeField] List<Claim_Reward<T>> rewards;
    [SerializeField] Transform rewardsContainer;

    [SerializeField] GameObject ScreenOne, ScreenMany;
    [SerializeField] UnityEvent<GameObject> SetTheUsingScreen;

    public void ShowOne(T attribute)
    {
        reward.ShowRewardQuantity(attribute);
        SetTheUsingScreen?.Invoke(ScreenOne);
    }
    public void ShowMany(List<T> attributes)
    {
        int chipCount = rewards.Count;
        int quantitiesCount = attributes.Count;
        if (chipCount < quantitiesCount)
        {
            int n = quantitiesCount - chipCount;
            for (int i = 0; i < n; i++)
            {
                rewards.Add(Instantiate(reward, rewardsContainer, false));
            }
        }

        for (int i = 0; i < quantitiesCount; i++)
        {
            rewards[i].ShowRewardQuantity(attributes[i]);
        }

        SetTheUsingScreen?.Invoke(ScreenMany);
    }
}
