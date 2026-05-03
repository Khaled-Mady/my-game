using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

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

    [Header("Loading Screen")]
    public GameObject loadingCanvas;

    private bool[] solved;
    private int solvedCount = 0;

    void Awake()
    {
        if (totalPuzzles <= 0) totalPuzzles = 5;
        solved = new bool[totalPuzzles];
        UpdateUI();

        if (congratuationsPanel != null)
            congratuationsPanel.SetActive(false);

        if (loadingCanvas != null)
            loadingCanvas.SetActive(false);
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
            StartCoroutine(LoadLevel2WithDelay());
        }
    }

    IEnumerator LoadLevel2WithDelay()
    {
        if (loadingCanvas != null)
            loadingCanvas.SetActive(true);

        Debug.Log("⏳ شاشة التحميل ظهرت... انتظار 7 ثواني");
        yield return new WaitForSeconds(7f);

        Debug.Log("🚀 جاري الانتقال إلى Level 2");
        SceneManager.LoadScene("Level2");
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