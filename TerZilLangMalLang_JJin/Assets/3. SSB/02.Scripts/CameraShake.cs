using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    private void Awake()
    {
        instance = this;
    }
    public float shakeTimer = 0; //��鸲 ȿ�� �ð�
    public float shakeAmount; //��鸲 ����
    Vector3 offset;

    private void Update()
    {
        if (shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

            transform.position = transform.position + new Vector3(ShakePos.x, ShakePos.y, 0) + offset;

            shakeTimer -= Time.deltaTime;
        }
    }


    public void ShakeCamera(float shakePwr, float shakeDur)
    {
        shakeAmount = shakePwr;
        shakeTimer = shakeDur;
    }

}


