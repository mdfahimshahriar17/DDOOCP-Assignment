using System.Windows.Forms;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            // Apply the same theme immediately so Design View and runtime are consistent.
            AppTheme.Apply(this);
            ShowAssignmentHomeImage();
        }

        private void ShowAssignmentHomeImage()
        {
            // Final assignment home page: use only the approved home image resource.
            this.Text = "Fitness Tracker Home";
            this.BackgroundImage = null;
            pbxHome.Image = Properties.Resources.HomeImage;
            pbxHome.Dock = DockStyle.Fill;
            pbxHome.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxHome.TabStop = false;
        }
    }
}
