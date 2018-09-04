using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2
{
    public partial class Form1 : Form
    {
        U04uzGEntities entities = new U04uzGEntities();
        public Form1()
        {
            InitializeComponent();
            errorLabel.Text = "";
            passwordTextBox.PasswordChar = '*' ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            user myUsername = entities.users.FirstOrDefault(user => user.userName.Equals(usernameTextBox.Text));
            user myPassword = entities.users.FirstOrDefault(user => user.password.Equals(passwordTextBox.Text));

            
            //Login
            if(usernameTextBox.Text != "" & passwordTextBox.Text != "")
            {
                // The below is used to determine if the username and password match and are case sensitive
                int compareUsername = string.Compare(myUsername.userName, usernameTextBox.Text, false);
                int comparePassword = string.Compare(myPassword.password, passwordTextBox.Text, false);

                if (myUsername != null & myPassword != null & compareUsername == 0 & comparePassword == 0)
                {
                    Main form = new Main();
                    this.Hide();
                    form.Show();
                }
                else
                {
                    errorLabel.Text = "Username/Password does not exist";
                }
            }
            else
            {
                errorLabel.Text = "Please provide a username and password to login";
            }
        }
    }
}
