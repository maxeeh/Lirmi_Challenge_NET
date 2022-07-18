using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Limi.Persistence.Postgresql.Entities;
using Lirmi.Domain.Models;

namespace Limi.Persistence.Postgresql.Mappings
{
    public class AsignaturaMap : Profile
    {
        public AsignaturaMap()
        {
            CreateMap<AsignaturaModel, Asignatura>();
            CreateMap<Asignatura, AsignaturaModel>();
        }
    }
}
