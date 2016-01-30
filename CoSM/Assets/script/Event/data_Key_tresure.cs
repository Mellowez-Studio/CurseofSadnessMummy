using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class data_Key_tresure : MonoBehaviour
{
    static List<string> data_Key_tresureS = new List<string>();

    public static bool chackKey(string nameChack)
    {
        foreach (var e in data_Key_tresureS)
            if (e == nameChack)
                return true;
        return false;
    }
    public static void addNameKey(string nameAdd)
    {
        data_Key_tresureS.Add(nameAdd);
    }
}
