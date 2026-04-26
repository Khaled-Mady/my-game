using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    [Header("Door Movement")]
    public float slideDistance = 2f;
    public float slideSpeed = 2f;

    [Header("Puzzle System")]
    public PuzzleManager puzzleManager;
    public GameObject progressUI;

    [Header("Loading Screen")]
    public GameObject loadingScreen;  // اسحب LoadingScreen هنا

    [Header("Level 2 Teleport")]
    public Transform level2SpawnPoint;
    public GameObject player;

    private bool shouldOpen = false;
    private bool hasTriggered = false;
    private Vector3 closedPos;
    private Vector3 openPos;

    void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + transform.forward * slideDistance;

        // أخفي شاشة التحميل في البداية
        if (loadingScreen != null)
            loadingScreen.SetActive(false);
    }

    void Update()
    {
        if (!shouldOpen) return;
        transform.position = Vector3.Lerp(transform.position, openPos, slideSpeed * Time.deltaTime);
    }

    public void OpenDoor()
    {
        shouldOpen = true;
        hasTriggered = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!shouldOpen) return;
        if (hasTriggered) return;

        hasTriggered = true;

        // إخفاء واجهة التقدم
        if (progressUI != null)
            progressUI.SetActive(false);

        // إعادة ضبط الألغاز (لو محتاج)
        if (puzzleManager != null)
            puzzleManager.ResetPuzzles();

        // إظهار شاشة التحميل
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        // نقل اللاعب لـ Level 2
        StartCoroutine(TeleportToLevel2());
    }

    IEnumerator TeleportToLevel2()
    {
        // انتظر شوية عشان شاشة التحميل تظهر
        yield return new WaitForSeconds(1.5f);

        // تعطيل الـ Character Controller مؤقتاً
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null)
            controller.enabled = false;

        // نقل اللاعب للمكان الجديد
        if (level2SpawnPoint != null)
            player.transform.position = level2SpawnPoint.position;

        // إعادة تفعيل الـ Character Controller
        if (controller != null)
            controller.enabled = true;

        // انتظر شوية عشان اللاعب يستقر
        yield return new WaitForSeconds(0.5f);

        // إخفاء شاشة التحميل
        if (loadingScreen != null)
            loadingScreen.SetActive(false);
    }
}