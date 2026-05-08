using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EPL_DBMS.Utils
{
    public static class UIHelper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            int msg,
            int wParam,
            [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private const int EM_SETCUEBANNER = 0x1501;

        // ── Shared accent colors ────────────────────────────────────────────────
        public static readonly Color PrimaryAccent = Color.FromArgb(32, 84, 147);
        public static readonly Color AccentHover = Color.FromArgb(50, 110, 180);
        public static readonly Color DangerColor = Color.FromArgb(192, 57, 43);
        public static readonly Color SuccessColor = Color.FromArgb(39, 174, 96);
        public static readonly Color NeutralGray = Color.FromArgb(108, 117, 125);
        public static readonly Color SurfaceColor = Color.FromArgb(245, 246, 248);
        public static readonly Color GridHeaderColor = Color.FromArgb(32, 84, 147);
        public static readonly Color PlaceholderGray = Color.FromArgb(160, 160, 160);
        public static readonly Color LabelTextGray = Color.FromArgb(90, 90, 90);
        public static readonly Color SearchBoxYellow = Color.FromArgb(255, 255, 225);

        // ── Form Styling ────────────────────────────────────────────────────────
        public static void StyleForm(Form form)
        {
            form.BackColor = SurfaceColor;
            form.Font = new Font("Segoe UI", 9f);
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void SetPlaceholder(TextBox txt, string placeholder)
        {
            // The handle must be created before sending the message.
            // Accessing txt.Handle forces creation if the control is not yet shown.
            SendMessage(txt.Handle, EM_SETCUEBANNER, 1, placeholder);
        }

        // ── Standard Controls Styling ───────────────────────────────────────────
        public static void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
        }

        public static void StyleSearchBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = SearchBoxYellow;
            txt.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            txt.TextAlign = HorizontalAlignment.Center;
        }

        public static void StyleComboBox(ComboBox cmb)
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = new Font("Segoe UI", 9.5f);
        }

        public static void StyleLabel(Label lbl)
        {
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 8.25f);
            lbl.ForeColor = LabelTextGray;
            lbl.BackColor = Color.Transparent;
        }

        // ── Button Styling with Rounded Borders ─────────────────────────────────
        public static void StyleButton(Button btn, Color backColor, int borderRadius = 10)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(backColor, 0.15f);
            btn.MouseLeave += (s, e) => btn.BackColor = backColor;

            ApplyRoundedRegion(btn, borderRadius);
            btn.Resize += (s, e) => ApplyRoundedRegion(btn, borderRadius);
        }

        private static void ApplyRoundedRegion(Control control, int radius)
        {
            if (control.Width == 0 || control.Height == 0) return;

            using (var path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();

                // Dispose the previous Region to release its GDI handle before
                // replacing it — critical when called repeatedly on every resize.
                control.Region?.Dispose();
                control.Region = new Region(path);
            }
            // 'path' is disposed here by the 'using' block.
        }

        // ── DataGridView Styling ────────────────────────────────────────────────
        public static void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.FromArgb(220, 220, 220);

            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 36;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = GridHeaderColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(4, 0, 0, 0)
            };

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

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }
    }
}