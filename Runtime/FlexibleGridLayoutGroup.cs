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
            var totalGridSpacing = spacing * (constraintCount - 1);
            if (constraint == Constraint.FixedColumnCount)
            {
                var rT = GetComponent<RectTransform>();
                var newCellSize = new Vector2((rT.rect.width - padding.horizontal - totalGridSpacing.x) / constraintCount, 0);

                if (offAxisScaling == OffAxisCellSize.Flexible)
                {
                    var rowCount = Mathf.Ceil((float) rectChildren.Count / constraintCount);
                    newCellSize.y = (rT.rect.height - padding.vertical - spacing.y*(rowCount-1)) / rowCount;
                }
                else if (offAxisScaling == OffAxisCellSize.Count)
                {
                    var offAxisCountSpacing = (offAxisCount - 1) * spacing.y;
                    newCellSize.y = (rT.rect.height - padding.vertical - offAxisCountSpacing) / offAxisCount;
                }
                else
                {
                    newCellSize.y = newCellSize.x * offAxisAspectRatio;
                }

                cellSize = newCellSize;
            }
            else if (constraint == Constraint.FixedRowCount)
            {
                var rT = GetComponent<RectTransform>();
                var newCellSize = new Vector2(0, (rT.rect.height - padding.vertical - totalGridSpacing.y) / constraintCount);

                if (offAxisScaling == OffAxisCellSize.Flexible)
                {
                    var colCount = Mathf.Ceil((float) rectChildren.Count / constraintCount);
                    newCellSize.x = (rT.rect.width - padding.horizontal - spacing.x*(colCount-1)) / colCount;
                }
                else if (offAxisScaling == OffAxisCellSize.Count)
                {
                    var offAxisCountSpacing = (offAxisCount - 1) * spacing.x;
                    newCellSize.x = (rT.rect.width - padding.horizontal - offAxisCountSpacing) / offAxisCount;
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
