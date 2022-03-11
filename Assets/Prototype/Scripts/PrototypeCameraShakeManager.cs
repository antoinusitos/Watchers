using System.Collections;
using UnityEngine;

namespace Prototype
{
    public class PrototypeCameraShakeManager : MonoBehaviour
    {
        public static PrototypeCameraShakeManager instance = null;

        private Transform selfTransform = null;

        private float speed = 5.0f;

        private float shakeRange = 0.3f;

        private float shakeTime = 0.5f;

        private Coroutine shakeCoroutine = null;

        private void Awake()
        {
            instance = this;
            selfTransform = transform;
        }

        public void Shake()
        {
            if (shakeCoroutine != null)
                StopCoroutine(shakeCoroutine);

            shakeCoroutine = StartCoroutine(Shaking());
        }

        private IEnumerator Shaking()
        {
            float timer = 0;

            Vector3 target = selfTransform.localPosition + GetRandomPos();

            while (timer <= shakeTime)
            {
                selfTransform.localPosition = Vector3.MoveTowards(selfTransform.localPosition, target, Time.deltaTime * speed);

                if (Vector3.Distance(selfTransform.localPosition, target) <= 0.1f)
                {
                    target = selfTransform.localPosition + GetRandomPos();
                }
                timer += Time.deltaTime;
                yield return null;
            }

            selfTransform.localPosition = Vector3.zero;
        }

        private Vector3 GetRandomPos()
        {
            return new Vector3(Random.Range(-shakeRange, shakeRange), Random.Range(-shakeRange, shakeRange), 0);
        }
    }
}