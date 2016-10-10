﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Restoran.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly RestoranContext context;
        public UnitRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(Unit entity)
        {
            context.Unit.Add(entity);
            context.SaveChanges();
        }
        public Unit Get(int id)
        {
            return context.Unit.Find(id);
        }
        public IEnumerable<Unit> GetAll()
        {
            return context.Unit.ToList();
        }
        public void Remove(Unit entity)
        {
            context.Unit.Remove(entity);
            context.SaveChanges();
        }
        public void Update(Unit entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}