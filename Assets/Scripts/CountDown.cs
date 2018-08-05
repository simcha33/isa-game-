using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public int TimeLeft = 300;
    public int CriticalTime = 60;

    public Color NormaleTimeColor;
    public Color CriticalTimeColor; 


    public Text CountDownText;

    public AudioClip HurryMusic;
    public AudioClip NormaleMusic; 

    public AudioSource HurryMusicSource;
    public AudioSource NormaleMusicSource; 

    void Start()
    {
        StartCoroutine("LoseTime");
        NormaleMusicSource.clip = NormaleMusic; 
        HurryMusicSource.clip = HurryMusic;
        NormaleMusicSource.Play();
        CountDownText.color = NormaleTimeColor;
    }

    private void Update()
    {
        CountDownText.text = ("" + TimeLeft);

        //Critical 
        if (TimeLeft <= CriticalTime)
        {
            if (NormaleMusicSource.isPlaying)
            { 
                NormaleMusicSource.Stop();
                HurryMusicSource.Play();
                CountDownText.color = CriticalTimeColor;
            }
        }

        else
        {
            HurryMusicSource.Stop();
            CountDownText.color = NormaleTimeColor;
        }

        if (TimeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            print("outtaTime"); 
            SceneManager.LoadScene("Level_1");
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            TimeLeft--;
        }
    }
}