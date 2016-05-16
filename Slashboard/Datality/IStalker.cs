using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datality {
    /// <summary>
    /// Stalker interface is for the EF that holds static data in HexaGraham
    /// </summary>
    internal interface IStalker {
        Thing Thing { get; }
    }
}
