using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerManager : MonoBehaviour
{
     public static PlayerManager instance;
     public Player player;

     private void Awake()
     {
          if(instance != null)
               Destroy(instance.gameObject);
          else
               instance = this;
     }
}
