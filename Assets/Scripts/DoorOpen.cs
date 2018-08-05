using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public GameObject Door;

    public AudioClip KeyPickedUp;
    public AudioSource KeyPickedUpSound;

    
    void Start()
    {
        KeyPickedUpSound.clip = KeyPickedUp;
    }

    private void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Player")
        {
            Door.SetActive(false);
            KeyPickedUpSound.Play();
            Destroy(gameObject);
        }
    }
}