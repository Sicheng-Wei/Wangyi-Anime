using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class InventoryControl : MonoBehaviour
{
    readonly Dictionary<string, string> intro = new Dictionary<string, string>
    {
      {"55200" , "燃料储罐:用于储存燃料"                                                             },
      {"4638" , "钚铀混合氧化物核燃料:用于填充燃料棒"                                               },
      {"9337" , "防辐射容纳盒:有了他就不用担心辐射了"                                               },
      {"9843" , "铅质外壳:可以拿来制作防辐射容纳盒"                                                },
      {"4620" , "锤子:遇事不决锤一下"                                                            },
      {"4672" , "铅锭:据说可以用来防辐射，但是得加工一下"                                           },
      {"4642" , "燃料棒 (枯竭MOX):将近枯竭的燃料棒，说不定可以从里面提取出一些原料，但是得小心辐射" },
      {"4639" , "燃料棒(枯竭铀):将近枯竭的燃料棒，说不定可以从里面提取出一些原料，但是得小心辐射"   },
      {"4637" , "钚:制作核燃料的原料之一"                                                           },
      {"4633" , "铀-238:制作核燃料的原料之一"                                                       },
      {"4645" , "燃料棒(MOX):崭新出场的核燃料棒"                                                    },
      {"4618" , "燃料棒(空):空的燃料棒" }
    };
    private Button btn;

    [SerializeField]
    TMP_Text text;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void onLeftClick()
    {
        text.text = intro[gameObject.name];
    }


}



