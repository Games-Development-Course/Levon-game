using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [Header("Content")]
    public QuizStep[] steps;

    [Header("Game Settings")]
    public int maxErrors = 5;

    // dependencies (can be set in inspector or via DI)
    public UIController uiController;
    public SceneService sceneService; // or assign via inspector

    private int currentStep = 0;
    private int errors = 0;

    void Awake()
    {
        // ensure a scene service exists (simple fallback)
        if (sceneService == null)
            sceneService = new SceneService();
    }

    void OnEnable()
    {
        if (uiController != null)
            uiController.OnAnswerSelected += HandleAnswer;
    }

    void OnDisable()
    {
        if (uiController != null)
            uiController.OnAnswerSelected -= HandleAnswer;
    }

    void Start()
    {
        currentStep = 0;
        errors = 0;
        if (steps == null || steps.Length == 0)
        {
            Debug.LogWarning("QuizManager: no steps configured.");
            return;
        }

        LoadStep(currentStep);
    }

    void LoadStep(int index)
    {
        var step = steps[index];
        uiController?.DisplayStep(step);
    }

    void HandleAnswer(int index)
    {
        var step = steps[currentStep];

        if (index == step.correctIndex)
        {
            currentStep++;

            if (currentStep >= steps.Length)
            {
                sceneService.LoadScene("WinGame");
                return;
            }

            LoadStep(currentStep);
        }
        else
        {
            errors++;
            uiController?.ShowTryAgain(1f);

            if (errors >= maxErrors)
            {
                sceneService.LoadScene("GameOver");
            }
        }
    }
}
