using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Additem : MonoBehaviour
{
    Dictionary<string, string> lis = new Dictionary<string, string>
    {
        { "","" }//��дbutton��ID�Ͳ�����Ʒ��ID

    };
    string ID;

    InventoryManager Inv;
    // Start is called before the first frame update
    void Start()
    {
        ID = gameObject.name;//��ȡ��ǰbutton��ID
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Click()
    {
        Inv = GameObject.Find("InventoryPanel").GetComponent<InventoryManager>();
        Inv.addnum(lis[ID], 1);
    }
}
