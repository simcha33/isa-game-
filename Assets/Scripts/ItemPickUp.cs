using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

    public GameObject Weapon;
    public Transform TestWeaponPos;

    private float WeaponState = 100; 

    void Start()
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("pick up");
            Weapon.transform.parent = GameObject.Find("EthanRightHandIndex2").transform;
            Weapon.transform.position = (TestWeaponPos.position); 
        }
    }
}