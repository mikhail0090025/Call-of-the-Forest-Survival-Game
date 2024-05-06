using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildingsWindow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    protected List<AvailableProject> availableProjects;
    public List<AvailableProject> AvailableProjects => availableProjects;
    public static GameObject CurrentProject;
    public static bool ProjectSelected = false;
    void Start()
    {
        foreach (var availableProj in availableProjects)
        {
            availableProj.Button.onClick.AddListener(delegate
            {
                ProjectSelected = true;
                CurrentProject = Instantiate(availableProj.ProjectInstance, new Vector3(0,0,0), Quaternion.identity);
                CurrentProject.GetComponent<Collider>().enabled = false;
                WindowsManager.WMinstance.DeactivateAll();
                Debug.Log("Project selected!");
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ProjectSelected)
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                CurrentProject.transform.position = hitInfo.point;
            }
            if (Input.GetMouseButtonDown(0))
            {
                ProjectSelected = false;
                CurrentProject.GetComponent<Collider>().enabled = true;
                Debug.Log("Project set!");
            }
            if (Input.GetKey(KeyCode.R))
            {
                CurrentProject.transform.Rotate(0f, 40f * Time.deltaTime, 0f);
            }
        }
    }

    [System.Serializable]
    public class AvailableProject
    {
        public Button Button;
        public GameObject ProjectInstance;
    }
}
