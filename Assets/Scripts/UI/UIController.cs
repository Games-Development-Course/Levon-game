using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    [Header("UI References")]
    public Image questionImage;
    public Button[] answerButtons;
    public TextMeshProUGUI tryAgainText;

    public event Action<int> OnAnswerSelected;

    void Start()
    {
        if (tryAgainText != null)
            tryAgainText.gameObject.SetActive(false);

        // Hook up button callbacks (delegates)
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => OnAnswerButtonClicked(index));
        }
    }

    void OnAnswerButtonClicked(int index)
    {
        OnAnswerSelected?.Invoke(index);
    }

    public void DisplayStep(QuizStep step)
    {
        if (questionImage != null)
            questionImage.sprite = step.image;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            var text = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            if (text != null && step.answers != null && i < step.answers.Length)
                text.text = step.answers[i];
        }
    }

    public void ShowTryAgain(float duration = 1.0f)
    {
        if (tryAgainText == null) return;
        tryAgainText.gameObject.SetActive(true);
        CancelInvoke(nameof(HideTryAgain));
        Invoke(nameof(HideTryAgain), duration);
    }

    void HideTryAgain()
    {
        if (tryAgainText == null) return;
        tryAgainText.gameObject.SetActive(false);
    }

    // Optional: methods to enable/disable interactability
    public void SetInteractableButtons(bool interactable)
    {
        foreach (var b in answerButtons)
            if (b != null) b.interactable = interactable;
    }
}
