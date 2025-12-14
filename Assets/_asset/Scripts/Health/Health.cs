using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public void TakeDamage(int dameAmount)
    {
        Debug.Log("takedame " + dameAmount);
    }
}

