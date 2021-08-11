using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;
using WebAPIDemo.Ddtabase;

namespace WebAPIDemo.Services
{
    public class WorkerRepository : IWorkerRepository
    {
        public void AddWorker(Worker worker)
        {
            DbWorker.DbWorkers.Add(worker);
        }

        public void DeleteWorker(Worker worker)
        {
            DbWorker.DbWorkers.Remove(worker);
        }

        public void DeleteWorkers(IEnumerable<Worker> workers)
        {
            foreach (Worker worker in workers)
            {
                DbWorker.DbWorkers.Remove(worker);
            }
        }

        public Worker GetWorker(Guid workerId)
        {
            return DbWorker.DbWorkers.Where(wk => wk.Id == workerId).FirstOrDefault();
        }

        public IEnumerable<Worker> GetWorkers(string keyWord)
        {
            throw new NotImplementedException();
        }
    }
}
