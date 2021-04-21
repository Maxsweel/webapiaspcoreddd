using DataLib.Context;
using DomainLib.Entitys;
using DomainLib.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLib.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(DataContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }


        //DELETE
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.id.Equals(id));
                if (result == null) { return false; }
                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }


        //INSERT
        public async Task<T> InsertAsync(T Item)
        {
            try
            {
                if(Item.id == Guid.Empty)
                {
                    Item.id = Guid.NewGuid();
                }
                Item.CreateAt = DateTime.UtcNow;
                _dataset.Add(Item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Item;
        }


        public async Task<bool>ExistAsync (Guid id)
        {
            return await _dataset.AnyAsync(p => p.id.Equals(id));
        }


        //SELECTS
        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.id.Equals(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async
            
            
           Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        //UPDATE
        public async Task<T> UpdateAsync(T Item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.id.Equals(Item.id));
                if (result == null) { return null; }

                Item.UpdateAt = DateTime.UtcNow;
                Item.CreateAt = result.CreateAt;
                _context.Entry(result).CurrentValues.SetValues(Item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Item;
            
        }
    }
}
