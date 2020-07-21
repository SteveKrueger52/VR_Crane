using System.Collections;
using UnityEngine;


public class SFXController : MonoBehaviour
{
    public AudioSource ObjectPickUp;
    public AudioSource PositiveBeepSound;
    public AudioSource NegativeBeepSound;
    public AudioSource ObjectDropped;
    public AudioSource EngineOn;
    public AudioSource EngineOff;
    public AudioSource EngineRunning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPickedUp()
    {
        //ObjectPickUp.Play();
        ObjectPickUp.PlayOneShot(ObjectPickUp.clip);
    }

    public void OnPutDown()
    {
        //ObjectDropped.Play();
        ObjectDropped.PlayOneShot(ObjectDropped.clip);
    }

    public void PositiveBeep()
    {
        //PositiveBeepSound.Play();
        PositiveBeepSound.PlayOneShot(PositiveBeepSound.clip);
    }

    public void NegativeBeep()
    {
        //NegativeBeepSound.Play();
        NegativeBeepSound.PlayOneShot(NegativeBeepSound.clip);
    }

    public void OnEngineStart()
    {
        EngineOn.Play();
        //StartCoroutine(WaitForLoop());
        StartCoroutine(Crossfade(EngineOn, EngineRunning, 2f));

    }

    public void OnEngineStop()
    {
        //EngineRunning.Stop();
        //EngineOff.Play();

        StartCoroutine(Crossfade(EngineRunning, EngineOff, 1f));
    }

    //IEnumerator WaitForLoop()
    //{
    //    yield return new WaitForSeconds(EngineOn.clip.length);
    //    EngineRunning.Play();
    //}
    IEnumerator Crossfade(AudioSource fadeout, AudioSource fadein, float fadetime)
        {
            float startfadeoutVolume = fadeout.volume;
            float startfadeinVolume = 0.2f;
            float endFadeinVolume = fadein.volume;

            fadein.volume = startfadeinVolume;
            fadein.Play();

        while (/*fadeout.volume > 0 &&*/ fadein.volume <= endFadeinVolume)
            {
                Debug.Log("while");

                if (fadeout.volume > 0)
                {
                    Debug.Log("if");
                    fadeout.volume -= startfadeoutVolume * Time.deltaTime / fadetime;
                }

                fadein.volume += startfadeinVolume * Time.deltaTime / fadetime;
                yield return null;
            }

            fadeout.Stop();
            fadeout.volume = startfadeoutVolume;

        }

}
