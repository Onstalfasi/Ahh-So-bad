using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float lifeTime;

    public void Initialize(float time)
    {
        lifeTime = time;
        Destroy(gameObject, lifeTime);
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        // Сообщаем менеджеру о разрушении
        if (BallGame.Instance != null)
            BallGame.Instance.RemoveBall(gameObject);
    }
}
