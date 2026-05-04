using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject gameplayUI;

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinish;
            videoPlayer.Play();
        }
    }

    void OnVideoFinish(VideoPlayer vp)
    {
        Debug.Log("✅ الفيديو خلص");

        if (videoPlayer.gameObject != null)
            videoPlayer.gameObject.SetActive(false);

        if (gameplayUI != null)
            gameplayUI.SetActive(true);

        Time.timeScale = 1f;
    }
}