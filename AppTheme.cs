using System.Drawing;
using System.Windows.Forms;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    /// <summary>
    /// Central UI theme so every form uses the same modern fitness-app colour palette.
    /// The DataGridView styling is intentionally defensive so older designer columns
    /// with Frozen=true cannot crash the application when AutoSizeColumnsMode is applied.
    /// </summary>
    internal static class AppTheme
    {
        private static readonly Color Background = Color.FromArgb(241, 248, 246);
        private static readonly Color Surface = Color.White;
        private static readonly Color Primary = Color.FromArgb(0, 121, 107);
        private static readonly Color PrimaryDark = Color.FromArgb(0, 77, 64);
        private static readonly Color Accent = Color.FromArgb(255, 193, 7);
        private static readonly Color Text = Color.FromArgb(33, 45, 49);
        private static readonly Color Border = Color.FromArgb(198, 221, 216);
        private static readonly Color Danger = Color.FromArgb(198, 40, 40);

        public static void Apply(Form form)
        {
            if (form == null)
            {
                return;
            }

            form.BackColor = Background;
            form.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            form.ForeColor = Text;
            ApplyToControls(form.Controls);
        }

        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                ApplyToControl(control);

                if (control.HasChildren)
                {
                    ApplyToControls(control.Controls);
                }
            }
        }

        private static void ApplyToControl(Control control)
        {
            GroupBox groupBox = control as GroupBox;
            if (groupBox != null)
            {
                groupBox.BackColor = Surface;
                groupBox.ForeColor = PrimaryDark;
                groupBox.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
                return;
            }

            Panel panel = control as Panel;
            if (panel != null)
            {
                panel.BackColor = Surface;
                return;
            }

            Button button = control as Button;
            if (button != null)
            {
                string text = button.Text == null ? string.Empty : button.Text.ToLowerInvariant();
                bool isDanger = text.Contains("logout") || text.Contains("cancel") || text.Contains("delete") || text.Contains("close");

                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = isDanger ? Danger : Primary;
                button.ForeColor = Color.White;
                button.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                button.Cursor = Cursors.Hand;
                return;
            }

            TextBox textBox = control as TextBox;
            if (textBox != null)
            {
                textBox.BackColor = Color.White;
                textBox.ForeColor = Text;
                textBox.BorderStyle = BorderStyle.FixedSingle;
                return;
            }

            ComboBox comboBox = control as ComboBox;
            if (comboBox != null)
            {
                comboBox.BackColor = Color.White;
                comboBox.ForeColor = Text;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                return;
            }

            DataGridView grid = control as DataGridView;
            if (grid != null)
            {
                ApplyGridTheme(grid);
                return;
            }

            LinkLabel linkLabel = control as LinkLabel;
            if (linkLabel != null)
            {
                linkLabel.BackColor = Color.Transparent;
                linkLabel.LinkColor = PrimaryDark;
                linkLabel.ActiveLinkColor = Primary;
                linkLabel.VisitedLinkColor = PrimaryDark;
                return;
            }

            Label label = control as Label;
            if (label != null)
            {
                // Dark label blocks are used as input captions in the designer.
                // Preserve white text so Design View and runtime stay readable.
                bool darkLabel = label.BackColor.ToArgb() == PrimaryDark.ToArgb()
                                 || label.BackColor.ToArgb() == Primary.ToArgb()
                                 || label.BorderStyle != BorderStyle.None;

                if (darkLabel)
                {
                    if (label.BorderStyle != BorderStyle.None)
                    {
                        label.BackColor = PrimaryDark;
                    }
                    label.ForeColor = Color.White;
                }
                else
                {
                    label.ForeColor = Text;
                }
                return;
            }

            StatusStrip statusStrip = control as StatusStrip;
            if (statusStrip != null)
            {
                statusStrip.BackColor = PrimaryDark;
                statusStrip.ForeColor = Color.White;
            }
        }

        private static void ApplyGridTheme(DataGridView grid)
        {
            grid.BackgroundColor = Surface;
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = Border;
            grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDark;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grid.DefaultCellStyle.BackColor = Surface;
            grid.DefaultCellStyle.ForeColor = Text;
            grid.DefaultCellStyle.SelectionBackColor = Primary;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 241);
            grid.RowHeadersVisible = false;
            grid.AllowUserToResizeRows = false;

            // Older designer files froze the first columns. A DataGridView throws an
            // InvalidOperationException if Fill sizing is inherited by frozen columns.
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.Frozen = false;
            }

            try
            {
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (System.InvalidOperationException)
            {
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }
    }
}
