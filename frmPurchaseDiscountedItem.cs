using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashierApplication
{
    public partial class frmPurchaseDiscountedItem : Form
    {
        private UserAccount user;
        public frmPurchaseDiscountedItem(UserAccount user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.user = user;

            MenuStrip fileStrip = new MenuStrip();
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            ToolStripMenuItem logoutItem = new ToolStripMenuItem("Logout");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");

            logoutItem.Click += (s, e) => { this.Close(); };
            exitItem.Click += (s, e) => { Application.Exit(); };

            fileMenu.DropDownItems.Add(logoutItem);
            fileMenu.DropDownItems.Add(exitItem);
            fileStrip.Items.Add(fileMenu);
        }

        private void btnCompute_Click_1(object sender, EventArgs e)
        {
            decimal price, discount, payment;
            int quantity;

            if (decimal.TryParse(txtboxPrice.Text, out price) &&
                int.TryParse(txtboxQuantity.Text, out quantity) &&
                decimal.TryParse(txtboxDiscount.Text, out discount) &&
                decimal.TryParse(txtboxPaymentReceived.Text, out payment))
            {
                discount /= 100;
                decimal total = price * quantity * (1 - discount);
                lblTotalAmt.Text = $"₱{total:N2}";

                if (payment < total)
                {
                    MessageBox.Show("Insufficient payment.");
                }
                else
                {
                    decimal change = payment - total;
                    lblChange.Text = $"₱{change:N2}";
                }
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            decimal price, discount;
            int quantity;

            if (decimal.TryParse(txtboxPrice.Text, out price) &&
                int.TryParse(txtboxQuantity.Text, out quantity) &&
                decimal.TryParse(txtboxDiscount.Text, out discount))
            {
                discount /= 100;
                decimal total = price * quantity * (1 - discount);
                lblTotalAmt.Text = $"₱{total:N2}";
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
        }

        private void logoutItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
