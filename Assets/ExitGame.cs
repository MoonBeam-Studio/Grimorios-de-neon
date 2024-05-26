using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    SceneChanger changer;
    // Start is called before the first frame update
    void Start()
    {
        changer = GetComponent<SceneChanger>();

        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5f);
        changer.ChangeScene();
    }
}
