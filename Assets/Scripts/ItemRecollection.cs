using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemRecollection : MonoBehaviour
{
    private ItemRecollection instance;
    private List<GameObject> itemsToCollect;
    private GameObject actualItem = null;
    private Coroutine currentCollection = null;

    public ItemRecollection Instance { get => instance; private set => instance = value; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    public void AddToList(GameObject _item)
    {
        itemsToCollect.Add(_item);
        CheckList();
    }

    public void RemoveFromList(GameObject _item)
    {
        itemsToCollect.Remove(_item);
        //Hay que reorganizar la lista aca

        //
        CheckList();
    }

    private void CheckList()
    {
        if((itemsToCollect.Count>0)&&(currentCollection == null))
        {
            CollectItem();
        }
    } 

    private void CollectItem()
    {
        currentCollection = StartCoroutine(CollectingItem(itemsToCollect[0]));
        itemsToCollect.Remove(itemsToCollect[0]);
    }

    private IEnumerator CollectingItem(GameObject _item)
    {
        while (true)
        {
          yield return null;
            break;
        }

        CheckList();
    }
}
