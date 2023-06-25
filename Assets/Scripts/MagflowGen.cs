using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagflowGen : MonoBehaviour
{
    [Header("Position Constants")]
    [SerializeField] private float startX;
    [SerializeField] private float startY;

    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;

    [Header("Prefabs")]
    [SerializeField] private GameObject magPrefab;

    [Header("Dependencies")]
    [SerializeField] private GameObject magFolder;

    [Header("Ingame")]
    [SerializeField] private List<Magflow> magActiveList;

    [Header("Debug")]
    private List<(int, int)> debugTest;

    // Start is called before the first frame update
    void Start()
    {
        debugTest = new List<(int, int)>
        {
            (0, 0),
            (0, 1),
            (0, 2),
            (1, 1),
            (-1, 0)
        };

        foreach ((int x, int y) in debugTest)
        {
            CreateMag(x, y);
        }
    }

    private void CreateMag(int x, int y)
    {
        GameObject newMag = Instantiate(magPrefab);

        if(y % 2 == 1)
        {
            newMag.transform.position = new Vector3(startX + (x - 0.5f) * offsetX, startY + y * offsetY);
        }
        else
        {
            newMag.transform.position = new Vector3(startX + x * offsetX, startY + y * offsetY);
        }

        newMag.transform.SetParent(magFolder.transform);

        Magflow magComp = newMag.GetComponent<Magflow>();
        magActiveList.Add(magComp);
    }

    private void AddLink()
    {

    }
    
}
