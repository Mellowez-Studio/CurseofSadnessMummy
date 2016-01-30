using UnityEngine;
using UnityEditor;

public class windowToolProject : EditorWindow
{
    [MenuItem("ThisProject/AddCompoment/EventObjectButton")]
    static void addeventobjectBtn()
    {
        GameObject selectObj = Selection.activeGameObject;
        if (selectObj != null)
        {
            selectObj.AddComponent<PlayerEvent>();
            selectObj.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
    [MenuItem("ThisProject/AddCompoment/EventObject")]
    static void addeventobj()
    {
        GameObject selectObj = Selection.activeGameObject;
        if (selectObj != null)
        {
            selectObj.AddComponent<PlayerEnnt_01>();
            selectObj.GetComponent<BoxCollider>().isTrigger = true;
        }
    }


    [MenuItem("ThisProject/AddCompoment/EventObject/Event1/WelcomeToMySadStory")]
    static void addevent01()
    {
        GameObject selectObj = Selection.activeGameObject;
        if (selectObj != null)
            selectObj.AddComponent<welcomeToMySadStory>();
        
    }

    [MenuItem("ThisProject/AddCompoment/EventObject/Event2/Tresure")]
    static void addtresure()
    {
        GameObject selectObj = Selection.activeGameObject;
        if (selectObj != null)
            selectObj.AddComponent<tresure_E2>();
    }
    [MenuItem("ThisProject/AddCompoment/EventObject/Event2/Ankh")]
    static void addankh()
    {
        GameObject selectObj = Selection.activeGameObject;
        if (selectObj != null)
            selectObj.AddComponent<ankh_E2>();
    }
    [MenuItem("ThisProject/AddCompoment/EventObject/Event3/Door")]
    static void adddoor1()
    {
        GameObject selectObj = Selection.activeGameObject;
        if (selectObj != null)
            selectObj.AddComponent<Door1>();
    }
   
}