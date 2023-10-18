using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoadingManager : MonoBehaviour
{
    [SerializeField] private RectTransform planeRectTransform, coinRectTransform;
    [SerializeField] private int loadSceneID;
    private float planeStartPosX;
    private float differentPosX;

    private void Start()
    {
        planeStartPosX = planeRectTransform.position.x;
        differentPosX = coinRectTransform.position.x - planeRectTransform.position.x;
        LoadScene(loadSceneID);
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
            planeRectTransform.position = new Vector2(planeStartPosX + progressValue * differentPosX, planeRectTransform.position.y);
            yield return null;
        }

    }
    [Range(0,1)]
    public float value;
    private void LateUpdate()
    {
        planeRectTransform.position = new Vector2(planeStartPosX + value * differentPosX, planeRectTransform.position.y);
    }
}
