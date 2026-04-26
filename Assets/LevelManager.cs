using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public Transform level2SpawnPoint;
    public GameObject player;
    public PuzzleManager puzzleManager;

    private bool isCompleting = false;

    void Update()
    {
        if (puzzleManager != null && !isCompleting)
        {
            // لازم تعمل دالة في PuzzleManager اسمها IsAllPuzzlesSolved
            // أو تحط الشرط هنا حسب نظامك
        }
    }

    public void CompleteLevel()
    {
        if (isCompleting) return;
        isCompleting = true;
        StartCoroutine(ExitToLevel2());
    }

    IEnumerator ExitToLevel2()
    {
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        yield return new WaitForSeconds(1f);

        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null)
            controller.enabled = false;

        player.transform.position = level2SpawnPoint.position;

        if (controller != null)
            controller.enabled = true;

        yield return new WaitForSeconds(0.5f);

        if (loadingScreen != null)
            loadingScreen.SetActive(false);
    }
}