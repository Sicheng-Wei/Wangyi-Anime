using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Additem : MonoBehaviour
{
    Dictionary<string, string> lis = new Dictionary<string, string>
    {
        { "","" }//��дbutton��ID�Ͳ�����Ʒ��ID

    };
    string ID;

    InventoryManager Inv;

    [SerializeField]
    TMP_Text snum;


    int num;

    // Start is called before the first frame update
    void Start()
    {
        ID = gameObject.name;//��ȡ��ǰbutton��ID
    }

    // Update is called once per frame
    void Update()//ʵʱ��ʾʣ������
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
