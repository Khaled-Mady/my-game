using UnityEngine;
using System.Collections;
using TMPro;

public class SimpleFadeScreen : MonoBehaviour
{
    public TextMeshProUGUI levelCompleteText;  // النص اللي جوه اللوحة
    public float fadeSpeed = 1f;  // سرعة الظهور (اختياري)

    void Start()
    {
        // أخفي كل حاجة في البداية
        gameObject.SetActive(false);

        if (levelCompleteText != null)
            levelCompleteText.gameObject.SetActive(false);
    }

    public void ShowScreen(float duration = 3f)
    {
        StartCoroutine(ShowAndHide(duration));
    }

    IEnumerator ShowAndHide(float duration)
    {
        // أظهر اللوحة
        gameObject.SetActive(true);

        // أظهر النص
        if (levelCompleteText != null)
            levelCompleteText.gameObject.SetActive(true);

        // انتظر المدة
        yield return new WaitForSeconds(duration);

        // أخفي اللوحة
        gameObject.SetActive(false);

        // أخفي النص
        if (levelCompleteText != null)
            levelCompleteText.gameObject.SetActive(false);
    }
}