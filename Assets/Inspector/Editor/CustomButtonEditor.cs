using UnityEditor;
using UnityEngine;
using System.Reflection;

[CustomEditor(typeof(MonoBehaviour), true)]
public class CustomButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Отображаем стандартные поля инспектора
        DrawDefaultInspector();

        // Получаем все методы в целевом объекте
        MethodInfo[] methods = target.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var method in methods)
        {
            // Проверяем наличие нашего атрибута
            var attributes = method.GetCustomAttributes(typeof(ButtonAttribute), false);
            if (attributes.Length > 0)
            {
                // Получаем название кнопки
                string buttonName = ((ButtonAttribute)attributes[0]).ButtonName;

                // Создаем кнопку в инспекторе
                if (GUILayout.Button(buttonName))
                {
                    method.Invoke(target, null); // Вызываем метод при нажатии кнопки
                }
            }
        }
    }
}