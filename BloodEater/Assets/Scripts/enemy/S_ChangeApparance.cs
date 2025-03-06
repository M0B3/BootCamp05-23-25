using System.Collections.Generic;
using UnityEngine;

public class S_ChangeApparance : MonoBehaviour
{
    [SerializeField] private List<Material> firstApparance = new List<Material>();
    [SerializeField] private List<Material> secondeApparance = new List<Material>();

    [SerializeField] private List<Transform> Waypoints = new List<Transform>();

    public GameObject ennemy;
    public GameObject ennemy2;

    private MeshRenderer Mesh;
    private MeshRenderer Mesh2;

    private int i = 1;


    private void Start()
    {
        Mesh = ennemy.GetComponent<MeshRenderer>();
        Mesh2 = ennemy2.GetComponent<MeshRenderer>();
    }

    public void Update()
    {
        ChangeApparance();
        MoveMonster();
    }

    public void ChangeApparance()
    {
        
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            Mesh.material = firstApparance[i];
            Mesh2.material = secondeApparance[i];

            i++;
        }

        if (i >= 3) 
        {
            i=3;
        }

        if (i <= 0) 
        {
            i=0;
        }
    }

    public void MoveMonster()
    {
        Transform tempTransform;

        switch (i)
        {
            case 1:
                tempTransform = Waypoints[0];
                break;
            case 2:
                tempTransform = Waypoints[1];
                break;
            case 3:
                tempTransform = Waypoints[2];
            break;

            default:
                tempTransform = transform;
            break;
        }

        ennemy.transform.position = tempTransform.position;
    }
}
