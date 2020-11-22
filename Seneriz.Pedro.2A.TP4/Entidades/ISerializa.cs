using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz para serializar productos
    /// </summary>
    public interface ISerializa
    {
        bool Xml();
        string Path { get; }
    }
}
