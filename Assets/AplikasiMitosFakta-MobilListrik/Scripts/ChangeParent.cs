using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeParent : MonoBehaviour
{
    private GameObject child;
    private Transform parent;

    void Start()
    {
        child = this.gameObject;
    }

    public void SetNewParent(Transform newParent)
    {
        child.transform.SetParent(newParent);
    }

    public void SetNewParentWithPosition(Transform newParent)
    {
        child.transform.SetParent(newParent, false);
    }

    public void SetNewParentWithPositionAt0(Transform newParent)
    {
        child.transform.SetParent(newParent, false);
        child.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void UnparentsObject()
    {
        child.transform.SetParent(null);
    }

    public void ChangeObjectPosition_X(float x)
    {
        child.transform.localPosition = new Vector3(x, child.transform.localPosition.y, child.transform.localPosition.z);
    }

    public void ChangeObjectPosition_Y(float y)
    {
        child.transform.localPosition = new Vector3(child.transform.localPosition.x, y, child.transform.localPosition.z);
    }

    public void ChangeObjectPosition_Z(float z)
    {
        child.transform.localPosition = new Vector3(child.transform.localPosition.x, child.transform.localPosition.y, z);
    }

}
