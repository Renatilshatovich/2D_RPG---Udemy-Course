using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Data/Item effect")]
public class ItemEffect : ScriptableObject
{
    [FormerlySerializedAs("itemEffectDescription")] [TextArea] public string effectDescription;
    public virtual void ExecuteEffect(Transform _enemyPosition)
    {
        Debug.Log("Effect");
    }
}
