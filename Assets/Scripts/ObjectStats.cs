using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectStats : MonoBehaviour
{
    public CharacterHandler handler;
    public float damage = 5;
    public float heal = 5;
   
   public void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == ("Player"))
        {

                handler.curHealth -= damage;


        }
    }
}
