using UnityEditor;
using UnityEngine;

namespace ScriptSwitchers.Core
{
    /// <summary>
    /// This code is from: 
    ///     http://answers.unity.com/answers/793012/view.html 
    ///     http://answers.unity.com/answers/550870/view.html
    /// </summary>
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class DefaultInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            this.DrawDefaultInspectorWithoutScriptField();
        }
    }
}