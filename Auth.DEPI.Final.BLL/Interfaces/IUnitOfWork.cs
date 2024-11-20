using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DEPI.Final.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public ICourseRepository CourseRepository { get;  }
        public IInstructorRepository InstructorRepository { get;  }
        public IStudentRepository StudentRepository { get;  }
        public IStudentCourseRepository StudentCourseRepository { get;  }
        public IVideoRepository VideoRepository { get;  }
    }
}
