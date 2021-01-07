using UnityEngine;
using UnityEngine.AI;
public class LevelGenerator : MonoBehaviour
{

    public NavMeshSurface surface;
    public int width = 1000;
    public int height = 1000;

    [Header("墙")]
    public GameObject wall;
    [Header("玩家")]
    public GameObject player;
    [Header("建筑根节点")]
    public Transform buildRoot;
    [Header("是否放置玩家")]
    public bool playerSpawned = false;

    // Use this for initialization
    void Start()
    {

    }

    // Create a grid based level
    public void GenerateLevel()
    {
        // Loop over the grid
        for (int x = 0; x <= width; x += 2)
        {
            for (int y = 0; y <= height; y += 2)
            {
                // Should we place a wall?
                if (Random.value > 0.9f)
                {
                    // Spawn a wall
                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    GameObject clone = Instantiate(wall, pos, Quaternion.identity, buildRoot);
                    clone.name = "obstacle";
                }
                else if (!playerSpawned) // Should we spawn a player?
                {
                    // Spawn the player
                    Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
                    GameObject playerobj = Instantiate(player, pos, Quaternion.identity);
                    playerobj.name = "Player";
                    playerSpawned = true;
                }
            }
        }
    }
}