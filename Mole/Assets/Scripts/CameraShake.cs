using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static CameraShake Instance { get; private set; }

    private Vector3 originalPosition;

    private void Awake()
    {
        // 싱글톤 패턴 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // 카메라의 기본 로컬 위치 저장
        originalPosition = transform.localPosition;
    }

    /// <summary>
    /// 카메라 진동을 실행하는 메서드
    /// </summary>
    /// <param name="duration">지속 시간 (초)</param>
    /// <param name="magnitude">진동 강도</param>
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeRoutine(duration, magnitude));
    }

    private IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // PerlinNoise를 사용하여 부드러운 무작위 값 생성 (-1 ~ 1 범위)
            float x = (Mathf.PerlinNoise(Time.time * 50f, 0f) - 0.5f) * 2f * magnitude;
            float y = (Mathf.PerlinNoise(0f, Time.time * 50f) - 0.5f) * 2f * magnitude;

            // 카메라 위치 변경 (원래 위치 기준)
            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        // 진동 종료 후 원래 위치로 복구
        transform.localPosition = originalPosition;
    }
}