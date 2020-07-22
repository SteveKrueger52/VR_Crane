using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimControls : MonoBehaviour
{
    public Renderer blackout;
    public GameObject pauseFade;
    private const float FADE_TIME = 1;

    public SpriteRenderer PauseImage;
    public Sprite PauseIcon;
    public Sprite PlayIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blackout(0));
    }

    public void Pause(bool paused)
    {
        Time.timeScale = paused ? 0 : 1;
        pauseFade.SetActive(paused);
        PauseImage.sprite = paused ? PlayIcon : PauseIcon;
    }
    
    public void ResetScene()
    {
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return Blackout(1);
        SceneManager.LoadScene(0);
    }
    
    IEnumerator Blackout(float desiredAlpha, float fadeTime = FADE_TIME)
    {
        Color fadeColor = blackout.material.color;
        float startAlpha = fadeColor.a;
        float endAlpha = Mathf.Clamp(desiredAlpha, 0f, 1f);
        int midframes = Mathf.CeilToInt(fadeTime / Time.unscaledDeltaTime);
        float deltaA = (endAlpha - startAlpha) / midframes;

        Debug.Log("Starting Fade: " + startAlpha + " : " + endAlpha + " : " + midframes + " : " + deltaA);
        for (int i = 0; i < midframes; i++)
        {
            Debug.Log("Fade Frame");
            fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeColor.a + deltaA);
            blackout.material.color = fadeColor;
            yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
        }
        Debug.Log("Ending Fade");
        fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, desiredAlpha);
        blackout.material.color = fadeColor;
    }
}
