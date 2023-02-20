using UnityEngine;

[ExecuteAlways]
public class AllRoundRounder : MonoBehaviour
{
    void Start()
    {
        var tp = this.transform.position;
        transform.position = new(Mathf.Round(tp.x), Mathf.Round(tp.y));
    }
}
