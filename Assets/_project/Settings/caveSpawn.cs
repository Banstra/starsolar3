using UnityEngine;

public class caveSpawn : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public int gridX;
    public int gridZ;
    public float gridSpacingOffset = 1f;
    public Vector3 gridOrigin = Vector3.zero;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnGrid();
    }

    private void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + gridOrigin;
                PickAndSpawn(spawnPosition, Quaternion.identity);
            }
        }
    }

    private void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotatoinToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotatoinToSpawn);
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
