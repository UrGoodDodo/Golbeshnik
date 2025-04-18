using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LoreStateInfoSO", menuName = "ScriptableObjects/LoreStateInfoSO", order = 1)]
public class LoreStateInfoSO : ScriptableObject
{
    [field: SerializeField]
    public string loreStateId { get; private set; }

    [Header("Основная")]
    public string StateName; // Наименования состояния (просто для себя)
    
    [TextArea]
    public string DialogText; // Реплика или текст персонажа

    [Header("Тасочки")]
    public string StartingTaskId = null; // Если есть начало таски то сюда ее айдишник
    public string FinishingTaskId = null;

    //можно добавить (наименования/ id / и т.д.) чтобы можно было это триггерить в начало лор события или в конце

    private void OnValidate() //ID всегда того же вида = имени объекта
    {
        #if UNITY_EDITOR
        loreStateId = name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}
