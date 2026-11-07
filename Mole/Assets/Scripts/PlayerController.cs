using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void TakeDamage()
    {
        // 예시: 0.2초 동안 0.3의 강도로 카메라 진동
        if (CameraShake.Instance != null)
        {
            CameraShake.Instance.Shake(0.2f, 0.3f);
        }
    }
}