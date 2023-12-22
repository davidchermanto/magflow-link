using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LinkDirection
{
    TOP,
    TOPRIGHT,
    BOTTOMRIGHT,
    BOTTOM,
    BOTTOMLEFT,
    TOPLEFT
}

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
    [SerializeField] private List<Sprite> magSprites;

    [Header("Ingame")]
    [SerializeField] private List<Magflow> magActiveList;

    [Header("Debug")]
    private List<(int, int)> debugTest;

    // Start is called before the first frame update
    void Start()
    {
        Debug();
    }

    private void Debug()
    {
        debugTest = new List<(int, int)>
        {
            (0, 0),
            (0, 1),
            (0, 2),
            (1, 1),
            (1, 2),
            (-1, 0),
            (-1, 1),
            (-1, -1)
        };

        foreach ((int x, int y) in debugTest)
        {
            CreateMag(x, y);
        }

        CreateMag(0, -2, MagType.RECEIVE);
        CreateMag(2, 1, MagType.RECEIVE);
        CreateMag(-1, 2, MagType.PROVIDE);
    }

    private void CreateMag(int x, int y, MagType magType = MagType.LINK)
    {
        GameObject newMag = Instantiate(magPrefab);

        if(Mathf.Abs(y) % 2 == 1)
        {
            newMag.transform.position = new Vector3(startX + (x - 0.5f) * offsetX, startY + y * offsetY);
        }
        else
        {
            newMag.transform.position = new Vector3(startX + x * offsetX, startY + y * offsetY);
        }

        newMag.transform.SetParent(magFolder.transform);

        Sprite sprite = magSprites[0];
        switch (magType)
        {
            case MagType.RECEIVE:
                sprite = magSprites[2];
                break;
            case MagType.PROVIDE:
                sprite = magSprites[1];
                break;
        }


        Magflow magComp = newMag.GetComponent<Magflow>();
        magComp.Setup(x, y, magType, new List<Sprite> { sprite, magSprites[3]});

        magActiveList.Add(magComp);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="linkDirection"></param>
    private void AddLink(int x, int y, LinkDirection linkDirection)
    {

    }

    /// <summary>
    /// Evaluate conditions of the board, whether it has succeeded or not, etc, and update power lines
    /// </summary>
    public void EvaluatePower()
    {

    }
    
}
