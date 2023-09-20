using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoadingManager : MonoBehaviour
{
    [SerializeField] private RectTransform planeRectTransform, coinRectTransform;

    private void Start()
    {
        //LoadScene(0);
        Debug.Log("Plane position: " + planeRectTransform.position + "AnchoredPosition: " + planeRectTransform.anchoredPosition);
        Debug.Log("Coin position: " + coinRectTransform.position + "AnchoredPosition: " + coinRectTransform.anchoredPosition);
    }

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f); // 0 ile 1 arasýnda bir deðer verir, 1 olduðunda yüklenmiþtir

            

            yield return null;
        }

    }
}
