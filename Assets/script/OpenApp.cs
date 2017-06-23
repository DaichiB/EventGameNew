using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenApp {

    [RuntimeInitializeOnLoadMethod]
    static void OpenManager()
    {
        UIManager.Create();
    }
}
