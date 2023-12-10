using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CenterPointCheck : MonoBehaviour
{
    [SerializeField] Camera PlayerCamera;
    [SerializeField] TMP_Text textInCenter;
    void Start()
    {
        textInCenter.text = "";
    }
    void Update()
    {
        var ray = new Ray(transform.position, PlayerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            var script = hitInfo.collider.gameObject.GetComponent<TextOnWatching>();
            if (script)
            {
                if (hitInfo.distance <= script.distance) textInCenter.text = script.Text;
            }
        }
        else textInCenter.text = "";
    }
}
