using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace LuckyDenfensePrototype
{
    public class RangeDisplayUI : MonoBehaviour
    {
        [SerializeField] private Tile tile;
        [SerializeField] private Image rangeCircleImage;

        public void RangeSetup()
        {
            if (tile.standingGuardians.Count > 0)
            {
                transform.position = tile.transform.position;
                Guardian guardian = tile.standingGuardians[0];
                float range = guardian.range;
                
                Camera cam = Camera.main;

                // Lấy vị trí nhân vật (giữa vòng tròn)
                Vector3 worldPosCenter = tile.transform.position;

                // Lấy điểm cách range đơn vị theo trục X (hoặc bất kỳ hướng nào)
                Vector3 worldPosEdge = worldPosCenter + Vector3.right * range;

                // Chuyển 2 điểm sang màn hình (pixel)
                Vector3 screenCenter = cam.WorldToScreenPoint(worldPosCenter);
                Vector3 screenEdge = cam.WorldToScreenPoint(worldPosEdge);

                // Tính đường kính bằng pixel
                float diameterInPixels = Vector2.Distance(screenCenter, screenEdge) * 2f;

                // Đặt kích thước vòng tròn UI
                rangeCircleImage.rectTransform.sizeDelta = new Vector2(diameterInPixels, diameterInPixels);

                // (Tùy canvas loại gì mà cần đặt vị trí đúng nữa – ví dụ nếu canvas dạng World Space thì xử lý khác)
            }
        }
    }
}