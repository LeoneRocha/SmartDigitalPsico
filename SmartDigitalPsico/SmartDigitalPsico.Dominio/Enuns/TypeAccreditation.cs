using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Dominio.Enuns
{
    public enum ETypeAccreditation
    {
        [Description("Conselho Regional de Medicina")]
        CRM = 0,
        [Description("Conselho Regional de Psicologia")]
        CRP = 1
    }
}
