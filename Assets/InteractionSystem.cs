using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InteractionSystem : MonoBehaviour
{
    public float interactRange = 2.5f;
    public TextMeshProUGUI interactText;

    private PuzzleInteractable nearest;

    void Update()
    {
        nearest = FindNearest();

        if (interactText != null)
        {
            bool show = nearest != null;
            interactText.gameObject.SetActive(show);
            if (show) interactText.text = "Press E to interact";
        }

        // لو مفيش لغز قريب اقفل الـ Panel
        if (nearest == null)
        {
            var ui = FindFirstObjectByType<PuzzleUIController>();
            if (ui != null) ui.Close();
        }

        if (Keyboard.current == null) return;
        if (Keyboard.current.eKey.wasPressedThisFrame && nearest != null)
            nearest.Interact();
    }

    PuzzleInteractable FindNearest()
    {
        PuzzleInteractable best = null;
        float bestD = interactRange;

        var all = FindObjectsByType<PuzzleInteractable>(FindObjectsSortMode.None);
        foreach (var p in all)
        {
            if (p == null || !p.isActiveAndEnabled) continue;

            float d = Vector3.Distance(transform.position, p.transform.position);
            if (d < bestD)
            {
                bestD = d;
                best = p;
            }
        }

        return best;
    }
}