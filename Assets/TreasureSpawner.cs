using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject treasurePrefab;  
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTreasure();


    }
    void SpawnTreasure()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned in TreasureSpawner!");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnLocation = spawnPoints[randomIndex];

        // Get surface height of terrain at this point
        float terrainHeight = Terrain.activeTerrain.SampleHeight(spawnLocation.position);

        // ?? Final buried chest position: slightly underground
        Vector3 buriedPosition = new Vector3(
            spawnLocation.position.x,
            terrainHeight - 1f, // 1 unit below terrain
            spawnLocation.position.z
        );

        GameObject spawnedChest = Instantiate(treasurePrefab, buriedPosition, Quaternion.identity);
        spawnedChest.SetActive(false); // hide it until dug

        // ?? Create Dig Zone

        GameObject digZone = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        digZone.transform.position = new Vector3(
            spawnLocation.position.x,
            terrainHeight,
            spawnLocation.position.z
        );
        SphereCollider col = digZone.GetComponent<SphereCollider>();
        col.isTrigger = true;
        col.radius = 1.5f; // Try increasing this radius

        digZone.transform.localScale = new Vector3(2f, 0.5f, 2f); // flattened zone
        digZone.GetComponent<MeshRenderer>().enabled = false; // hide the sphere

        // ?? Add DigSpot script to link with chest
        DigSpot digSpot = digZone.AddComponent<DigSpot>();
        digSpot.linkedChest = spawnedChest;

        // ?? Optional: set a tag for easier detection
        digZone.tag = "DigSpot";
    }


}
