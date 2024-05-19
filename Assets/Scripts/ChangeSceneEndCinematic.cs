using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChangeSceneEndCinematic : MonoBehaviour
{
    SceneChanger SceneChanger;
    VideoPlayer VideoPlayer;
    [SerializeField] Image BlackScreen;
    private void Awake()
    {
        SceneChanger = GetComponent<SceneChanger>();
        VideoPlayer = GetComponent<VideoPlayer>();
    }

    private void Start()
    {
        StartCoroutine(WaitEndOfCinematic());
    }

    IEnumerator WaitEndOfCinematic()
    {
        BlackScreen.enabled = false;

        yield return new WaitForSeconds((float)VideoPlayer.clip.length);
        VideoPlayer.enabled = false;
        BlackScreen.enabled = true;

        yield return new WaitForSeconds(.5f);
        SceneChanger.ChangeScene();
    }
}
