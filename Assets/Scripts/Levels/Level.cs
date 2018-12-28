using System;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    public abstract string Question();

    public abstract void Test();

    public abstract void Submit();
}
