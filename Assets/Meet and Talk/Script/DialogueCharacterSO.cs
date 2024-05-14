using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MEET_AND_TALK
{
    [CreateAssetMenu(menuName = "Dialogue/New Dialogue Character")]
    public class DialogueCharacterSO : ScriptableObject
    {
        [Header("Name")]
        public List<LanguageGeneric<string>> characterName;
        public GlobalValueClass CustomizedName;
        public bool UseGlobalValue = false;
        [Header("Name Color")]
        public Color textColor = new Color(.8f, .8f, .8f, 1);
        [Header("Avatars")]
        public List<CharacterSprite> Avatars;

        public string HexColor()
        {
            return $"#{ColorUtility.ToHtmlStringRGB(textColor)}";
        }

        private void OnValidate()
        {
            Validate();
        }

        public void Validate()
        {
            // Names
            if (characterName.Count != System.Enum.GetNames(typeof(LocalizationEnum)).Length)
            {
                // Less
                if (characterName.Count < System.Enum.GetNames(typeof(LocalizationEnum)).Length)
                {
                    for (int i = characterName.Count; i < System.Enum.GetNames(typeof(LocalizationEnum)).Length; i++)
                    {
                        characterName.Add(new LanguageGeneric<string>());
                        characterName[i].languageEnum = (LocalizationEnum)i;
                        characterName[i].LanguageGenericType = "";
                    }
                }
                // More
                if (characterName.Count > System.Enum.GetNames(typeof(LocalizationEnum)).Length)
                {
                    for (int i = 0; i < characterName.Count - System.Enum.GetNames(typeof(LocalizationEnum)).Length; i++)
                    {
                        characterName.Remove(characterName[characterName.Count - 1]);
                    }
                }
            }
            // Character Avataras
            while (Avatars.Count > System.Enum.GetNames(typeof(AvatarType)).Length) { Avatars.RemoveAt(System.Enum.GetNames(typeof(AvatarType)).Length - 1); }

            for (int i = 0; i < Avatars.Count; i++)
            {
                Avatars[i].type = (AvatarType)i;
            }

            while (Avatars.Count != System.Enum.GetNames(typeof(AvatarType)).Length) { Avatars.Add(new CharacterSprite()); }
        }

        public string GetName()
        {
            LocalizationManager _manager = (LocalizationManager)Resources.Load("Languages");
            if (_manager != null)
            {
                return characterName.Find(text => text.languageEnum == _manager.SelectedLang()).LanguageGenericType;
            }
            else
            {
                return "Can't find Localization Manager in scene";
            }
        }

        public Sprite GetAvatar(AvatarPosition position, AvatarType type)
        {
            CharacterSprite cs = Avatars[(int)type];

            if (position == AvatarPosition.Left) return cs.LeftPosition;
            if (position == AvatarPosition.Right) return cs.RightPosition;

            return null;
        }
    }

    /**/
#if UNITY_EDITOR
    [CustomEditor(typeof(DialogueCharacterSO))]
    public class DialogueCharacterSOInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DialogueCharacterSO character = (DialogueCharacterSO)target;

            character.Validate();

            // Name
            EditorGUILayout.BeginVertical("HelpBox");
            EditorGUILayout.BeginHorizontal("HelpBox");
            EditorGUILayout.LabelField($"Character Name Settings");
            character.UseGlobalValue = EditorGUILayout.Toggle(" Use Global Value as Name", character.UseGlobalValue);
            EditorGUILayout.EndHorizontal();
            // Code Here
            if (character.UseGlobalValue)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("CustomizedName"), new GUIContent(" Dynamic Character Name"));
            }
            else
            {
                for (int i = 0; i < character.characterName.Count; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    character.characterName[i].LanguageGenericType = EditorGUILayout.TextField($" {character.characterName[i].languageEnum} Name", character.characterName[i].LanguageGenericType);
                    EditorGUILayout.EndHorizontal();
                }
            }
            character.textColor = EditorGUILayout.ColorField(" Character Text Color", character.textColor);
            EditorGUILayout.EndVertical();

            // Name
            EditorGUILayout.BeginVertical("HelpBox");
            EditorGUILayout.BeginVertical("HelpBox");
            EditorGUILayout.LabelField($"Character Sprite Settings");
            EditorGUILayout.EndVertical();
            // Code Here
            for (int i = 0; i < character.Avatars.Count; i++)
            {
                float originalLabelWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = 75;

                EditorGUILayout.LabelField(" " + character.Avatars[i].type.ToString(), EditorStyles.boldLabel);
                EditorGUILayout.BeginHorizontal();
                character.Avatars[i].LeftPosition = (Sprite)EditorGUILayout.ObjectField($"  Left Sprite", character.Avatars[i].LeftPosition, typeof(Sprite), false);
                character.Avatars[i].RightPosition = (Sprite)EditorGUILayout.ObjectField($" Right Sprite", character.Avatars[i].RightPosition, typeof(Sprite), false);
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndVertical();


            serializedObject.ApplyModifiedProperties();
        }

        #region Custom Drawer
        public static bool ShowArray(SerializedObject serializedObject, string PropertyName, string objectName)
        {
            EditorGUILayout.BeginVertical("HelpBox");

            SerializedProperty property = serializedObject.FindProperty(PropertyName);
            int count = property.arraySize;

            // Foldout
            Rect rect = EditorGUILayout.BeginVertical("HelpBox");
            GUIContent foldoutContent = new GUIContent($"{objectName} [{count}]");
            EditorGUILayout.LabelField($"List of {objectName} Value");
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical("HelpBox");

            // List
            for (int i = 0; i < count; i++)
            {
                int index = i;
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(property.GetArrayElementAtIndex(i), GUIContent.none);
                if (IconButton("d_P4_DeletedLocal", "", GUILayout.Width(EditorGUIUtility.singleLineHeight * 2f + 2), GUILayout.Height(EditorGUIUtility.singleLineHeight * 2f + 2)))
                {
                    property.DeleteArrayElementAtIndex(index);
                    serializedObject.ApplyModifiedProperties();
                    break;
                }
                EditorGUILayout.EndHorizontal();

                if (i < count - 1)
                {
                    EditorGUILayout.Separator();
                }
            }


            EditorGUILayout.EndVertical(); // End of List Vertical

            // Button
            if (IconButton("Toolbar Plus", $"Add New {objectName}"))
            {
                property.arraySize++;
                serializedObject.ApplyModifiedProperties();
            }

            EditorGUILayout.EndVertical(); // End of Main Vertical

            return true;
        }
        public static bool IconButton(string iconName, string text, params GUILayoutOption[] options)
        {
            Texture icon = EditorGUIUtility.IconContent(iconName).image;
            GUIContent content = new GUIContent(text, icon);

            return GUILayout.Button(content, options);
        }
        #endregion
    }
#endif
}

[System.Serializable]
public class CharacterSprite
{
    public AvatarType type;
    public Sprite LeftPosition;
    public Sprite RightPosition;
}

[System.Serializable]
public enum AvatarPosition { None, Left, Right }

[System.Serializable]
public enum AvatarType { Normal = 0, Smile = 1, Suprized = 2, Disgust = 3, Crying = 4, Angry = 5 }
