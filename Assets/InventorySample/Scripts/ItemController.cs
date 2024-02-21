using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemController : MonoBehaviour ,IPointerClickHandler
{
    [SerializeField] private Text _text;
    ItemData _itemData;
    Image _image;
    public void SetData(ItemData itemData)
    {
        _itemData = itemData;
        _text.text = _itemData.id + "";
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(_itemData.id);
    }
    
}
