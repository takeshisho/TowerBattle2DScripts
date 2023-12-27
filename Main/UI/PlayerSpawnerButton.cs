using DG.Tweening;
using UnityEngine;  
using UnityEngine.EventSystems;  

public class PlayerSpawnerButton : CustomButton
{
    // newは消してもいいけど、継承元のCustomButtonのonClickCallbackではなく、
    // ここで定義したonClickCallbackを使うことを明示的に示している。
    // ちなみに継承前のものを使いたい場合はbase.onClickCallbackと書く。
    public new System.Action<GameObject> onClickCallback; 
    [SerializeField] GameObject playerMobPrefab;

    public override void OnPointerClick(PointerEventData eventData)  
    {
        onClickCallback?.Invoke(playerMobPrefab);  
    }

}
