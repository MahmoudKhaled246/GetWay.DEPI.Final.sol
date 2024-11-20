using Auth.DEPI.Final.BLL.Interfaces;
using Auth.DEPI.Final.DAL.Data.Context;
using Auth.DEPI.Final.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DEPI.Final.BLL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if (typeof(TEntity) == typeof(Courses))
            {
                return await _context.Courses.Include(C => C.Instructor).ToListAsync() as IEnumerable<TEntity>;
            }
            else if (typeof(TEntity) == typeof(Instructor))
            {
                return await _context.Instructors.Include(I => I.Courses).ToListAsync() as IEnumerable<TEntity>;

            }
            else
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<TEntity> GetAsync(string Id)
        {
            if (typeof(TEntity) == typeof(Courses))
            {
                return await _context.Courses.Include(C => C.Instructor).FirstOrDefaultAsync(p=>p.Id == Id) as TEntity;
            }
            return  await _context.Set<TEntity>().FindAsync(Id); 
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

    }
}
