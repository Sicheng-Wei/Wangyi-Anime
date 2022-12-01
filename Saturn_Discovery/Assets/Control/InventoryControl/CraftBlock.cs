using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftBlock : MonoBehaviour
{
    private string ID = "";

    [SerializeField]
    CraftBlock nextbutton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ID != "")
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
        if (!filled())
        {
            ID = IDinput;
            return 1;
        }
        else if (nextbutton) return nextbutton.fill(IDinput);
        else return 0;
    }
    public void unfill()//退回物品
    {
        if(filled())
        {
            GameObject.Find("InventoryPanel").GetComponent<InventoryManager>().addnum(ID,1);
            ID = "";

        }

    }
    
    public int getID()
    {
        if (ID == "") return 0;
        else return int.Parse(ID);
    }

    public void Craft()//使用物品进行制作
    {
        if(ID == "4620")//是锤子
        {
            unfill();
        }
        else
        {
            ID = "";
        }
    }


    void OnLeftClick()
    {
        if (filled())
            unfill();
    }
}
