using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New File Instrument Config", menuName = "Instrument Config")]
public class MusicIntrumentConfig : ScriptableObject
{
    [SerializeField] Transform pathPrefabs;
    [SerializeField] List<GameObject> instruments;

    public Transform GetPathPrefabs()
    {
        return pathPrefabs;
    }
}
