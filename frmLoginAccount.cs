using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;

namespace CashierApplication
{
    public partial class frmLoginAccount : Form
    {
        private UserAccount user;
        private List<UserAccount> users;   

        public frmLoginAccount()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            users = new List<UserAccount>
            {
                new Cashier("admin", "1234", "Jesler Guzman", "IT Department"),
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            user = users.Find(u => u.ValidateCredentials(txtBoxUsername.Text, txtBoxPassword.Text));

            if (user != null)
            {
                MessageBox.Show($"Welcome {user.Name} to {user.Department}!", "Login Successful");

                frmPurchaseDiscountedItem mainForm = new frmPurchaseDiscountedItem(user);
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}