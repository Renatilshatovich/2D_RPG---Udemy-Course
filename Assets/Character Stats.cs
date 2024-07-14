using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour
{
     public Stat strength;
     public Stat damage;
     public Stat maxHealth;
     
     [SerializeField] private int currentHealth;

     protected virtual void Start()
     {
          currentHealth = maxHealth.GetValue();
     }

     public virtual void DoDamage(CharacterStats _targetStats)
     {
          int totalDamage = damage.GetValue() + strength.GetValue();
          
          _targetStats.TakeDamage(totalDamage);
     }

     public virtual void TakeDamage(int _damage)
     {
          currentHealth -= _damage;
          
          if (currentHealth < 0 )
               Die();
     }

     protected virtual void Die()
     {
          // throw new NotImplementedException();
     }
}
