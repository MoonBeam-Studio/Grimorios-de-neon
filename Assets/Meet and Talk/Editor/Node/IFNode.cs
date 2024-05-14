using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System.Linq;

namespace MEET_AND_TALK
{

    public class IFNode : BaseNode
    {
        public List<DialogueNodePort> dialogueNodePorts = new List<DialogueNodePort>();

        public string ValueName;
        public GlobalValueIFOperations Operations;
        public string OperationValue;

        private DropdownField ValueName_Field;
        private EnumField AvatarPositionField;
        private TextField Value_Field;

        public IFNode()
        {

        }

        public IFNode(Vector2 _position, DialogueEditorWindow _editorWindow, DialogueGraphView _graphView)
        {
            editorWindow = _editorWindow;
            graphView = _graphView;

            title = "IF Node";
            SetPosition(new Rect(_position, defualtNodeSize));
            nodeGuid = Guid.NewGuid().ToString();

            AddInputPort("Input ", Port.Capacity.Multi);
            AddOutputPort("If True", "True", Port.Capacity.Single);
            AddOutputPort("If False", "False", Port.Capacity.Single);

            // Value Name Field
            GlobalValueManager manager = Resources.Load<GlobalValueManager>("GlobalValue");
            manager.LoadFile();

            List<string> valueNames = new List<string>();
            valueNames.AddRange(manager.IntValues.Select(intValue => intValue.ValueName));
            valueNames.AddRange(manager.FloatValues.Select(floatValue => floatValue.ValueName));
            valueNames.AddRange(manager.BoolValues.Select(boolValue => boolValue.ValueName));

            ValueName_Field = new DropdownField(label: "Global Value", choices: (valueNames.Distinct().ToList()), defaultIndex: 0);
            ValueName_Field.RegisterValueChangedCallback(value =>
            {
                ValueName = value.newValue;   
                
                // SprawdŸ, czy ValueName znajduje siê w manager.IntValues lub manager.FloatValues
                bool isValueNameInIntValues = manager.IntValues.Any(intValue => intValue.ValueName == ValueName);
                bool isValueNameInFloatValues = manager.FloatValues.Any(floatValue => floatValue.ValueName == ValueName);

                // Ustaw widocznoœæ AvatarPositionField w zale¿noœci od warunków
                AvatarPositionField.style.display = isValueNameInIntValues || isValueNameInFloatValues ? DisplayStyle.Flex : DisplayStyle.None;
                Value_Field.style.display = isValueNameInIntValues || isValueNameInFloatValues ? DisplayStyle.Flex : DisplayStyle.None;
            });
            ValueName_Field.SetValueWithoutNotify(ValueName);
            mainContainer.Add(ValueName_Field);

            // Operation Enum Field
            AvatarPositionField = new EnumField("Operation", Operations);
            AvatarPositionField.RegisterValueChangedCallback(value =>
            {
                Operations = (GlobalValueIFOperations)value.newValue;
            });
            AvatarPositionField.SetValueWithoutNotify(Operations);
            mainContainer.Add(AvatarPositionField);

            // Value Field
            Value_Field = new TextField("Value");
            Value_Field.RegisterValueChangedCallback(value =>
            {
                OperationValue = value.newValue;
            });
            Value_Field.SetValueWithoutNotify(OperationValue);
            Value_Field.multiline = true;
            mainContainer.Add(Value_Field);
        }

        public override void LoadValueInToField()
        {
            GlobalValueManager manager = Resources.Load<GlobalValueManager>("GlobalValue");
            manager.LoadFile();

            bool isValueNameInIntValues = manager.IntValues.Any(intValue => intValue.ValueName == ValueName);
            bool isValueNameInFloatValues = manager.FloatValues.Any(floatValue => floatValue.ValueName == ValueName);

            // Ustaw widocznoœæ AvatarPositionField w zale¿noœci od warunków
            AvatarPositionField.style.display = isValueNameInIntValues || isValueNameInFloatValues ? DisplayStyle.Flex : DisplayStyle.None;
            Value_Field.style.display = isValueNameInIntValues || isValueNameInFloatValues ? DisplayStyle.Flex : DisplayStyle.None;

            AvatarPositionField.SetValueWithoutNotify(Operations);
            Value_Field.SetValueWithoutNotify(OperationValue);
            ValueName_Field.SetValueWithoutNotify(ValueName);
        }
    }
}
