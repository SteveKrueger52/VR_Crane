using System.Collections;
using UnityEngine;
public class SFXController : Singleton<SFXController>
{
    public AudioSource ObjectPickUp;
    public AudioSource PositiveBeepSound;
    public AudioSource NegativeBeepSound;
    public AudioSource ObjectDropped;
    public AudioSource EngineOn;
    public AudioSource EngineOff;
    public AudioSource EngineRunning;
    public AudioSource ButtonPress;
    private bool startdelay=true;

    // Start is called before the first frame update
    void Awake()
    {
        startdelay = true;
        StartCoroutine(StartDelayTime());
    }

    public void OnPickedUp()
    {
        //ObjectPickUp.Play();
        if (startdelay == false)
            ObjectPickUp.PlayOneShot(ObjectPickUp.clip);

    }

    public void OnPutDown()
    {
        //ObjectDropped.Play();
        if (startdelay == false)
            ObjectDropped.PlayOneShot(ObjectDropped.clip);
    }

    public void PositiveBeep()
    {
        //PositiveBeepSound.Play();
        if (startdelay == false)
            PositiveBeepSound.PlayOneShot(PositiveBeepSound.clip);
    }

    public void NegativeBeep()
    {
        //NegativeBeepSound.Play();
        if (startdelay == false)
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

    public void OnButtonPress()
    {
        if (startdelay == false)
            ButtonPress.Play();
    }

   
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

    IEnumerator StartDelayTime()
    {
        yield return new WaitForSeconds(0.1f);
        startdelay = false;
    }

}
