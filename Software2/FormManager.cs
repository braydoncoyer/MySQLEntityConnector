using System;
using SimpleInjector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2
{
    public class FormManager : IFormManager
    {
        private readonly Container container;
        private readonly Dictionary<Type, Form1> ActiveForms;

        public FormManager(Container container)
        {
            this.container = container;
            this.ActiveForms = new Dictionary<Type, Form1>();
        }

        public void ShowForm<TForm>() where TForm : Form1
        {
            Form form;
            if (this.ActiveForms.ContainsKey(typeof(TForm)))
            {
                form = this.ActiveForms[typeof(TForm)];
            }
            else
            {
                form = GetForm<TForm>();
                //this.ActiveForms.Add(form.GetType(), form);
                form.Closed += (s, e) => this.ActiveForms.Remove(form.GetType());
            }
            form.Show();
        }

        private Form GetForm<TForm>() where TForm : Form
        {
            return this.container.GetInstance<TForm>();
        }
    }
}
