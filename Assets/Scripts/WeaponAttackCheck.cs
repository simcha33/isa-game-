using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackCheck : MonoBehaviour
{
    
    public int EnemyHealth = 100;
    public int DamageAmt = 35;

    public int WeaponState = 100;
    public int WeaponBreak = 10; 

    public GameObject Enemy;
    public GameObject Weapon; 

    private void Awake()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Enemy") && EnemyHealth > 0)
        {
            Debug.Log("WeaponHit");
            EnemyHealth -= DamageAmt;
            WeaponState -= WeaponBreak;
        }
    }

    private void Update()
    {
        if (EnemyHealth <= 0)
        {
            Debug.Log("WeaponDeath");
            Destroy(Enemy);
        }

        if (WeaponState <= 0)
        {
            Debug.Log("WeaponDestroyed");
            Destroy(gameObject);
            Destroy(Weapon); 
        }
    }


}
