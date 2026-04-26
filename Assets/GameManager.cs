using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject loadingScreen;        // صفحة التحميل
    public Transform level2SpawnPoint;      // مكان الخروج في الحديقة
    public GameObject player;               // اللاعب
    public PuzzleManager puzzleManager;     // مدير الألغاز

    private bool isCompleting = false;

    void Update()
    {
        // لو خلصت الألغاز ولسه مخلصتش
        if (puzzleManager != null && puzzleManager.IsAllPuzzlesSolved() && !isCompleting)
        {
            CompleteLevel();
        }
    }

    void CompleteLevel()
    {
        isCompleting = true;
        StartCoroutine(ExitToLevel2());
    }

    IEnumerator ExitToLevel2()
    {
        // إظهار صفحة التحميل
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        // انتظر شوية
        yield return new WaitForSeconds(1f);

        // نقل اللاعب برا البيت
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null)
            controller.enabled = false;

        player.transform.position = level2SpawnPoint.position;

        if (controller != null)
            controller.enabled = true;

        // انتظر شوية
        yield return new WaitForSeconds(0.5f);

        // إخفاء صفحة التحميل
        if (loadingScreen != null)
            loadingScreen.SetActive(false);
    }
}