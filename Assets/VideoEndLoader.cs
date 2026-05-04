using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoEndLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneToLoad = "Level1";  // هيفضل في نفس المشهد بعد الفيديو

    void Start()
    {
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("✅ الفيديو خلص!");

        // إخفاء RawImage بتاع الفيديو (Screen)
        GameObject screen = GameObject.Find("Screen");
        if (screen != null)
            screen.SetActive(false);

        // تشغيل اللعبة (تفعيل الحركة، إلخ)
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // تفعيل الـ Character Controller لو كان متعطل
        GameObject player = GameObject.Find("character");
        if (player != null)
            player.GetComponent<CharacterController>().enabled = true;
    }
}