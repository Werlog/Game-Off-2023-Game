using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    private static Dungeon _singleton;

    public static Dungeon Singleton
    {
        get => _singleton;

        set
        {
            if (_singleton != null)
            {
                Debug.Log($"{nameof(Dungeon)}: Instance already exists, destroying duplicate");
                Destroy(value);
            }else
            {
                _singleton = value;
            }
        }
    }

    public List<GameObject> rooms = new List<GameObject>();
    public int dungeonSize = 25;

    private void Awake()
    {
        Singleton = this;
    }
}
