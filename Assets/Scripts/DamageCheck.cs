using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DamageCheck : MonoBehaviour {

    private float PlayerHealth = 100.00f;
    private float PunchDamageAmt = 5.00f;
    private float WeaponDamageAmt = 10.00f;
    private float TrapDamageAmt = 10.00f;
    private float MaxPlayerHealth = 100.00f;

    public AudioClip HealthPickUp;
    public AudioClip WeaponImpact;
    public AudioClip TrapHit; 
    public AudioClip Ambience; 

    public AudioSource HealthPickUpSound;
    public AudioSource WeaponImpactSound;
    public AudioSource AmbienceSound; 
    public AudioSource TrapHitSound; 
 
    private int HealthUp = 25;

    public Image CurrentHealth;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        HealthPickUpSound.clip = HealthPickUp;
        WeaponImpactSound.clip = WeaponImpact;
        AmbienceSound.clip = Ambience;
        TrapHitSound.clip = TrapHit;
        AmbienceSound.Play(); 
    }
        
    private void Update()
    {
        //Block
        if (Input.GetKey("f"))
        {
            PunchDamageAmt = 0f;
            WeaponDamageAmt = 4.00f;
            anim.SetBool("Blocking", true);
            print("blocking");
        }

        else
        {
            anim.SetBool("Blocking", false);
            PunchDamageAmt = 10.00f;
            WeaponDamageAmt = 20.00f;
        }

        //Dies
        if (PlayerHealth <= 0)
        {
            SceneManager.LoadScene("Level_1");
            print("Player died");
        }
    }


    void OnTriggerEnter(Collider other)
    {
        UpdateHealthbar();

        {    //Punch
            if ((other.gameObject.tag == ("Enemy")) && PlayerHealth > 0 && (!Input.GetKey("f")))
            {
                print("Player Punch Hit");
                PlayerHealth -= PunchDamageAmt;
            }

            //Weapon
            if ((other.gameObject.tag == ("Bat")) && PlayerHealth > 0 && (!Input.GetKey("f")))
            {
                WeaponImpactSound.Play(); 
                print("Player Weapon Hit");
                PlayerHealth -= WeaponDamageAmt;
            }

            //Spikes
            if ((other.gameObject.tag == ("Spikes")))
            {
                print("spike death");
                PlayerHealth -= PlayerHealth;
            }

            //Traps
            if ((other.gameObject.tag == ("Trap")))
            {
                print("Trap hit");
                TrapHitSound.Play(); 
                PlayerHealth -= TrapDamageAmt;
            }

            //Medkit
            if ((other.gameObject.tag == ("Medkit")) && PlayerHealth < 100)
            {
                HealthPickUpSound.Play(); 
                PlayerHealth += HealthUp;
                Destroy(other.gameObject);
            }
        }  
    }

    private void UpdateHealthbar()
    {
        {
            float ratio = PlayerHealth / MaxPlayerHealth;
            CurrentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
        }
    }
}

