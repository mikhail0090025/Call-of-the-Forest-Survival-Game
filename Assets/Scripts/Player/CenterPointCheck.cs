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
            var projectScript = hitInfo.collider.gameObject.GetComponent<BuildsProject>();
            if (script)
            {
                if (hitInfo.distance <= script.distance) textInCenter.text = script.Text;
                else textInCenter.text = "";
            }
            else textInCenter.text = "";

            var inventory = this.gameObject.GetComponent<PlayerInventory>();

            if (projectScript && Input.GetMouseButtonDown(0) && hitInfo.distance < BuildsProject.DistanceToContact)
            {
                foreach (var item in projectScript.materials)
                {
                    if(item.CountNeeded > item.CurrentCount)
                    {
                        bool WasTaken = false;
                        inventory.RemoveItem(item.ID, 1, out WasTaken);
                        if(WasTaken)
                        {
                            item.CurrentCount++;
                            projectScript.Refresh();
                            projectScript.Check();
                            Debug.Log("Item to build project was added!");
                            break;
                        }
                    }
                }
            }
        }
        else textInCenter.text = "";
    }
}
