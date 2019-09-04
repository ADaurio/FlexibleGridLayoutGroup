namespace UnityEngine.UI
{
    [AddComponentMenu("Layout/Flexible Grid Layout Group", 152)]
    public class FlexibleGridLayoutGroup : GridLayoutGroup
    {
        public enum OffAxisCellSize
        {
            Flexible = 0,
            Count,
            AspectRatio
        }

        [SerializeField]
        protected OffAxisCellSize m_OffAxisScaling = OffAxisCellSize.Flexible;
        public OffAxisCellSize offAxisScaling { get { return m_OffAxisScaling; } set { SetProperty(ref m_OffAxisScaling, value); } }

        [SerializeField]
        protected int m_OffAxisCount = 1;
        public int offAxisCount { get { return m_OffAxisCount; } set { SetProperty(ref m_OffAxisCount, Mathf.Max(0, value)); } }

        [SerializeField]
        protected float m_OffAxisAspectRatio = 1;
        public float offAxisAspectRatio { get { return m_OffAxisAspectRatio; } set { SetProperty(ref m_OffAxisAspectRatio, Mathf.Max(0, value)); } }
        
        public override void SetLayoutHorizontal()
        {
            UpdateCellSize();
            base.SetLayoutHorizontal();
        }

        public override void SetLayoutVertical()
        {
            UpdateCellSize();
            base.SetLayoutVertical();
        }

        protected void UpdateCellSize()
        {
            if (constraint == Constraint.FixedColumnCount)
            {
                RectTransform rT = GetComponent<RectTransform>();
                Vector2 newCellSize = new Vector2((rT.rect.width - padding.horizontal) / constraintCount, 0);

                if (offAxisScaling == OffAxisCellSize.Flexible)
                {
                    newCellSize.y = (rT.rect.height - padding.vertical) / rectChildren.Count;
                }
                else if (offAxisScaling == OffAxisCellSize.Count)
                {
                    newCellSize.y = (rT.rect.height - padding.vertical) / offAxisCount;
                }
                else
                {
                    newCellSize.y = newCellSize.x * offAxisAspectRatio;
                }

                cellSize = newCellSize;
            }
            else if (constraint == Constraint.FixedRowCount)
            {
                RectTransform rT = GetComponent<RectTransform>();
                Vector2 newCellSize = new Vector2(0, (rT.rect.height - padding.vertical) / constraintCount);

                if (offAxisScaling == OffAxisCellSize.Flexible)
                {
                    newCellSize.x = (rT.rect.width - padding.horizontal) / rectChildren.Count;
                }
                else if (offAxisScaling == OffAxisCellSize.Count)
                {
                    newCellSize.x = (rT.rect.width - padding.horizontal) / offAxisCount;
                }
                else
                {
                    newCellSize.x = newCellSize.y * offAxisAspectRatio;
                }

                cellSize = newCellSize;
            }
        }
    }
}
