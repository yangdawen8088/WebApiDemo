using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;

namespace WebAPIDemo.Ddtabase
{
    public class DbWorker
    {
        public List<Worker> DbWorkers { get; set; }
        /// <summary>
        /// 职工信息数据库
        /// </summary>
        public DbWorker()
        {
            if (DbWorkers == null)
            {
                InitializeWorkers();
            }
        }

        private void InitializeWorkers()
        {
            DbWorkers = new List<Worker>()
            {
                new Worker()
                {
                    Id=Guid.NewGuid(),
                    WorkerName="张大大",
                    Age=18,
                    Gender=true,
                    Salary=6000,
                    Department="研发部门",
                    JobNum="20210723006"
                },
                new Worker()
                {
                    Id=Guid.NewGuid(),
                    WorkerName="张三",
                    Age=18,
                    Gender=true,
                    Salary=5000,
                    Department="IT部门",
                    JobNum="20210723001"
                },
                new Worker()
                {
                    Id=Guid.NewGuid(),
                    WorkerName="李四",
                    Age=20,
                    Gender=true,
                    Salary=6000,
                    Department="市场部",
                    JobNum="20210723002"
                },
                new Worker()
                {
                    Id=Guid.NewGuid(),
                    WorkerName="小红",
                    Age=28,
                    Gender=false,
                    Salary=8000,
                    Department="人事部",
                    JobNum="20210723003"
                },
                new Worker()
                {
                    Id=new Guid("3c434121-b694-4b79-b1c6-41a268e98fef"),
                    WorkerName="小方",
                    Age=23,
                    Gender=false,
                    Salary=8500,
                    Department="销售部",
                    JobNum="20210723004"
                }
            };
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Worker> GetWorker()
        {
            if (DbWorkers == null)
            {
                InitializeWorkers();
            }
            return DbWorkers;
        }
        /// <summary>
        /// 创建数据
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public async Task SetWorkerAsync(List<Worker> worker)
        {
            await Task.Run(() =>
            {
                DbWorkers.AddRange(worker);
            });
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="worke"></param>
        /// <returns></returns>
        public async Task UpdateWorkerAsync(Worker worke)
        {
            await Task.Run(() =>
            {
                Worker wor = DbWorkers.Where(w => w.Id == worke.Id).FirstOrDefault();
                if (wor != null)
                {
                    wor.WorkerName = worke.WorkerName;
                    wor.Age = worke.Age;
                    wor.Gender = worke.Gender;
                    wor.Salary = worke.Salary;
                    wor.Department = worke.Department;
                    wor.JobNum = worke.JobNum;
                }
            });
        }
        /// <summary>
        /// 根据 Id 删除数据
        /// </summary>
        /// <param name="workeId"></param>
        /// <returns></returns>
        public async Task DelWorkerAsync(Guid workeId)
        {
            await Task.Run(() =>
            {
                Worker wor = DbWorkers.Where(w => w.Id == workeId).FirstOrDefault();
                if (wor != null)
                {
                    DbWorkers.Remove(wor);
                }
            });
        }
    }
}
