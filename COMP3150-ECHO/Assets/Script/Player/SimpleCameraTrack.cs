using UnityEngine;
//https://pngtree.com/freepng/triangle-line-black-icon_3746346.html
// Triangle: <a href='https://pngtree.com/so/beautiful'>beautiful png from pngtree.com/</a>
public class SimpleCameraTrack : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        transform.position = player.position;
        transform.rotation = Quaternion.identity;
    }
}
