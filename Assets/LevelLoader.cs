using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingCanvas;   // اسحب LoadingCanvas هنا
    public Animator barAnimator;       // اسحب Animator بتاع Bar2 (لو موجود)

    // دي الدالة اللي حتناديها عشان تشغل التحميل
    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
    }

    IEnumerator LoadAsync(string sceneName)
    {
        // 1- إظهار شاشة التحميل
        if (loadingCanvas != null)
            loadingCanvas.SetActive(true);

        // 2- تشغيل الأنيميشن بتاع البار (لو موجود)
        if (barAnimator != null)
            barAnimator.SetTrigger("Start");

        // 3- انتظر 7 ثواني عشان اللاعب يقرأ
        yield return new WaitForSeconds(7f);

        // 4- بدء تحميل المشهد الجديد
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        // 5- استنى لحد ما التحميم يوصل 90%
        while (operation.progress < 0.9f)
        {
            yield return null;
        }

        // 6- انتظر ثانية إضافية (اختياري)
        yield return new WaitForSeconds(1f);

        // 7- السماح بالدخول للمشهد الجديد
        operation.allowSceneActivation = true;
    }
}