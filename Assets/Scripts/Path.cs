using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private Vector3 _maxRandomOffset;

    public IEnumerator<Vector3> GettingPosition()
    {
        Queue<Waypoint> waypoints = new(_waypoints);

        while (waypoints.Count > 1)
        {
            Waypoint waypoint = waypoints.Dequeue();

            yield return waypoint.Position + GetRandomOffset();
        }

        if (waypoints.Count > 0)
            yield return waypoints.Dequeue().Position;
    }

    private Vector3 GetRandomOffset()
    {
        return new Vector3(
            Random.Range(-_maxRandomOffset.x, _maxRandomOffset.x),
            Random.Range(-_maxRandomOffset.y, _maxRandomOffset.y),
            Random.Range(-_maxRandomOffset.z, _maxRandomOffset.z)
        );
    }
}