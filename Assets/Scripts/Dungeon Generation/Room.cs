using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private byte doors = 0; // Top, right, bottom, left (binary number)
}
