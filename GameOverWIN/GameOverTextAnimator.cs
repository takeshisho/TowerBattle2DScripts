using DG.Tweening;
using UnityEngine;
using System.Collections;
using TMPro;

public class GameOverTextAnimator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        StartCoroutine(GameOverAnimation());
    }

    private IEnumerator GameOverAnimation()
    {
        // 終点として利用するので、初期座標を取得
        var transformCache = transform;
        var defaultPosition = transformCache.localPosition;

        var lastPosition = transform.localPosition + new Vector3(0, 140f);

        transformCache.localPosition = new Vector3(0, 300f);   
        transformCache.DOLocalMove(defaultPosition, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            transformCache.DOShakePosition(1.5f, 100);
        });

        yield return new WaitForSeconds(3f);

        transformCache.DOLocalMove(lastPosition, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            scoreText.text = "score: " + Score.Instance.DestroyedCastleNum.ToString();
        });
    }
}
