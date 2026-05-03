using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimerLevel2Manager : MonoBehaviour
{
    public GameObject timeOutCanvas;  // هنحط TimeOutCanvas هنا

    void Start()
    {
        // لو مش مربوط، دور عليه تلقائياً
        if (timeOutCanvas == null)
        {
            timeOutCanvas = GameObject.Find("TimeOutCanvas");
            if (timeOutCanvas != null)
                Debug.Log("✅ تم العثور على TimeOutCanvas");
            else
                Debug.LogError("❌ TimeOutCanvas مش موجود في المشهد!");
        }
    }

    // دي الدالة اللي التايمر هيناديها لما يخلص
    public void OnTimerFinished()
    {
        StartCoroutine(ShowImageThenBackToLevel1());
    }

    IEnumerator ShowImageThenBackToLevel1()
    {
        // 1- إظهار الصورة
        if (timeOutCanvas != null)
            timeOutCanvas.SetActive(true);

        // 2- وقف الحركة عشان اللاعب ما يتحركش
        Time.timeScale = 0f;

        // 3- انتظر 4 ثواني
        yield return new WaitForSecondsRealtime(4f);

        // 4- الرجوع إلى Level 1
        SceneManager.LoadScene("Level1");
    }
}