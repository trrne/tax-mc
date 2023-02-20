using System.Collections;
using UnityEngine;

public class PlayerAnimation : Movement
{
    [SerializeField]
    Sprite idle;
    [SerializeField]
    Sprite[] walks;
    public GameObject player;

    new void Start()
    {
        base.Start();
        StartCoroutine(WalkAnimation());
    }

    IEnumerator WalkAnimation()
    {
        int i = 0;
        while (true)
        {
            switch (State)
            {
                case PlayerState.Idle:
                    sr.sprite = idle;
                    yield return null;
                    break;

                case PlayerState.Walk:
                    i = i >= walks.Length - 1 ? 0 : i + 1;
                    sr.sprite = walks[i];
                    yield return new WaitForSeconds(0.1f);
                    break;
            }
        }
    }
}
