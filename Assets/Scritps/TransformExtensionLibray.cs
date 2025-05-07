using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensionLibray
{
    public static IEnumerator Move(this Transform transform, Vector3 pos, float duration)
    {
        float startTime = 0;
        Vector3 startPos = transform.position;

        while (startTime < duration)
        {
            startTime += Time.deltaTime;
            float t = startTime / duration;

            transform.position = Vector3.Lerp(startPos, pos, t);

            yield return null;
        }
    }
}
