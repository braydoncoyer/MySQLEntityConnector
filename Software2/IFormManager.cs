using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2
{
    public interface IFormManager
    {
        void ShowForm<TForm>() where TForm : Form1;
    }
}
