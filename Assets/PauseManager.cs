using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            // حفظ آخر مستوى
            PlayerPrefs.SetString("LastLevel", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();

            // الانتقال لمشهد Menu
            SceneManager.LoadScene("Menu");
        }
    }
}