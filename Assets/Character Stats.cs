using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour
{
     public int damage;
     public int maxHealth;

     [SerializeField] private int currentHealth;

     private void Start()
     {
          currentHealth = maxHealth;
     }

     public void TakeDamage(int _damage)
     {
          currentHealth -= damage;

          if (currentHealth < 0)
               Die();
     }

     private void Die()
     {
          
     }
}
