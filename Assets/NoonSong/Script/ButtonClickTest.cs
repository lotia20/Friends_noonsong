using UnityEngine;
using UnityEngine.UI;

public class ButtonClickTest : MonoBehaviour
{
    public Button testButton;
    public Text feedbackText;

    void Start()
    {
        testButton.onClick.AddListener(OnTestButtonClick);
    }

    public void OnTestButtonClick()
    {
        feedbackText.text = "Button Clicked!";
        Debug.Log("Button Clicked!");
    }
}
