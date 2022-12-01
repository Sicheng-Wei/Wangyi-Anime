using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonControl : MonoBehaviour
{
    readonly string[] intro =
    {
        "燃料储罐:用于储存燃料",
        "钚铀混合氧化物核燃料:用于填充燃料棒",
        "防辐射容纳盒:有了他就不用担心辐射了",
        "铅质外壳:可以拿来制作防辐射容纳盒",
        "锤子:遇事不决锤一下",
        "铅锭:据说可以用来防辐射，但是得加工一下",
        "燃料棒 (枯竭MOX):将近枯竭的燃料棒，说不定可以从里面提取出一些原料，但是得小心辐射",
        "燃料棒(枯竭铀):将近枯竭的燃料棒，说不定可以从里面提取出一些原料，但是得小心辐射",
        "钚:制作核燃料的原料之一",
        "铀-238:制作核燃料的原料之一",
        "燃料棒(MOX):崭新出场的核燃料棒",
        "燃料棒(空):空的燃料棒",
    };

    [SerializeField]
    TMP_Text text;

    void Start()
    {
    }

    public void OnClick()
    {
        text.text = intro[11];
    }
}
