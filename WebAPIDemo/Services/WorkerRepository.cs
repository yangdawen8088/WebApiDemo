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
            var x = DbWorker.DbWorkers.Where(wk => wk.Id == workerId).FirstOrDefault();
            return DbWorker.DbWorkers.Where(wk => wk.Id == workerId).FirstOrDefault();
        }

        public IEnumerable<Worker> GetWorkers(string keyWord)
        {
            return DbWorker.DbWorkers.Where((worker) =>
            {
                return worker.WorkerName.Contains(keyWord ?? "");
            });
        }

        public Worker UpdateWorker(Worker worker)
        {
            Worker workerU = new Worker();
            // 简单粗暴，不想思考那么多，这波操作有点笨拙，希望你能给出好的方案
            for (int i = 0; i < DbWorker.DbWorkers.Count; i++)
            {
                if (DbWorker.DbWorkers[i].Id == worker.Id)
                {
                    DbWorker.DbWorkers[i].WorkerName = (DbWorker.DbWorkers[i].WorkerName == worker.WorkerName || worker.WorkerName == null) ? DbWorker.DbWorkers[i].WorkerName : worker.WorkerName;
                    DbWorker.DbWorkers[i].Age = (DbWorker.DbWorkers[i].Age == worker.Age || worker.Age == null) ? DbWorker.DbWorkers[i].Age : worker.Age;
                    DbWorker.DbWorkers[i].Gender = (DbWorker.DbWorkers[i].Gender == worker.Gender || worker.Gender == null) ? DbWorker.DbWorkers[i].Gender : worker.Gender;
                    DbWorker.DbWorkers[i].Salary = (DbWorker.DbWorkers[i].Salary == worker.Salary || worker.Salary == null) ? DbWorker.DbWorkers[i].Salary : worker.Salary;
                    DbWorker.DbWorkers[i].Department = (DbWorker.DbWorkers[i].Department == worker.Department || worker.Department == null) ? DbWorker.DbWorkers[i].Department : worker.Department;
                    DbWorker.DbWorkers[i].JobNum = (DbWorker.DbWorkers[i].JobNum == worker.JobNum || worker.JobNum == null) ? DbWorker.DbWorkers[i].JobNum : worker.JobNum;
                    workerU = DbWorker.DbWorkers[i];
                }
            }
            return workerU;
        }

        public bool WorkerExists(Guid workerId)
        {
            return DbWorker.DbWorkers.Any(w => w.Id == workerId);
        }
    }
}
