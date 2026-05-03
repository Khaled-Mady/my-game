using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public static string lastLevel = "Level1"; // آخر مستوى دخلته

    void Start()
    {
        if (menuCanvas != null)
            menuCanvas.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // أرقام الكيبورد
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            StartGame();

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            ContinueGame();

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            ExitGame();

        // زر Escape
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (menuCanvas != null && !menuCanvas.activeSelf)
            {
                // إظهار القائمة
                menuCanvas.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (menuCanvas != null && menuCanvas.activeSelf)
            {
                // إخفاء القائمة والعودة للعبة
                menuCanvas.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void StartGame()
    {
        Debug.Log("🎮 Start Game");

        lastLevel = "Level1";
        SceneManager.LoadScene("Level1");

        if (menuCanvas != null)
            menuCanvas.SetActive(false);

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ContinueGame()
    {
        Debug.Log("📂 Continue Game → " + lastLevel);

        SceneManager.LoadScene(lastLevel);

        if (menuCanvas != null)
            menuCanvas.SetActive(false);

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitGame()
    {
        Debug.Log("🚪 Exit Game");
        Application.Quit();
    }
}