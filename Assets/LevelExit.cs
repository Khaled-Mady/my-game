using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public GameObject progressText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            progressText.SetActive(false);

            SceneManager.LoadScene("LoadingScene");
        }
    }
}