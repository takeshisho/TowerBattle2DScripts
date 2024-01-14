using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerSpawnerButton : CustomButton
{
    public new System.Action<GameObject> onClickCallback; 
    [SerializeField] GameObject playerMobPrefab;
    [SerializeField] GameObject hidePanel;
    [SerializeField] TextMeshProUGUI spqwnCostText;

    private RectTransform hidePanelRectTransform;
    private float originalHeight;
    private int spawnCost;
    private bool isClickable = true;

    private void Start() {
        hidePanel.gameObject.SetActive(false);
        hidePanelRectTransform = hidePanel.GetComponent<RectTransform>();
        originalHeight = hidePanelRectTransform.sizeDelta.y;
        spawnCost = playerMobPrefab.GetComponent<MobManager>().Cost;
        spqwnCostText.text = spawnCost.ToString();
    }

    private void Update() {
        if(Cost.Instance.GameCost < spawnCost)
        {
            isClickable = false;
            hidePanel.gameObject.SetActive(true);
        }
        else if(Cost.Instance.GameCost == spawnCost)
        {
            isClickable = true;
            hidePanel.gameObject.SetActive(false);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)  
    {
        if (!isClickable) return;
        StartSpawnCooltimeProcess();
        onClickCallback?.Invoke(playerMobPrefab);  
    }

    private void StartSpawnCooltimeProcess()
    {
        hidePanel.gameObject.SetActive(true);
        isClickable = false;

        // ピボット（中心点）をY軸について0に設定
        hidePanelRectTransform.pivot = new Vector2(hidePanelRectTransform.pivot.x, 0);

        // Panelの高さを縮小するアニメーション（上から縮小し、底辺にくっついて消える）
        hidePanelRectTransform.DOSizeDelta(new Vector2(hidePanelRectTransform.sizeDelta.x, 0), playerMobPrefab.GetComponent<MobManager>().SpawnCooltime)
            .SetEase(Ease.OutSine)
            .OnComplete(EndSpawnCooltimeProcess);
    }

    private void EndSpawnCooltimeProcess()
    {
        hidePanel.gameObject.SetActive(false);
        hidePanelRectTransform.sizeDelta = new Vector2(hidePanelRectTransform.sizeDelta.x, originalHeight);
        isClickable = true;
    }

}
