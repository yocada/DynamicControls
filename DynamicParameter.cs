using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicControls
{
    internal class DynamicParameter
    {
        private string name;
        
        private Panel container;
        private Label label;
        private TextBox textBox;

        private Panel parent;

        private int margin;

        private int numParameter;

        public DynamicParameter(Panel _parent, string _name, int _numParameter, int _margin)
        {
            container = new Panel();
            parent = _parent;
            margin = _margin;
            
            name = _name;

            numParameter = _numParameter;

            ConstructControl();
        }

        public Control getControl()
        {
            return container;
        }

        public object getValue()
        {
            return textBox.Text;
        }

        private void ConstructControl()
        {
            parent.SuspendLayout();

            container.Dock = DockStyle.Top;
            container.Location = new Point(0, margin * 3 * (numParameter - 1));
            container.Name = "p" + name;
            container.Size = new Size(parent.Width, margin*3);
            container.TabIndex = numParameter - 1;

            label = new Label();
            label.Text = name;
            label.Name = "l" + name;
            label.AutoSize = false;
            label.Width = getWidth(label, margin);
            container.Controls.Add(label);

            textBox = new TextBox();
            textBox.Name = name;
            textBox.Width = getWidth(textBox, margin);
            container.Controls.Add(textBox);

            if (label.Width + textBox.Width + margin*3 <= parent.Width)
            {
                label.Top = margin;
                label.Left = margin;
                textBox.Top = margin;
                textBox.Left = container.Width - margin - textBox.Width;
            }
            else
            {
                label.Top = margin;
                label.Left = margin;
                textBox.Top = margin*2 + label.Height;
                textBox.Left = margin;
            }

            parent.Controls.Add(container);

            parent.ResumeLayout(false);
        }

        private int getWidth(Control _control, int _margin)
        {
            if (_control.GetType() == typeof(Label))
            {
                Label label = (Label)_control;
                return _margin * label.Text.Length;
            }
            if (_control.GetType() == typeof(TextBox))
            {
                TextBox txtBox = (TextBox)_control;
                return _margin * 6;
            }

            return 0;
        }
    }
}
