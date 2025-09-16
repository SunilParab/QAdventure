using TMPro;
using UnityEngine;

public class IntroText : MonoBehaviour
{

    [SerializeField]
    string[] dialogue;

    [SerializeField]
    bool[] profile;

    int curLine;

    TextMeshProUGUI textField;

    GameObject textbox;
    [SerializeField]
    GameObject QImage;
    [SerializeField]
    GameObject KeyboardImage;

    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        curLine = -1;
        textbox = transform.parent.gameObject;

        AdvanceText();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            AdvanceText();
        }
    }

    public void AdvanceText()
    {

        curLine++;

        if (curLine < dialogue.Length)
        {
            textField.text = dialogue[curLine];
            SetProfile(profile[curLine]);
        }
        else
        {
            GameState.reference.talking = false;
            textbox.SetActive(false);
            KeyboardImage.SetActive(false);
            QImage.SetActive(false);
        }
    }


    public void SetProfile(bool isQ)
    {
        if (!isQ)
        {
            KeyboardImage.SetActive(false);
            QImage.SetActive(true);
        }
        else
        {
            KeyboardImage.SetActive(true);
            QImage.SetActive(false);
        }
    }
}
