using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftResult : MonoBehaviour
{
    private string ID = "";

    [SerializeField]
    CraftBlock btn1,btn2,btn3,btn4;
    readonly Dictionary<int, string> CraftDic = new Dictionary<int, string>
    {
           {18536, "4638"},
           {39372, "9337"},
          { 9292, "9843"},
           {18599, "4637"},
           {18596, "4633"},
          { 9256, "4645"},
    };




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int craftsum = btn1.getID() + btn2.getID() + btn3.getID() + btn4.getID();
        if (CraftDic.ContainsKey(craftsum))
        {
            ID = CraftDic[craftsum];

        }
        else ID = "";

        if (ID != "")
        {
            gameObject.GetComponent<Button>().image.sprite = GameObject.Find(ID).GetComponent<Button>().image.sprite;//更新图片
        }
        else
        {
            gameObject.GetComponent<Button>().image.sprite = null;
        }
    }
    public bool filled()
    {
        if (ID != "") return true;
        else return false;
    }
    public int fill(string IDinput)//1则成功填入，0则未成功
    {
        if (filled())
        {
            ID = IDinput;
            return 1;
        }
        
        else return 0;
    }
    public void unfill()
    {
        if (filled())
        {
            GameObject.Find("InventoryPanel").GetComponent<InventoryManager>().addnum(ID, 1);
            ID = "";

        }

    }

    void Click()
    {
        if(ID !="")//能做则做
        {
            btn1.Craft();
            btn2.Craft();
            btn3.Craft();
            btn4.Craft();

            GameObject.Find("InventoryPanel").GetComponent<InventoryManager>().addnum(ID, 1);
            ID = "";
        }
        


    }
}
