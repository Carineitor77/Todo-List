using System.Collections.Generic;
using System.Linq;
using TodoList.Data.Context;
using TodoList.Data.Entities;

namespace TodoList.Data.Repository
{
    public class AffairsRepository : IRepository<Affair>
    {
        private readonly ContextApp Context;

        public IEnumerable<Affair> All => Context.Affairs.ToList();

        public AffairsRepository(ContextApp context)
        {
            Context = context;
        }

        public void Add(Affair entity)
        {
            Context.Affairs.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(Affair entity)
        {
            Context.Affairs.Remove(entity);
            Context.SaveChanges();
        }

        public Affair FindById(int id)
        {
            return Context.Affairs.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Affair entity)
        {
            Context.Affairs.Update(entity);
            Context.SaveChanges();
        }
    }
}
