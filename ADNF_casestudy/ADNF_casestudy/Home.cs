using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADNF_casestudy
{
    public partial class Home : Form
    {
        private int childFormNumber = 0;
        public Home()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void addNewUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unit un = new Unit();
            un.Show();
        }

        private void aboutUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_info us = new User_info();
            us.Show();
        }

        private void addProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modify_Products ap = new Modify_Products();
            ap.Show();
        }

        private void modifyDealersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dealer_info di = new Dealer_info();
            di.Show();
        }

        private void purchaseProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase_product pur = new Purchase_product();
            pur.Show();
        }

        private void salesProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales sale = new Sales();
            sale.Show();
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase_report pr = new Purchase_report();
            pr.Show();
        }

        private void stocksReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_report sr = new Stock_report();
            sr.Show();
        }

        private void orderDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order_detail_report odr = new Order_detail_report();
            odr.Show();
        }
    }
}
