using Feto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : Singleton<Street>
{
    public int food { get; set; }
    int rats;

    private void Start() {
        rats = 1;
    }

    public bool HasAvaibleRats(int desiredRats) {
        return rats >= desiredRats;
    }

    public void Assign(int ratsToAssign) {
        rats += ratsToAssign;
    }

    public void Unassign(int ratsToUnassign) {
        rats -= 1;
    }

}
