using UnityEngine;
using UnityEngine.UI;

public class ScreenText : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    public string text
    {
        get { return _text.text; }
        set { _text.text = value; }
    }

    public string startingText;
    private void OnValidate() { text = startingText; }
}
