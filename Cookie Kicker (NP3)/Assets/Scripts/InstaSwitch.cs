using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Reflection;
using UnityEngine;

public class InstaSwitch : MonoBehaviour
{
    public int switchScene;
    public void ClearLog(){
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.ActiveEditorTracker));
        var type = assembly.GetType("UnityEditorInternal.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

    void Awake(){
        //ClearLog();
        SceneManager.LoadScene(switchScene);
    }
}
