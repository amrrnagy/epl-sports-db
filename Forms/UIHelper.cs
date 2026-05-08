using System.Drawing;
using System.Drawing.Drawing2D; // NEW: Required for drawing curved paths
using System.Windows.Forms;

namespace EPL_DBMS.Utils
{
    public static class UIHelper
    {
        // ── Shared accent colors ────────────────────────────────────────────────
        public static readonly Color PrimaryAccent = Color.FromArgb(32, 84, 147);   // EPL dark blue
        public static readonly Color AccentHover = Color.FromArgb(50, 110, 180);
        public static readonly Color DangerColor = Color.FromArgb(192, 57, 43);
        public static readonly Color SuccessColor = Color.FromArgb(39, 174, 96);
        public static readonly Color SurfaceColor = Color.FromArgb(245, 246, 248); // Light gray background
        public static readonly Color GridHeaderColor = Color.FromArgb(32, 84, 147);
        public static readonly Color PlaceholderGray = Color.FromArgb(160, 160, 160);

        // ── Placeholder logic ───────────────────────────────────────────────────
        public static void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = PlaceholderGray;

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = string.Empty;
                    txt.ForeColor = Color.Black;
                }
            };

            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = PlaceholderGray;
                }
            };
        }

        // ── Apply modern flat styling to a Button with CURVED BORDERS ───────────
        // NEW: Added an optional 'borderRadius' parameter (defaults to 10)
        public static void StyleButton(Button btn, Color backColor, int borderRadius = 10)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            // Subtle hover effect
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ControlPaint.Light(backColor, 0.15f);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = backColor;
            };

            // NEW: Apply the curved corners immediately
            ApplyRoundedRegion(btn, borderRadius);

            // NEW: Ensure corners stay curved even if the window/button is resized
            btn.Resize += (s, e) => ApplyRoundedRegion(btn, borderRadius);
        }

        // ── NEW: Helper method to draw and clip the curved corners ──────────────
        private static void ApplyRoundedRegion(Control control, int radius)
        {
            if (control.Width == 0 || control.Height == 0) return;

            GraphicsPath path = new GraphicsPath();

            // Draw the 4 curved corners
            path.AddArc(0, 0, radius, radius, 180, 90);                                       // Top-Left
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);                  // Top-Right
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90); // Bottom-Right
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);                  // Bottom-Left

            path.CloseAllFigures();

            // Apply the new curved shape to the control
            control.Region = new Region(path);
        }

        // ── Apply modern styling to a DataGridView ──────────────────────────────
        public static void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.FromArgb(220, 220, 220);

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = GridHeaderColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(4, 0, 0, 0)
            };
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 36;

            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 249, 252)
            };
            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9f),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(50, 50, 50),
                SelectionBackColor = Color.FromArgb(200, 220, 245),
                SelectionForeColor = Color.Black,
                Padding = new Padding(3, 2, 3, 2)
            };
            dgv.RowHeadersVisible = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }
    }
}