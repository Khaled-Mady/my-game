using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputManagerEntry;

public class LevelMessage : MonoBehaviour
{
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;
    public float displayTime = 3f;

    void Start()
    {
        messagePanel.SetActive(false);
    }

    public void ShowMessage()
    {
        StartCoroutine(DisplayMessage());
    }

    IEnumerator DisplayMessage()
    {
        messageText.text = "Level 2\nFind the puzzles to escape!";
        messagePanel.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        messagePanel.SetActive(false);
    }
}