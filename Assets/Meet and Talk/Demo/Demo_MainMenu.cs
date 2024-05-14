using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MEET_AND_TALK
{
    public class Demo_MainMenu : MonoBehaviour
    {
        public TMPro.TMP_InputField NameInput;
        public GlobalValueClass NameGlobalValue;

        GlobalValueManager manager;

        public void Awake()
        {
            manager = Resources.Load<GlobalValueManager>("GlobalValue");
            manager.LoadFile();

            NameInput.text = manager.Get(NameGlobalValue.ValueName);
        }

        public void DemoChangeValue(string Test)
        {
            manager.Set(NameGlobalValue.ValueName, NameInput.text);
        }

        public void OpenDemo(int ID)
        {
            SceneManager.LoadScene(ID);
        }

        //public 
    }
}
