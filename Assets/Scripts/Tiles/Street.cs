using Feto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : Singleton<Street>
{
    int rats;

    private void Start() {
        rats = 1;
    }

    public bool HasAvaibleRats() {
        return rats > 0;
    }

    public void Assign() {
        rats += 1;
    }

    public void Unassign() {
        rats -= 1;
    }

}
