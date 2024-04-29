using System.Collections;
using UnityEngine;

public class BulletTrace : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float renderDuration = 1f;

    public void RenderBulletTrace(Vector3 traceEndPosition)
    {
        Vector3[] renderPositions = new Vector3[2] { Vector3.zero, GetLocalEndPosition(traceEndPosition) };
        StartCoroutine(RenderLineTrace(renderPositions));
    }

    private IEnumerator RenderLineTrace(Vector3[] renderPositions)
    {
        lineRenderer.positionCount = renderPositions.Length;
        lineRenderer.SetPositions(renderPositions);
        yield return new WaitForSeconds(renderDuration);

        Destroy(gameObject);
    }

    /* 
     * Since LineRenderer uses local positions, we calculate the offset
     * between where the raycast hit the target and the barrel end.
     * The resulting Vector3 is the local position where the raycast hit.
     */
    private Vector3 GetLocalEndPosition(Vector3 traceEndPosition)
    {
        return traceEndPosition - transform.position;
    }
}