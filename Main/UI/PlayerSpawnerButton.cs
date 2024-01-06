using DG.Tweening;
using UnityEngine;  
using UnityEngine.EventSystems;  

public class PlayerSpawnerButton : CustomButton
{
    public new System.Action<GameObject> onClickCallback; 
    [SerializeField] GameObject playerMobPrefab;

    public override void OnPointerClick(PointerEventData eventData)  
    {
        onClickCallback?.Invoke(playerMobPrefab);  
    }

}
