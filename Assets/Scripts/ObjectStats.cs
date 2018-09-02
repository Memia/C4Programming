using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectStats : MonoBehaviour
{
    public GameObject player;
    public CharacterHandler handler;
    public float damage = 5;
    public float heal = 5;
   
   public void OnTriggerEnter(Collider col)
    {
        player = GameObject.Find("Player");
        handler = player.GetComponent<CharacterHandler>();
        if (col.gameObject.tag == ("Player"))
        {
            
            handler.TakeDamage();


        }
    }
}
