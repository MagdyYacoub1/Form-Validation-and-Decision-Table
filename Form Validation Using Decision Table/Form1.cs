using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Validation_Using_Decision_Table
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var allTextBoxes = GetAll(this, typeof(TextBox));
            MessageBox.Show("Total Controls: " + allTextBoxes.Count());
            /*foreach (TextBox tb in allTextBoxes)
            {
               // tb.Text = ...;
            }*/
        }
    }
}
