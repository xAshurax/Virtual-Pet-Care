using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GenerateItem : MonoBehaviour
{
    private Button myButton;
    [SerializeField]
    private GameObject item;
    private Vector3 pos;

    private void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() =>
        {
            CreateItem();
        });
    }

    private void CreateItem()
    {
#if UNITY_EDITOR
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

#else
         Touch touch = Input.GetTouch(0);
        pos = Camera.main.ScreenToWorldPoint(touch.position);
#endif
        pos.z = 0;
        Instantiate(item, pos,Quaternion.identity);
    }
}
