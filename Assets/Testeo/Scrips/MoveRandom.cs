using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     EventManager.Instance.OnSpellCast += Move;
    }

    private void Move() => StartCoroutine(MovCor());

    IEnumerator MovCor()
    {
        yield return new WaitForSeconds(.1f);
        transform.position = new Vector3(5,0,5);
    }

}
