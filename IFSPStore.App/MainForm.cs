using IFSPStore.App.Infra;
using ReaLTaiizor.Forms;

namespace IFSPStore.App
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void ShowForm<TFormulario>() where TFormulario : Form
        {
            var cad = ConfigureDI.serviceProvider!.GetService<TFormulario>();
            if(cad != null && !cad.IsDisposed)
            {
                cad.MdiParent;
                cad.
            }
        }
    }
}
