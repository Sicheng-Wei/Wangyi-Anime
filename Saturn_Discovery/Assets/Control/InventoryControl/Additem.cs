using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Additem : MonoBehaviour
{
    Dictionary<string, string> lis = new Dictionary<string, string>
    {
        { "","" }//填写button的ID和产出物品的ID

    };
    string ID;

    InventoryManager Inv;

    [SerializeField]
    TMP_Text snum;


    int num;

    // Start is called before the first frame update
    void Start()
    {
        ID = gameObject.name;//获取当前button的ID
    }

    // Update is called once per frame
    void Update()//实时显示剩余数量
    {
        snum.text = num.ToString();
    }

    void Click()
    {

        Inv = GameObject.Find("InventoryPanel").GetComponent<InventoryManager>();
        if(num > 0)
        {
            num--;
            Inv.addnum(lis[ID], 1);
        }
        
    }
}
