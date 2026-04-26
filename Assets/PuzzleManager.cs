using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    [Header("Progress")]
    public int totalPuzzles = 5;
    public TextMeshProUGUI progressText;

    [Header("Congratulations")]
    public GameObject congratuationsPanel;
    public TextMeshProUGUI congratuationsText;

    [Header("Door")]
    public DoorController exitDoor;

    private bool[] solved;
    private int solvedCount = 0;

    void Awake()
    {
        if (totalPuzzles <= 0) totalPuzzles = 5;
        solved = new bool[totalPuzzles];
        UpdateUI();

        if (congratuationsPanel != null)
            congratuationsPanel.SetActive(false);
    }

    public void SolvePuzzle(int index)
    {
        if (index < 0 || index >= solved.Length) return;
        if (solved[index]) return;

        solved[index] = true;
        solvedCount++;
        UpdateUI();

        if (solvedCount >= totalPuzzles)
        {
            ShowCongratulations();
            if (exitDoor != null)
                exitDoor.OpenDoor();

            // 🔥🔥🔥 أضف السطر ده هنا 🔥🔥🔥
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if (levelManager != null)
                levelManager.CompleteLevel();
        }
    }

    void ShowCongratulations()
    {
        if (congratuationsPanel != null)
        {
            congratuationsPanel.SetActive(true);
            Invoke(nameof(HideCongratulations), 3f);
        }

        if (progressText != null)
            progressText.gameObject.SetActive(false);
    }

    void HideCongratulations()
    {
        if (congratuationsPanel != null)
            congratuationsPanel.SetActive(false);
    }

    public void ResetPuzzles()
    {
        var allPuzzles = FindObjectsByType<PuzzleInteractable>(FindObjectsSortMode.None);
        foreach (var puzzle in allPuzzles)
        {
            puzzle.ResetPuzzle();
        }

        for (int i = 0; i < solved.Length; i++)
        {
            solved[i] = false;
        }
        solvedCount = 0;

        if (progressText != null)
            progressText.gameObject.SetActive(true);

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (progressText != null)
        {
            progressText.text = "Solved: " + solvedCount + "/" + totalPuzzles +
                                " | Remaining: " + (totalPuzzles - solvedCount);
        }

    }
    public bool IsAllPuzzlesSolved()
    {
        return solvedCount >= totalPuzzles;
    }
}