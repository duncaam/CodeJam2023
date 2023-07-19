using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IS7024Project.Models;
using IS7024Project.Serializations;

namespace IS7024Project.Data
{
    public class IS7024ProjectContext : DbContext
    {
        public IS7024ProjectContext(DbContextOptions<IS7024ProjectContext> options)
            : base(options)
        {
        }
        public DbSet<IS7024Project.Models.PhotoshopResponse> Response { get; set; }
        public DbSet<IS7024Project.Models.imgBBResponse> imgBBResponse { get; set; }
        public DbSet<IS7024Project.Models.googleVAPIResponse> googleVAPIResponse { get; set; }
        public DbSet<IS7024Project.Models.Corkboard> Corkboard { get; set; }
        public DbSet<IS7024Project.Serializations.WalkScoreResponse> WalkScoreResponse { get; set; }

    }
}
