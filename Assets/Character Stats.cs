using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour
{
     public Stat damage;
     public Stat maxHealth;
     
     [SerializeField] private int currentHealth;

     private void Start()
     {
          currentHealth = maxHealth.GetValue();
          
          damage.AddModifier(4);
     }

     public void TakeDamage(int _damage)
     {
          currentHealth -= _damage;

          if (currentHealth < 0)
               Die();
     }

     private void Die()
     {
          throw new NotImplementedException();
     }
}
