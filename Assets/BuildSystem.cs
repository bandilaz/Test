using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{

    [SerializeField]
    Transform CamChild;

    [SerializeField]
    Transform FloorBuild;

    [SerializeField]
    Transform FloorPrefab;

    RaycastHit Hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(CamChild.position, CamChild.forward, out Hit, 15f)) { 
        
            FloorBuild.position = new Vector3(Mathf.RoundToInt(Hit.point.x) != 0 ? Mathf.RoundToInt(Hit.point.x/3) * 3 : 3 , 
                (Mathf.RoundToInt(Hit.point.y) != 0 ? Mathf.RoundToInt(Hit.point.y / 3) * 3 : 0) + FloorBuild.localScale.y, 
                Mathf.RoundToInt(Hit.point.z) != 0 ? Mathf.RoundToInt(Hit.point.z / 3) * 3 : 3);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(FloorPrefab, FloorBuild.position, Quaternion.identity);
        }

    }
}
