using UnityEngine;
using TMPro;

public class PuzzleUIController : MonoBehaviour
{
    [Header("UI")]
    public GameObject puzzlePanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;
    public TextMeshProUGUI feedbackText;

    [Header("Disable While Open")]
    public MonoBehaviour[] disableWhileOpen;

    private PuzzleInteractable currentPuzzle;
    private string baseQuestionText = "";

    void Awake()
    {
        // مخفي من البداية
        if (puzzlePanel != null)
            puzzlePanel.SetActive(false);
    }

    public void Open(PuzzleInteractable puzzle)
    {
        currentPuzzle = puzzle;
        baseQuestionText = puzzle.question;

        if (titleText != null) titleText.text = puzzle.puzzleTitle;
        if (questionText != null) questionText.text = baseQuestionText;
        if (feedbackText != null) feedbackText.text = "";

        // بيظهر بس لما تضغط E
        if (puzzlePanel != null)
            puzzlePanel.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (disableWhileOpen != null)
            foreach (var script in disableWhileOpen)
                if (script != null) script.enabled = false;

        if (answerInput != null)
        {
            answerInput.text = "";
            answerInput.ActivateInputField();
        }
    }

    public void Close()
    {
        // بيختفي لما تقفله
        if (puzzlePanel != null)
            puzzlePanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (disableWhileOpen != null)
            foreach (var script in disableWhileOpen)
                if (script != null) script.enabled = true;

        currentPuzzle = null;
    }

    public void Submit()
    {
        if (currentPuzzle == null) return;

        string userAnswer = answerInput != null ? answerInput.text.Trim() : "";
        bool isCorrect = currentPuzzle.CheckAnswer(userAnswer);

        if (isCorrect)
        {
            if (feedbackText != null)
                feedbackText.text = "Correct!";
            else if (questionText != null)
                questionText.text = baseQuestionText + "\n\n<color=#00AA00>Correct!</color>";

            Invoke(nameof(Close), 1.0f);
        }
        else
        {
            if (feedbackText != null)
                feedbackText.text = "Wrong answer, try again!";
            else if (questionText != null)
                questionText.text = baseQuestionText + "\n\n<color=#AA0000>Wrong answer, try again!</color>";

            if (answerInput != null)
            {
                answerInput.text = "";
                answerInput.ActivateInputField();
            }
        }
    }
}