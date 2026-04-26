using UnityEngine;

public class PuzzleInteractable : MonoBehaviour
{
    [Header("Puzzle Data")]
    public string puzzleTitle = "Puzzle";
    [TextArea] public string question = "12 + 13 = ?";
    public string correctAnswer = "25";
    public int puzzleIndex = 0;

    [Header("References")]
    public PuzzleUIController uiController;
    public PuzzleManager puzzleManager;

    private bool solved = false;

    public void Interact()
    {
        if (solved) return;
        if (uiController != null) uiController.Open(this);
    }

    public bool CheckAnswer(string answer)
    {
        if (solved) return true;

        bool isCorrect = answer == correctAnswer;
        if (isCorrect)
        {
            solved = true;
            if (puzzleManager != null)
                puzzleManager.SolvePuzzle(puzzleIndex);
        }

        return isCorrect;
    }

    public void ResetPuzzle()
    {
        solved = false;
    }
}