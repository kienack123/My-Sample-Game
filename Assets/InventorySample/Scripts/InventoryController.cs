using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class InventoryController : MonoBehaviour
{
    [SerializeField] private ItemController _itemController;

    [SerializeField] private List<ItemData> _itemControllerList;

    [SerializeField] private Transform _itemContainer;

    [SerializeField] private List<Color> _colorList;

    [SerializeField] private GameObject _cellPrefab;


    List<ItemController> _items;
    private void Start()
    {
        _items = new List<ItemController>();  
        CreateItemInventory();
    }

    private void CreateItemInventory()
    {
        var _sortItem = SortItemByColor(_itemControllerList);
        foreach (var item in _sortItem)
        {
            ItemController _itemCell = Instantiate(_itemController);
            _itemCell.SetData(item);
            _items.Add(_itemCell);
            GameObject _cell = Instantiate(_cellPrefab);
            _cell.gameObject.transform.SetParent(_itemContainer);
            _itemCell.gameObject.transform.SetParent(_cell.transform);
            
            Debug.Log("111111111111111111111");
        }
    }


    //private List<ItemData> SortItemByColor(List<ItemData> itemDatas)
    //{
    //    List<ItemData> _sortItemByColor = new List<ItemData>();

    //    for (int i = 0; i < _colorList.Count; i++)
    //    {
    //        foreach (var itemData in itemDatas)
    //        {
    //            if ((int)itemData.color == i)
    //            {
    //                if (_sortItemByColor.Contains(itemData)) continue;
    //                _sortItemByColor.Add(itemData);
    //            }
    //        }
    //    }      
    //    return _sortItemByColor;
    //}

    private List<ItemData> SortItemByColor(List<ItemData> itemDatas)
    {
        return itemDatas.OrderBy(item => (int)item.color).ToList();
    }


    public void HideItemOutViewPort()
    {
        foreach (var item in _items)
        {
            if (item.transform.position.y > 350f || item.transform.position.y < 100f)
            {
                item.enabled = false;
            }
            else
            {
                item.enabled=true;
            }
        }
    }
}
[Serializable]
public class ItemData
{
    public int id;
    public string name;
    public string description;
    public int quantity;
    public int price;
    public ItemColor color;
}
public enum ItemColor
{
    Green,
    Blue,
    Red,
    Gold
}

