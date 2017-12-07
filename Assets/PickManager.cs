using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickManager : MonoBehaviour
{

    private static PickManager _instance;
    public static PickManager Instance { get { return _instance; } }

    private Transform[] pickUps;

    void Start()
    {
        _instance = this;
        pickUps = GetComponentsInChildren<Transform>();
    }


    void Update()
    {

    }

    public void DeactivatePick(GameObject disabled)
    {
        disabled.SetActive(false);
        StartCoroutine(EnablePickUp(disabled));
    }

    private IEnumerator EnablePickUp(GameObject toEnable)
    {
        yield return new WaitForSeconds(30f);
        foreach (var O in pickUps)
        {
            if (O.gameObject.Equals(toEnable))
            {
                O.gameObject.SetActive(true);
            }
        }
    }


}
