using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MEET_AND_TALK
{
    [CreateAssetMenu(menuName = "Dialogue/Event/Character Event")]
    [System.Serializable]
    public class GlobalValueEvent : DialogueEventSO
    {

        [HideInInspector] GlobalValueManager manager;

        //public GlobalValueClass ValueName2;
        //public string ValueName;
        //public GlobalValueOperations Operations;
        //public string Value;

        public GlobalValueOperationClass Operation;

        public override void RunEvent()
        {
            // Load Global Value
            manager = Resources.Load<GlobalValueManager>("GlobalValue");
            manager.LoadFile();

            manager.Set(Operation.ValueName, Operation.Operation, Operation.OperationValue);

            // Change Value
            
            //if(Operation.Operation == GlobalValueOperations.Add) { manager.Set(Operation.ValueName, Operation.OperationValue)}
            //manager.Set()

            base.RunEvent();
        }
    }
}
