using System;
using System.Reflection;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class Helpers : MonoBehaviour
{
    public static string SplitOnCase(string input)
    {
        return Regex.Replace(input, "(\\B[A-Z])", " $1");
    }

    public static void CreateInfoList(string[] stats, object obj, Transform parent, GameObject textPrefab, float startYPos, float spacing)
    {
        float positioning = startYPos;
        Type type = obj.GetType();

        foreach(string item in stats)
        {
            FieldInfo itemField = type.GetField(item);

            if (itemField != null)
            {
                var textLine = Instantiate(textPrefab, parent);
                textLine.transform.SetLocalPositionAndRotation(new Vector3(textLine.transform.localPosition.x, positioning, textLine.transform.localPosition.z), Quaternion.identity);
                positioning += spacing;
                TMP_Text text = textLine.GetComponent<TMP_Text>();

                if (itemField.FieldType.Equals(typeof(GameObject)))
                {
                    GameObject equipment = itemField.GetValue(obj) as GameObject;
                    Item subItem = equipment.GetComponent<Item>();

                        text.text = $"{SplitOnCase(item)}: {subItem.Name}";
                        text.fontStyle = FontStyles.Underline;
//                        subItem.SetInfoText(text.transform, -50f);

                } 
                else
                    text.text = $"{SplitOnCase(item)}: {itemField.GetValue(obj)}";

            }
        }
    }
}
