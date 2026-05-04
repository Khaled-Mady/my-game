using UnityEngine;

public class AboutManager : MonoBehaviour
{
    public GameObject aboutPanel;

    public void ShowAbout()
    {
        aboutPanel.SetActive(true);
    }

    public void HideAbout()
    {
        aboutPanel.SetActive(false);
    }
}