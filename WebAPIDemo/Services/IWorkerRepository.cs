using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;

namespace WebAPIDemo.Services
{
    public interface IWorkerRepository
    {
        /// <summary>
        /// 获取 Worker 数据，可以通过关键字检索(姓名)
        /// </summary>
        /// <param name="keyWord">姓名关键字</param>
        /// <returns>列表</returns>
        IEnumerable<Worker> GetWorkers(string keyWord);
        /// <summary>
        /// 通过 Id 获取一个 Worker 
        /// </summary>
        /// <param name="workerId">workerId</param>
        /// <returns>Worker</returns>
        Worker GetWorker(Guid workerId);
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="worker">Worker</param>
        /// <returns>Worker</returns>
        Worker UpdateWorker(Worker worker);
        /// <summary>
        /// 新增 Worker
        /// </summary>
        /// <param name="worker">Worker</param>
        void AddWorker(Worker worker);
        /// <summary>
        /// 删除一个 Worker
        /// </summary>
        /// <param name="worker">Worker</param>
        void DeleteWorker(Worker worker);
        /// <summary>
        /// 批量删除 Worker
        /// </summary>
        /// <param name="workers">Workers</param>
        void DeleteWorkers(IEnumerable<Worker> workers);
        /// <summary>
        /// 判断 workerId 所对应的 worker 是否存在
        /// </summary>
        /// <param name="workerId">workerId</param>
        /// <returns>bool</returns>
        bool WorkerExists(Guid workerId);
    }
}
