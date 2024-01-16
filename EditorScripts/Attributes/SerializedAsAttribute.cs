using UnityEngine;
using UnityEditor;

namespace ArchitectureLibrary
{
    public class LabelAttribute : PropertyAttribute
    {
        public string text;
        public LabelAttribute(string text) => this.text = text;
    }

    [CustomPropertyDrawer(typeof(LabelAttribute))]
    public class LabelDrawer : PropertyDrawer
    {
        private float propertyHeight = 0f;
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => propertyHeight;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            LabelAttribute newLabel = attribute as LabelAttribute;

            PropertyDrawer drawer = PropertyDrawerFinder.Find(property);

            if (drawer != null)
            {
                drawer.OnGUI(position, property, new GUIContent(newLabel.text));
                propertyHeight = drawer.GetPropertyHeight(property, label);
            }
            else
            {
                EditorGUI.PropertyField(position, property, new GUIContent(newLabel.text));
                propertyHeight = base.GetPropertyHeight(property, label);
            }
        }
    }
}