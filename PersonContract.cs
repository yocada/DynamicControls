using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicControls
{
    internal class PersonContract : DynamicContract
    {
        public PersonContract(Form container) : base(container)
        {
        }

        protected override void addParameters()
        {
            addParameter("Nombre");
            addParameter("Edad");
        }
    }
}
