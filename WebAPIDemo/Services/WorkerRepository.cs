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
        DbWorker dbWorker = new DbWorker();
        public void AddWorker(Worker worker)
        {
            dbWorker.DbWorkers.Add(worker);
        }

        public void DeleteWorker(Worker worker)
        {
            dbWorker.DbWorkers.Remove(worker);
        }

        public void DeleteWorkers(IEnumerable<Worker> workers)
        {
            foreach (Worker worker in workers)
            {
                dbWorker.DbWorkers.Remove(worker);
            }
        }

        public Worker GetWorker(Guid workerId)
        {
            var x = dbWorker.DbWorkers.Where(wk => wk.Id == workerId).FirstOrDefault();
            return dbWorker.DbWorkers.Where(wk => wk.Id == workerId).FirstOrDefault();
        }

        public IEnumerable<Worker> GetWorkers(string keyWord)
        {
            return dbWorker.DbWorkers.Where((worker)=> {
                return worker.WorkerName.Contains(keyWord);
            });
        }

        public Worker UpdateWorker(Worker worker)
        {
            Worker workerU= dbWorker.DbWorkers.Where(wk => wk.Id == worker.Id).FirstOrDefault();
            workerU = worker;
            return workerU;
        }

        public bool WorkerExists(Guid workerId)
        {
            return dbWorker.DbWorkers.Any(w => w.Id == workerId);
        }
    }
}
