using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Xml.Linq;

namespace DynamicControls
{
    internal abstract class DynamicContract
    {
        private Dictionary<string, DynamicParameter> dictionary;

        private Form container;
        private Panel pForm;
        private int margin;

        private int numParameters;

        protected DynamicContract(Form container) 
        {
            dictionary = new Dictionary<string, DynamicParameter>();

            this.container = container;
            ConstructPanel();

            numParameters = 0;
            addParameters();
        }

        public object getValue(string _parmName)
        {
            return dictionary[_parmName].getValue();
        }

        protected abstract void addParameters();

        protected void addParameter(string _parmName)
        {
            DynamicParameter dp = new DynamicParameter(pForm, _parmName, ++numParameters, margin);
            dictionary[_parmName] = dp;
        }

        private void ConstructPanel()
        {
            container.SuspendLayout();

            int size = 300;
            margin = 15;
            
            pForm = new Panel();

            pForm.Dock = DockStyle.Right;
            pForm.Location = new Point(container.Width - margin - size,0);
            pForm.Name = "pForm";
            pForm.Size = new Size(size,container.Height);
            pForm.TabIndex = 0;
            pForm.BackColor = Color.White;

            container.Controls.Add(pForm);

            container.ResumeLayout(false);
        }
    }
}
