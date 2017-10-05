using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestCore.Data.Models;

namespace TestCore.Data.Repositories
{
    public interface ICounterRepository
    {
        Task<IEnumerable<Counter>> AllCounters();

        Task<Counter> GetCounter(int counterId);

        Task<Counter> UpdateCounter(Counter counter);

        Task<Counter> CreateCounter(Counter counter);

        Task DeleteCounter(int counterId);
    }

    public class CounterRepository : ICounterRepository
    {
        public async Task<IEnumerable<Counter>> AllCounters()
        {
            using (var db = new TestContext())
            {
                return await db.Counters.ToListAsync();
            }
        }

        public async Task<Counter> GetCounter(int counterId)
        {
            using (var db = new TestContext())
            {
                return await db.Counters.FindAsync(counterId);
            }
        }

        public async Task<Counter> UpdateCounter(Counter counter)
        {
            using (var db = new TestContext())
            {
                var fetched = await GetCounter(counter.CounterId);
                db.Counters.Update(fetched);
                fetched.Count = counter.Count;
                await db.SaveChangesAsync();
                return await GetCounter(fetched.CounterId);
            }
        }

        public async Task<Counter> CreateCounter(Counter counter)
        {
            using (var db = new TestContext())
            {
                await db.Counters.AddAsync(counter);
                await db.SaveChangesAsync();
                return counter;
            }
        }

        public async Task DeleteCounter(int counterId)
        {
            using (var db = new TestContext())
            {
                var fetched = await GetCounter(counterId);
                db.Counters.Remove(fetched);
                await db.SaveChangesAsync();
            }
        }
    }
}