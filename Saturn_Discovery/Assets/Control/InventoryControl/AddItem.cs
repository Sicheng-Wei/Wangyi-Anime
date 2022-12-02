using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddItem : MonoBehaviour
{
    Dictionary<string, string> lis = new Dictionary<string, string>
    {
        { "btnEnceladus","4672" },              //产出铅锭
        { "btnMimas","4642" },                   //产出枯竭MOX棒
        { "btnTethys","4639" },                  //产出枯竭铀棒
        { "btnDione","4618" },                  //产出空棒
        { "btnRhea","4672" },                  //产出铅锭
    };

    Dictionary<string, int> numlis = new Dictionary<string, int>
    {
        { "btnEnceladus",20 },              //产出铅锭
        { "btnMimas",5 },                   //产出枯竭MOX棒
        { "btnTethys",10 },                  //产出枯竭铀棒
        { "btnDione",5 },                  //产出空棒
        { "btnRhea",20 },                  //产出铅锭
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
        num = numlis[ID];
    }

    // Update is called once per frame
    void Update()//实时显示剩余数量
    {
        gameObject.GetComponent<Button>().image.sprite = GameObject.Find(lis[ID]).GetComponent<Button>().image.sprite;//更新图片
        snum.text = num.ToString();
    }

    public void Click()
    {

        Inv = GameObject.Find("InventoryPanel").GetComponent<InventoryManager>();
        if (num > 0)
        {
            num--;
            Inv.addnum(lis[ID], 1);
        }

    }
}
