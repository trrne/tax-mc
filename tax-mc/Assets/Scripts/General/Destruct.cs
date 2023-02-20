using UnityEngine;

public class Destruct : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag(Batch.Tags["Destroy"]))
            Destroy(this.gameObject);
    }
}
