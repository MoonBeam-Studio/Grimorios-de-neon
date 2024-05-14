using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using System.IO;
using System;
#endif
using UnityEngine;
using UnityEngine.UIElements;

namespace MEET_AND_TALK
{
    [CreateAssetMenu(menuName = "Dialogue/New Dialogue")]
    [System.Serializable]
    public class DialogueContainerSO : ScriptableObject
    {
        public List<NodeLinkData> NodeLinkDatas = new List<NodeLinkData>();

        public List<DialogueChoiceNodeData> DialogueChoiceNodeDatas = new List<DialogueChoiceNodeData>();
        public List<DialogueNodeData> DialogueNodeDatas = new List<DialogueNodeData>();
        public List<TimerChoiceNodeData> TimerChoiceNodeDatas = new List<TimerChoiceNodeData>();
        public List<EndNodeData> EndNodeDatas = new List<EndNodeData>();
        public List<EventNodeData> EventNodeDatas = new List<EventNodeData>();
        public List<StartNodeData> StartNodeDatas = new List<StartNodeData>();
        public List<RandomNodeData> RandomNodeDatas = new List<RandomNodeData>();
        public List<CommandNodeData> CommandNodeDatas = new List<CommandNodeData>();
        public List<IfNodeData> IfNodeDatas = new List<IfNodeData>();

        public List<BaseNodeData> AllNodes
        {
            get
            {
                List<BaseNodeData> tmp = new List<BaseNodeData>();
                tmp.AddRange(DialogueNodeDatas);
                tmp.AddRange(DialogueChoiceNodeDatas);
                tmp.AddRange(TimerChoiceNodeDatas);
                tmp.AddRange(EndNodeDatas);
                tmp.AddRange(EventNodeDatas);
                tmp.AddRange(StartNodeDatas);
                tmp.AddRange(RandomNodeDatas);
                tmp.AddRange(CommandNodeDatas);
                tmp.AddRange(IfNodeDatas);

                return tmp;
            }
        }

#if UNITY_EDITOR
        public void GenerateCSV(string filePath, MEET_AND_TALK.DialogueContainerSO SO)
        {
            // List to store TSV content
            List<string> tsvContent = new List<string>();

            // Define file path for saving TSV file

            /* GENERATING HEADER */
            // List to store header texts
            List<string> headerTexts = new List<string>();
            headerTexts.Add("GUID ID"); // Add GUID ID as the first header
                                        // Loop through each language enum and add it to the header
            foreach (LocalizationEnum language in (LocalizationEnum[])Enum.GetValues(typeof(LocalizationEnum)))
            {
                headerTexts.Add(language.ToString());
            }
            // Concatenate header texts with tab separators
            string finalHeader = string.Join("\t", headerTexts);

            // Write header to file
            TextWriter tw = new StreamWriter(filePath, false, System.Text.Encoding.UTF32);
            tw.WriteLine(finalHeader);
            tw.Close();
            /* GENERATING HEADER */

            /* GENERATING TEXT CONTENT */
            // Loop through each type of dialogue node to extract text content
            // Dialogue Node
            for (int i = 0; i < SO.DialogueNodeDatas.Count; i++)
            {
                List<string> dialogueNodeContent = new List<string>();
                dialogueNodeContent.Add(SO.DialogueNodeDatas[i].NodeGuid); // Add Node GUID
                                                                           // Loop through each text type for the dialogue node
                for (int j = 0; j < SO.DialogueNodeDatas[i].TextType.Count; j++)
                {
                    dialogueNodeContent.Add(SO.DialogueNodeDatas[i].TextType[j].LanguageGenericType);
                }
                // Concatenate dialogue node content with tab separators
                string dialogueNodeFinal = string.Join("\t", dialogueNodeContent);
                tsvContent.Add(dialogueNodeFinal); // Add dialogue node content to TSV content list
            }

            // Choice Dialogue Node
            for (int i = 0; i < SO.DialogueChoiceNodeDatas.Count; i++)
            {
                List<string> choiceNodeContent = new List<string>();
                choiceNodeContent.Add(SO.DialogueChoiceNodeDatas[i].NodeGuid); // Add Node GUID
                                                                               // Loop through each text type for the choice dialogue node
                for (int j = 0; j < SO.DialogueChoiceNodeDatas[i].TextType.Count; j++)
                {
                    choiceNodeContent.Add(SO.DialogueChoiceNodeDatas[i].TextType[j].LanguageGenericType);
                }
                // Concatenate choice dialogue node content with tab separators
                string choiceNodeFinal = string.Join("\t", choiceNodeContent);
                tsvContent.Add(choiceNodeFinal); // Add choice dialogue node content to TSV content list

                // Loop through each dialogue node port for the choice dialogue node
                for (int j = 0; j < SO.DialogueChoiceNodeDatas[i].DialogueNodePorts.Count; j++)
                {
                    List<string> choiceNodeChoiceContent = new List<string>();
                    choiceNodeChoiceContent.Add(SO.DialogueChoiceNodeDatas[i].DialogueNodePorts[j].PortGuid); // Add Port GUID
                                                                                                              // Loop through each text language for the dialogue node port
                    for (int k = 0; k < SO.DialogueChoiceNodeDatas[i].DialogueNodePorts[j].TextLanguage.Count; k++)
                    {
                        choiceNodeChoiceContent.Add(SO.DialogueChoiceNodeDatas[i].DialogueNodePorts[j].TextLanguage[k].LanguageGenericType);
                    }
                    // Concatenate choice dialogue node port content with tab separators
                    string choiceNodeChoiceFinal = string.Join("\t", choiceNodeChoiceContent);
                    tsvContent.Add(choiceNodeChoiceFinal); // Add choice dialogue node port content to TSV content list
                }
            }

            // Timer Choice Node
            for (int i = 0; i < SO.TimerChoiceNodeDatas.Count; i++)
            {
                List<string> choiceNodeContent = new List<string>();
                choiceNodeContent.Add(SO.TimerChoiceNodeDatas[i].NodeGuid); // Add Node GUID
                                                                            // Loop through each text type for the timer choice node
                for (int j = 0; j < SO.TimerChoiceNodeDatas[i].TextType.Count; j++)
                {
                    choiceNodeContent.Add(SO.TimerChoiceNodeDatas[i].TextType[j].LanguageGenericType);
                }
                // Concatenate timer choice node content with tab separators
                string choiceNodeFinal = string.Join("\t", choiceNodeContent);
                tsvContent.Add(choiceNodeFinal); // Add timer choice node content to TSV content list

                // Loop through each dialogue node port for the timer choice node
                for (int j = 0; j < SO.TimerChoiceNodeDatas[i].DialogueNodePorts.Count; j++)
                {
                    List<string> choiceNodeChoiceContent = new List<string>();
                    choiceNodeChoiceContent.Add(SO.TimerChoiceNodeDatas[i].DialogueNodePorts[j].PortGuid); // Add Port GUID
                                                                                                           // Loop through each text language for the dialogue node port
                    for (int k = 0; k < SO.TimerChoiceNodeDatas[i].DialogueNodePorts[j].TextLanguage.Count; k++)
                    {
                        choiceNodeChoiceContent.Add(SO.TimerChoiceNodeDatas[i].DialogueNodePorts[j].TextLanguage[k].LanguageGenericType);
                    }
                    // Concatenate timer choice node port content with tab separators
                    string choiceNodeChoiceFinal = string.Join("\t", choiceNodeChoiceContent);
                    tsvContent.Add(choiceNodeChoiceFinal); // Add timer choice node port content to TSV content list
                }
            }
            /* GENERATING TEXT CONTENT */

            // Append content to file
            tw = new StreamWriter(filePath, true, System.Text.Encoding.UTF32);
            // Write each line of TSV content to file
            foreach (string line in tsvContent)
            {
                tw.WriteLine(line);
            }
            tw.Close();

            // Log file path
            Debug.Log("TSV file generated at: " + filePath);
        }
        public void ImportText(string filePath, MEET_AND_TALK.DialogueContainerSO SO)
        {
            // Define the file path for the text file
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                // Log an error if the file does not exist
                Debug.LogError("File does not exist at path: " + filePath);
                return;
            }

            try
            {
                // Open the file for reading
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    bool headerSkipped = false;
                    // Read each line of the file
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Skip the header line
                        if (!headerSkipped)
                        {
                            headerSkipped = true;
                            continue;
                        }

                        // Split the line into fields
                        string[] fields = line.Split('\t');

                        // Get GUID
                        string nodeGuid = fields[0];

                        // Update Dialogue Node data
                        for (int i = 0; i < SO.DialogueNodeDatas.Count; i++)
                        {
                            if (nodeGuid == SO.DialogueNodeDatas[i].NodeGuid)
                            {
                                // Update text for each language
                                for (int j = 0; j < fields.Length - 1; j++)
                                {
                                    SO.DialogueNodeDatas[i].TextType[j].LanguageGenericType = fields[j + 1];
                                }
                            }
                        }

                        // Update Choice Node data
                        for (int i = 0; i < SO.DialogueChoiceNodeDatas.Count; i++)
                        {
                            // Update text for Choice Node
                            if (nodeGuid == SO.DialogueChoiceNodeDatas[i].NodeGuid)
                            {
                                // Update text for each language
                                for (int j = 0; j < fields.Length - 1; j++)
                                {
                                    SO.DialogueChoiceNodeDatas[i].TextType[j].LanguageGenericType = fields[j + 1];
                                }
                            }
                            // Update text for Answer Nodes
                            for (int j = 0; j < SO.DialogueChoiceNodeDatas[i].DialogueNodePorts.Count; j++)
                            {
                                if (SO.DialogueChoiceNodeDatas[i].DialogueNodePorts[j].PortGuid == nodeGuid)
                                {
                                    // Update text for each language
                                    for (int k = 0; k < fields.Length - 1; k++)
                                    {
                                        SO.DialogueChoiceNodeDatas[i].DialogueNodePorts[j].TextLanguage[k].LanguageGenericType = fields[k + 1];
                                    }
                                }
                            }
                        }

                        // Update Timer Choice Node data
                        for (int i = 0; i < SO.TimerChoiceNodeDatas.Count; i++)
                        {
                            // Update text for Choice Node
                            if (nodeGuid == SO.TimerChoiceNodeDatas[i].NodeGuid)
                            {
                                // Update text for each language
                                for (int j = 0; j < fields.Length - 1; j++)
                                {
                                    SO.TimerChoiceNodeDatas[i].TextType[j].LanguageGenericType = fields[j + 1];
                                }
                            }
                            // Update text for Answer Nodes
                            for (int j = 0; j < SO.TimerChoiceNodeDatas[i].DialogueNodePorts.Count; j++)
                            {
                                if (SO.TimerChoiceNodeDatas[i].DialogueNodePorts[j].PortGuid == nodeGuid)
                                {
                                    // Update text for each language
                                    for (int k = 0; k < fields.Length - 1; k++)
                                    {
                                        SO.TimerChoiceNodeDatas[i].DialogueNodePorts[j].TextLanguage[k].LanguageGenericType = fields[k + 1];
                                    }
                                }
                            }
                        }
                    }
                }

                // Log success message
                Debug.Log("Text imported successfully.");
            }
            catch (Exception e)
            {
                // Log error message if an exception occurs
                Debug.LogError("Error while importing text: " + e.Message);
            }
        }
#endif
    }
    [System.Serializable]
    public class NodeLinkData
    {
        public string BaseNodeGuid;
        public string TargetNodeGuid;
    }

    [System.Serializable]
    public class BaseNodeData
    {
        public string NodeGuid;
        public Vector2 Position;
    }

    [System.Serializable]
    public class DialogueChoiceNodeData : BaseNodeData
    {
        public List<DialogueNodePort> DialogueNodePorts;
        public List<LanguageGeneric<AudioClip>> AudioClips;
        public DialogueCharacterSO Character;
        public AvatarPosition AvatarPos;
        public AvatarType AvatarType;
        public List<LanguageGeneric<string>> TextType;
        public float Duration;
    }

    [System.Serializable]
    public class TimerChoiceNodeData : BaseNodeData
    {
        public List<DialogueNodePort> DialogueNodePorts;
        public List<LanguageGeneric<AudioClip>> AudioClips;
        public DialogueCharacterSO Character;
        public AvatarPosition AvatarPos;
        public AvatarType AvatarType;
        public List<LanguageGeneric<string>> TextType;
        public float Duration;
        public float time;
    }

    [System.Serializable]
    public class RandomNodeData : BaseNodeData
    {
        public List<DialogueNodePort> DialogueNodePorts;
    }

    [System.Serializable]
    public class DialogueNodeData : BaseNodeData
    {
        public List<DialogueNodePort> DialogueNodePorts;
        public List<LanguageGeneric<AudioClip>> AudioClips;
        public DialogueCharacterSO Character;
        public AvatarPosition AvatarPos;
        public AvatarType AvatarType;
        public List<LanguageGeneric<string>> TextType;
        public float Duration;
    }

    [System.Serializable]
    public class EndNodeData : BaseNodeData
    {
        public EndNodeType EndNodeType;
    }

    [System.Serializable]
    public class StartNodeData : BaseNodeData
    {
        public string startID;
    }


    [System.Serializable]
    public class EventNodeData : BaseNodeData
    {
        public List<EventScriptableObjectData> EventScriptableObjects;
    }
    [System.Serializable]
    public class EventScriptableObjectData
    {
        public DialogueEventSO DialogueEventSO;
    }

    [System.Serializable]
    public class CommandNodeData : BaseNodeData
    {
        public string commmand;
    }

    [System.Serializable]
    public class IfNodeData : BaseNodeData
    {
        public string ValueName;
        public GlobalValueIFOperations Operations;
        public string OperationValue;

        public string TrueGUID;
        public string FalseGUID;
    }


    [System.Serializable]
    public class LanguageGeneric<T>
    {
        public LocalizationEnum languageEnum;
        public T LanguageGenericType;
    }

    [System.Serializable]
    public class DialogueNodePort
    {
        public string PortGuid; //NOWE
        public string InputGuid;
        public string OutputGuid;
#if UNITY_EDITOR
        [HideInInspector] public Port MyPort;
#endif
        public TextField TextField;
        public List<LanguageGeneric<string>> TextLanguage = new List<LanguageGeneric<string>>();
    }

    [System.Serializable]
    public enum EndNodeType
    {
        End,
        Repeat,
        GoBack,
        ReturnToStart
    }


#if UNITY_EDITOR

    /* --------------------- */
    // Custom Property Draw
    /* --------------------- */


    [CustomEditor(typeof(DialogueContainerSO))]
    public class DialogueContainerSOEditor : Editor
    {
        bool NodeLink = false;
        bool StartNode = false;
        bool EndNode = false;
        bool DialogueNode = false;
        bool DialogueChoiceNode = false;
        bool DialogueTimerChoiceNode = false;
        bool DialogueEventNode = false;
        bool RandomNode = false;
        bool CommandNode = false;
        bool IFNode = false;

        public override void OnInspectorGUI()
        {
            EditorUtility.SetDirty(target);
            DialogueContainerSO _target = (DialogueContainerSO)target;

            // Base Info
            EditorGUI.indentLevel = 0;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(_target.name, EditorStyles.boldLabel);

            if (GUILayout.Button("Import File", EditorStyles.miniButtonLeft))
            {
                string path = EditorUtility.OpenFilePanel("Import Dialogue Localization File", Application.dataPath, "tsv");
                if (path.Length != 0)
                {
                    _target.ImportText(path, _target);
                    serializedObject.ApplyModifiedProperties();
                }
            }
            if (GUILayout.Button("Export File", EditorStyles.miniButtonRight))
            {
                string path = EditorUtility.SaveFilePanel("Export Dialogue Localization File", Application.dataPath, _target.name, "tsv");
                if (path.Length != 0)
                {
                    _target.GenerateCSV(path, _target);
                    serializedObject.ApplyModifiedProperties();
                }
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Connection Between Nodes", EditorStyles.boldLabel);

            #region Node Link
            EditorGUILayout.BeginVertical("HelpBox");
            int count = _target.NodeLinkDatas.Count;

            // Foldout
            Rect rect = EditorGUILayout.BeginVertical("HelpBox");
            EditorGUI.indentLevel++;
            GUIContent foldoutContent = new GUIContent($"Node Link [{count}]");
            NodeLink = EditorGUILayout.Foldout(NodeLink, foldoutContent, true);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if (NodeLink)
            {
                EditorGUILayout.BeginVertical("HelpBox");
                // List
                for (int i = 0; i < count; i++)
                {
                    int index = i;
                    EditorGUILayout.BeginHorizontal();
                    // Display Node
                    EditorGUILayout.BeginVertical("Box"); 
                    EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                    EditorGUILayout.LabelField("Node Link Between", EditorStyles.boldLabel);
                    EditorGUILayout.EndVertical();

                    EditorGUILayout.TextField("Base Node", _target.NodeLinkDatas[i].BaseNodeGuid);
                    EditorGUILayout.TextField("Target Node", _target.NodeLinkDatas[i].TargetNodeGuid);
                    EditorGUILayout.EndVertical();
                    // Display Node
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
            #endregion

            EditorGUILayout.LabelField("Base Node", EditorStyles.boldLabel);

            #region Start Node
            EditorGUILayout.BeginVertical("HelpBox");
            count = _target.StartNodeDatas.Count;

            // Foldout
            rect = EditorGUILayout.BeginVertical("HelpBox");
            EditorGUI.indentLevel++;
            foldoutContent = new GUIContent($"Start Node [{count}]");
            StartNode = EditorGUILayout.Foldout(StartNode, foldoutContent, true);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if (StartNode)
            {
                EditorGUILayout.BeginVertical("HelpBox");
                // List
                for (int i = 0; i < count; i++)
                {
                    int index = i;
                    EditorGUILayout.BeginHorizontal();
                    // Display Node
                    EditorGUILayout.BeginVertical("Box");
                    EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                    EditorGUILayout.LabelField("ID: " + _target.StartNodeDatas[i].NodeGuid, EditorStyles.boldLabel);
                    EditorGUILayout.EndVertical();
                    _target.StartNodeDatas[i].Position = EditorGUILayout.Vector2Field("Position", _target.StartNodeDatas[i].Position);
                    _target.StartNodeDatas[i].startID = EditorGUILayout.TextField("ID:", _target.StartNodeDatas[i].startID);
                    EditorGUILayout.EndVertical();
                    // Display Node
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
            #endregion

            #region End Node
            EditorGUILayout.BeginVertical("HelpBox");
            count = _target.EndNodeDatas.Count;

            // Foldout
            rect = EditorGUILayout.BeginVertical("HelpBox");
            EditorGUI.indentLevel++;
            foldoutContent = new GUIContent($"End Node [{count}]");
            EndNode = EditorGUILayout.Foldout(EndNode, foldoutContent, true);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if (EndNode)
            {
                EditorGUILayout.BeginVertical("HelpBox");
                // List
                for (int i = 0; i < count; i++)
                {
                    int index = i;
                    EditorGUILayout.BeginHorizontal();
                    // Display Node
                    EditorGUILayout.BeginVertical("Box");
                    EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                    EditorGUILayout.LabelField("ID: " + _target.EndNodeDatas[i].NodeGuid, EditorStyles.boldLabel);
                    EditorGUILayout.EndVertical();

                    _target.EndNodeDatas[i].Position = EditorGUILayout.Vector2Field("Position", _target.EndNodeDatas[i].Position);
                    _target.EndNodeDatas[i].EndNodeType = (EndNodeType)EditorGUILayout.EnumPopup("End Enum", _target.EndNodeDatas[i].EndNodeType);
                    EditorGUILayout.EndVertical();
                    // Display Node
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
            #endregion

            #region Dialogue Node
            EditorGUILayout.BeginVertical("HelpBox");
            count = _target.DialogueNodeDatas.Count;

            // Foldout
            rect = EditorGUILayout.BeginVertical("HelpBox");
            EditorGUI.indentLevel++;
            foldoutContent = new GUIContent($"Dialogue Node [{count}]");
            DialogueNode = EditorGUILayout.Foldout(DialogueNode, foldoutContent, true);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if (DialogueNode)
            {
                EditorGUILayout.BeginVertical("HelpBox");
                // List
                for (int i = 0; i < count; i++)
                {
                    int index = i;
                    EditorGUILayout.BeginHorizontal();
                    // Display Node
                    EditorGUILayout.BeginVertical("Box");
                    EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                    EditorGUILayout.LabelField("ID: " + _target.DialogueNodeDatas[i].NodeGuid, EditorStyles.boldLabel);
                    EditorGUILayout.EndVertical();

                    _target.DialogueNodeDatas[i].Position = EditorGUILayout.Vector2Field("Position", _target.DialogueNodeDatas[i].Position);
                    _target.DialogueNodeDatas[i].Character = (DialogueCharacterSO)EditorGUILayout.ObjectField("Character", _target.DialogueNodeDatas[i].Character, typeof(DialogueCharacterSO), false);
                    _target.DialogueNodeDatas[i].AvatarPos = (AvatarPosition)EditorGUILayout.EnumPopup("Avatar Display", _target.DialogueNodeDatas[i].AvatarPos);
                    _target.DialogueNodeDatas[i].AvatarType = (AvatarType)EditorGUILayout.EnumPopup("Avatar Emotion", _target.DialogueNodeDatas[i].AvatarType);

                    _target.DialogueNodeDatas[i].Duration = EditorGUILayout.FloatField("Display Time", _target.DialogueNodeDatas[i].Duration);

                    for (int j = 0; j < _target.DialogueNodeDatas[0].TextType.Count; j++)
                    {
                        EditorGUILayout.BeginVertical("Box");
                        EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                        EditorGUILayout.LabelField(_target.DialogueNodeDatas[0].TextType[j].languageEnum.ToString(), EditorStyles.boldLabel);
                        EditorGUILayout.EndVertical();
                        _target.DialogueNodeDatas[i].AudioClips[j].LanguageGenericType = (AudioClip)EditorGUILayout.ObjectField("Audio Clips", _target.DialogueNodeDatas[i].AudioClips[j].LanguageGenericType, typeof(AudioClip), false);
                        _target.DialogueNodeDatas[i].TextType[j].LanguageGenericType = EditorGUILayout.TextField("Displayed String", _target.DialogueNodeDatas[i].TextType[j].LanguageGenericType);
                        EditorGUILayout.EndVertical();
                    }
                    EditorGUILayout.EndVertical();
                    // Display Node
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
            #endregion

            #region Choice Node
            EditorGUILayout.BeginVertical("HelpBox");
            count = _target.DialogueChoiceNodeDatas.Count;

            // Foldout
            rect = EditorGUILayout.BeginVertical("HelpBox");
            EditorGUI.indentLevel++;
            foldoutContent = new GUIContent($"Choice Node [{count}]");
            DialogueChoiceNode = EditorGUILayout.Foldout(DialogueChoiceNode, foldoutContent, true);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if (DialogueChoiceNode)
            {
                EditorGUILayout.BeginVertical("HelpBox");
                // List
                for (int i = 0; i < count; i++)
                {
                    int index = i;
                    EditorGUILayout.BeginHorizontal();
                    // Display Node
                    EditorGUILayout.BeginVertical("Box");
                    EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                    EditorGUILayout.LabelField("ID: " + _target.DialogueChoiceNodeDatas[i].NodeGuid, EditorStyles.boldLabel);
                    EditorGUILayout.EndVertical();

                    _target.DialogueChoiceNodeDatas[i].Position = EditorGUILayout.Vector2Field("Position", _target.DialogueChoiceNodeDatas[i].Position);
                    _target.DialogueChoiceNodeDatas[i].Character = (DialogueCharacterSO)EditorGUILayout.ObjectField("Character", _target.DialogueChoiceNodeDatas[i].Character, typeof(DialogueCharacterSO), false);
                    _target.DialogueChoiceNodeDatas[i].AvatarPos = (AvatarPosition)EditorGUILayout.EnumPopup("Avatar Display", _target.DialogueChoiceNodeDatas[i].AvatarPos);
                    _target.DialogueChoiceNodeDatas[i].AvatarType = (AvatarType)EditorGUILayout.EnumPopup("Avatar Emotion", _target.DialogueChoiceNodeDatas[i].AvatarType);
                    _target.DialogueChoiceNodeDatas[i].Duration = EditorGUILayout.FloatField("Display Time", _target.DialogueChoiceNodeDatas[i].Duration);

                    for (int j = 0; j < _target.DialogueChoiceNodeDatas[0].TextType.Count; j++)
                    {
                        EditorGUILayout.BeginVertical("Box");
                        EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                        EditorGUILayout.LabelField(_target.DialogueChoiceNodeDatas[0].TextType[j].languageEnum.ToString(), EditorStyles.boldLabel);
                        EditorGUILayout.EndVertical();
                        _target.DialogueChoiceNodeDatas[i].AudioClips[j].LanguageGenericType = (AudioClip)EditorGUILayout.ObjectField("Audio Clips", _target.DialogueChoiceNodeDatas[i].AudioClips[j].LanguageGenericType, typeof(AudioClip), false);
                        _target.DialogueChoiceNodeDatas[i].TextType[j].LanguageGenericType = EditorGUILayout.TextField("Displayed String", _target.DialogueChoiceNodeDatas[i].TextType[j].LanguageGenericType);
                        EditorGUILayout.LabelField("Options: ", EditorStyles.boldLabel);
                        EditorGUI.indentLevel++;
                        for (int x = 0; x < _target.DialogueChoiceNodeDatas[i].DialogueNodePorts.Count; x++)
                        {
                            _target.DialogueChoiceNodeDatas[i].DialogueNodePorts[x].TextLanguage[j].LanguageGenericType = EditorGUILayout.TextField($"Option_{x + 1}", _target.DialogueChoiceNodeDatas[i].DialogueNodePorts[x].TextLanguage[j].LanguageGenericType);
                        }
                        EditorGUI.indentLevel--;
                        EditorGUILayout.EndVertical();
                    }
                    EditorGUILayout.EndVertical();
                    // Display Node
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
            #endregion

            #region Timer Choice Node
            EditorGUILayout.BeginVertical("HelpBox");
            count = _target.TimerChoiceNodeDatas.Count;

            // Foldout
            rect = EditorGUILayout.BeginVertical("HelpBox");
            EditorGUI.indentLevel++;
            foldoutContent = new GUIContent($"Timer Choice Node [{count}]");
            DialogueTimerChoiceNode = EditorGUILayout.Foldout(DialogueTimerChoiceNode, foldoutContent, true);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if (DialogueTimerChoiceNode)
            {
                EditorGUILayout.BeginVertical("HelpBox");
                // List
                for (int i = 0; i < count; i++)
                {
                    int index = i;
                    EditorGUILayout.BeginHorizontal();
                    // Display Node
                    EditorGUILayout.BeginVertical("Box");
                    EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                    EditorGUILayout.LabelField("ID: " + _target.TimerChoiceNodeDatas[i].NodeGuid, EditorStyles.boldLabel);
                    EditorGUILayout.EndVertical();

                    _target.TimerChoiceNodeDatas[i].Position = EditorGUILayout.Vector2Field("Position", _target.TimerChoiceNodeDatas[i].Position);
                    _target.TimerChoiceNodeDatas[i].Character = (DialogueCharacterSO)EditorGUILayout.ObjectField("Character", _target.TimerChoiceNodeDatas[i].Character, typeof(DialogueCharacterSO), false);
                    _target.TimerChoiceNodeDatas[i].AvatarPos = (AvatarPosition)EditorGUILayout.EnumPopup("Avatar Display", _target.TimerChoiceNodeDatas[i].AvatarPos);
                    _target.TimerChoiceNodeDatas[i].AvatarType = (AvatarType)EditorGUILayout.EnumPopup("Avatar Emotion", _target.TimerChoiceNodeDatas[i].AvatarType);
                    _target.TimerChoiceNodeDatas[i].Duration = EditorGUILayout.FloatField("Display Time", _target.TimerChoiceNodeDatas[i].Duration);
                    _target.TimerChoiceNodeDatas[i].time = EditorGUILayout.FloatField("Time to make decision", _target.TimerChoiceNodeDatas[i].time);

                    for (int j = 0; j < _target.TimerChoiceNodeDatas[0].TextType.Count; j++)
                    {
                        EditorGUILayout.BeginVertical("Box");
                        EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                        EditorGUILayout.LabelField(_target.TimerChoiceNodeDatas[0].TextType[j].languageEnum.ToString(), EditorStyles.boldLabel);
                        EditorGUILayout.EndVertical();
                        _target.TimerChoiceNodeDatas[i].AudioClips[j].LanguageGenericType = (AudioClip)EditorGUILayout.ObjectField("Audio Clips", _target.TimerChoiceNodeDatas[i].AudioClips[j].LanguageGenericType, typeof(AudioClip), false);
                        _target.TimerChoiceNodeDatas[i].TextType[j].LanguageGenericType = EditorGUILayout.TextField("Displayed String", _target.TimerChoiceNodeDatas[i].TextType[j].LanguageGenericType);
                        EditorGUILayout.LabelField("Options: ", EditorStyles.boldLabel);
                        EditorGUI.indentLevel++;
                        for (int x = 1; x < _target.TimerChoiceNodeDatas[i].DialogueNodePorts.Count; x++)
                        {
                            _target.TimerChoiceNodeDatas[i].DialogueNodePorts[x].TextLanguage[j].LanguageGenericType = EditorGUILayout.TextField($"Option_{x}", _target.TimerChoiceNodeDatas[i].DialogueNodePorts[x].TextLanguage[j].LanguageGenericType);
                        }
                        EditorGUI.indentLevel--;
                        EditorGUILayout.EndVertical();
                    }
                    EditorGUILayout.EndVertical();
                    // Display Node
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
            #endregion

            EditorGUILayout.LabelField("Functional Nodes", EditorStyles.boldLabel);

            #region Event Node
            EditorGUILayout.BeginVertical("HelpBox");
            count = _target.EventNodeDatas.Count;

            // Foldout
            rect = EditorGUILayout.BeginVertical("HelpBox");
            EditorGUI.indentLevel++;
            foldoutContent = new GUIContent($"Event Node [{count}]");
            DialogueEventNode = EditorGUILayout.Foldout(DialogueEventNode, foldoutContent, true);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if (DialogueEventNode)
            {
                EditorGUILayout.BeginVertical("HelpBox");
                // List
                for (int i = 0; i < count; i++)
                {
                    int index = i;
                    EditorGUILayout.BeginHorizontal();
                    // Display Node
                    EditorGUILayout.BeginVertical("Box");
                    EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                    EditorGUILayout.LabelField("ID: " + _target.EventNodeDatas[i].NodeGuid, EditorStyles.boldLabel);
                    EditorGUILayout.EndVertical();

                    _target.EventNodeDatas[i].Position = EditorGUILayout.Vector2Field("Position", _target.EventNodeDatas[i].Position);
                    EditorGUILayout.LabelField("Events: ", EditorStyles.boldLabel);
                    EditorGUI.indentLevel++;
                    for (int x = 0; x < _target.EventNodeDatas[i].EventScriptableObjects.Count; x++)
                    {
                        _target.EventNodeDatas[i].EventScriptableObjects[x].DialogueEventSO = (DialogueEventSO)EditorGUILayout.ObjectField($"Event_{x}", _target.EventNodeDatas[i].EventScriptableObjects[x].DialogueEventSO, typeof(DialogueEventSO), false);
                    }
                    EditorGUI.indentLevel--;
                    // Display Node
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
            #endregion

            #region Random Node
            EditorGUILayout.BeginVertical("HelpBox");
            count = _target.RandomNodeDatas.Count;

            // Foldout
            rect = EditorGUILayout.BeginVertical("HelpBox");
            EditorGUI.indentLevel++;
            foldoutContent = new GUIContent($"Random Node [{count}]");
            RandomNode = EditorGUILayout.Foldout(RandomNode, foldoutContent, true);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if (RandomNode)
            {
                EditorGUILayout.BeginVertical("HelpBox");
                // List
                for (int i = 0; i < count; i++)
                {
                    int index = i;
                    EditorGUILayout.BeginHorizontal();
                    // Display Node
                    EditorGUILayout.BeginVertical("Box");
                    EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                    EditorGUILayout.LabelField("ID: " + _target.RandomNodeDatas[i].NodeGuid, EditorStyles.boldLabel);
                    EditorGUILayout.EndVertical();

                    _target.RandomNodeDatas[i].Position = EditorGUILayout.Vector2Field("Position", _target.RandomNodeDatas[i].Position);

                    EditorGUILayout.LabelField("Ports: ", EditorStyles.boldLabel);
                    EditorGUI.indentLevel++;
                    for (int x = 0; x < _target.RandomNodeDatas[i].DialogueNodePorts.Count; x++)
                    {
                        _target.RandomNodeDatas[i].DialogueNodePorts[x].InputGuid = EditorGUILayout.TextField($"Port {x + 1}", _target.RandomNodeDatas[i].DialogueNodePorts[x].InputGuid);
                    }
                    EditorGUI.indentLevel--;
                    EditorGUILayout.EndVertical();
                    // Display Node
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
            #endregion

            #region IF Node
            EditorGUILayout.BeginVertical("HelpBox");
            count = _target.IfNodeDatas.Count;

            // Foldout
            rect = EditorGUILayout.BeginVertical("HelpBox");
            EditorGUI.indentLevel++;
            foldoutContent = new GUIContent($"IF Node [{count}]");
            IFNode = EditorGUILayout.Foldout(IFNode, foldoutContent, true);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if (IFNode)
            {
                EditorGUILayout.BeginVertical("HelpBox");
                // List
                for (int i = 0; i < count; i++)
                {
                    int index = i;
                    EditorGUILayout.BeginHorizontal();
                    // Display Node
                    EditorGUILayout.BeginVertical("Box");
                    EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                    EditorGUILayout.LabelField("ID: " + _target.IfNodeDatas[i].NodeGuid, EditorStyles.boldLabel);
                    EditorGUILayout.EndVertical();

                    _target.IfNodeDatas[i].Position = EditorGUILayout.Vector2Field("Position", _target.IfNodeDatas[i].Position);
                    _target.IfNodeDatas[i].ValueName = EditorGUILayout.TextField("Global Value Name", _target.IfNodeDatas[i].ValueName);
                    _target.IfNodeDatas[i].Operations = (GlobalValueIFOperations)EditorGUILayout.EnumPopup("Operation", _target.IfNodeDatas[i].Operations);
                    _target.IfNodeDatas[i].OperationValue = EditorGUILayout.TextField("Operation Value", _target.IfNodeDatas[i].OperationValue);

                    EditorGUILayout.EndVertical();
                    // Display Node
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
            #endregion

            EditorGUILayout.LabelField("Decoration Nodes", EditorStyles.boldLabel);

            #region Comment Node
            EditorGUILayout.BeginVertical("HelpBox");
            count = _target.CommandNodeDatas.Count;

            // Foldout
            rect = EditorGUILayout.BeginVertical("HelpBox");
            EditorGUI.indentLevel++;
            foldoutContent = new GUIContent($"Comment Node [{count}]");
            CommandNode = EditorGUILayout.Foldout(CommandNode, foldoutContent, true);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if (CommandNode)
            {
                EditorGUILayout.BeginVertical("HelpBox");
                // List
                for (int i = 0; i < count; i++)
                {
                    int index = i;
                    EditorGUILayout.BeginHorizontal();
                    // Display Node
                    EditorGUILayout.BeginVertical("Box");
                    EditorGUILayout.BeginVertical("Toolbar", GUILayout.Height(30));
                    EditorGUILayout.LabelField("ID: " + _target.CommandNodeDatas[i].NodeGuid, EditorStyles.boldLabel);
                    EditorGUILayout.EndVertical();
                    _target.CommandNodeDatas[i].Position = EditorGUILayout.Vector2Field("Position", _target.CommandNodeDatas[i].Position);
                    _target.CommandNodeDatas[i].commmand = EditorGUILayout.TextField("Comment", _target.CommandNodeDatas[i].commmand, EditorStyles.textArea);
                    EditorGUILayout.EndVertical();
                    // Display Node
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
            #endregion

            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}