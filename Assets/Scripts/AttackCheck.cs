using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCheck : MonoBehaviour
{

    public int EnemyHealth = 100;
    public int LightDamageAmt;
    public int HeavyDamageAmt;

    public AudioClip PunchHit; 
    public AudioClip KickHit;
    public AudioClip Dying;
    public AudioClip PunchImpact; 

    public AudioSource PunchHitSound; 
    public AudioSource KickHitSound;
    public AudioSource DyingSound;
    public AudioSource PunchImpactSound; 

    public GameObject WeaponCollision;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        PunchHitSound.clip = PunchHit;
        PunchImpactSound.clip = PunchImpact; 
        KickHitSound.clip = KickHit;
        DyingSound.clip = Dying;

    }

    private void Update()
    {
        if (EnemyHealth <= 0)
        {
            DyingSound.Play();
            print("dead");
            anim.SetBool("Dead", true);
            anim.SetBool("Damaged", false);
            anim.SetBool("Kicked", false); 
            gameObject.GetComponent<EnemyFollow>().Dead = true;
            WeaponCollision.SetActive(false);
            
        }

        if (Input.GetKey("f"))
        {
            LightDamageAmt = 0; 
            HeavyDamageAmt = 0;
            anim.SetBool("Damaged", false);
            anim.SetBool("Kicked", false); 
            PunchHitSound.Stop();
            KickHitSound.Stop();
        }

        else
        {
            LightDamageAmt = 10;
            HeavyDamageAmt = 34;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Light attack 
        if (other.gameObject.tag == ("Weapon") && EnemyHealth > 0 && (!Input.GetKey("f")))
        {
           
            Debug.Log("PunchHit");
            anim.SetBool("Damaged", true);
            
            EnemyHealth -= LightDamageAmt;
            PunchHitSound.Play();
            PunchImpactSound.Play();
        }


        //Heavy attack 
        if (other.gameObject.tag == ("Foot") && EnemyHealth > 0 && (!Input.GetKey("f")))
        {

            Debug.Log("KickHit");
            anim.SetBool("Kicked", true);
            EnemyHealth -= HeavyDamageAmt;
            KickHitSound.Play();
        }
    }  
}
