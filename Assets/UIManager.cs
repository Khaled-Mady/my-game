using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startMenuPanel;   // Panel شاشة البداية
    public GameObject pauseMenuPanel;   // Panel شاشة الإيقاف
    public GameObject winPanel;         // Panel شاشة الفوز

    void Start()
    {
        ShowStartMenu();
        Time.timeScale = 0f;

        // الماوس يبقى ظاهر طول الوقت
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        startMenuPanel.SetActive(false);
        Time.timeScale = 1f;

        // الماوس لسه ظاهر
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowStartMenu()
    {
        startMenuPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        winPanel.SetActive(false);

        // الماوس ظاهر
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowWinScreen()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;

        // الماوس ظاهر
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}