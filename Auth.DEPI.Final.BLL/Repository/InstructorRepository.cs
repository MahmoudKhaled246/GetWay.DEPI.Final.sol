using Auth.DEPI.Final.BLL.Interfaces;
using Auth.DEPI.Final.DAL.Data.Context;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DEPI.Final.BLL.Repository
{
    public class InstructorRepository : GenericRepository<Instructor> , IInstructorRepository
    {
        public InstructorRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
