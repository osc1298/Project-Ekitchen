﻿using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Servicios.Interfaces
{
    public interface ITipoRecetaServicio
    {
        List<TipoReceta> ObtenerTiposRecetas();
    }
}
