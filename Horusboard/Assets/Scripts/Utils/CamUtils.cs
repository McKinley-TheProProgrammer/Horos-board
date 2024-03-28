using UnityEngine;

public static class CamUtils
{

    public static Vector3 ScreenToWorldCustom(Camera cam, Vector3 input)
    {
        input.z = cam.nearClipPlane;
        return cam.ScreenToWorldPoint(input);
    }
}
