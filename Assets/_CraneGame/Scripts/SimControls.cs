using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimControls : MonoBehaviour
{
    public static bool GoalObtained;
    
    public Renderer blackout;
    public GameObject pauseFade;
    public ScreenText timer;
    private const float FADE_TIME = 1;

    public SpriteRenderer PauseImage;
    public Sprite PauseIcon;
    public Sprite PlayIcon;

    private float timeSim;
    public bool timerActive { get; set; }
    public bool simStarted { get; set; }

    private bool _simOver;
    public bool simOver
    {
        get { return _simOver; }
        set
        {
            _simOver = value && GoalObtained;
            // Only shows as finished if the box is in contact with the goal
        }
    }

    // Start is called before the first frame update
    private void Start() { StartCoroutine(Blackout(0)); }
    public void ResetScene() { StartCoroutine(Reset()); }

    private void Update()
    {
        string text;
        if (timerActive && !simOver)
            timeSim += Time.deltaTime;
        int m  = Mathf.FloorToInt(timeSim / 60);
        float s  = Mathf.FloorToInt(timeSim) % 60;
        text = string.Format("{0:F0}:{1:F3}",m,s) + (timerActive ? "" : simOver ? "" : "\n -- Timer Paused --");
        
        if (simStarted)
            timer.text = text;
        
        if (simOver)
            timer.ChangeColor(Color.green);
    }

    public void Pause(bool paused)
    {
        Time.timeScale = paused ? 0 : 1;
        pauseFade.SetActive(paused);
        PauseImage.sprite = paused ? PlayIcon : PauseIcon;
        timerActive = !paused && simStarted;
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
