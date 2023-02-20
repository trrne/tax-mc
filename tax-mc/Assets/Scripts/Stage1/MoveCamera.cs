using UnityEngine;

[ExecuteAlways]
public class MoveCamera : Batch
{
    [SerializeField, Range(.1f, 2)]
    float distance = 2;

    GameObject playerObj;
    Transform player;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag(Tags["Player"]);
        player = playerObj.GetComponent<Transform>();
    }

    void Update() => transform.position = new(player.position.x, player.position.y + distance, -10);
}
