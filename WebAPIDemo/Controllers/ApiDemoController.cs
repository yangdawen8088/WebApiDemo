using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;
using WebAPIDemo.Services;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDemoController : ControllerBase
    {
        private IWorkerRepository _workerRepository;

        public ApiDemoController(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        [HttpGet]
        public IActionResult GetDatasDemo([FromQuery] string keyWord)
        {
            return Ok(_workerRepository.GetWorkers(keyWord));
        }
        [HttpGet("{workerId}", Name = "GetDataDemo")]
        public IActionResult GetDataDemo([FromRoute] Guid workerId)
        {
            return Ok(_workerRepository.GetWorker(workerId));
        }
        [HttpPost]
        public IActionResult CreateDataDemo([FromBody] Worker worker)
        {
            worker.Id = Guid.NewGuid();
            _workerRepository.AddWorker(worker);
            return CreatedAtRoute("GetDataDemo", new { workerId = worker.Id }, worker);
        }
        [HttpDelete("{workerId}")]
        public IActionResult DeleteWorker([FromRoute] Guid workerId)
        {
            if (!_workerRepository.WorkerExists(workerId))
            {
                return NotFound("需要删除的数据不存在");
            }
            Worker worker = _workerRepository.GetWorker(workerId);
            _workerRepository.DeleteWorker(worker);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult DeleteByIDs([FromBody] IEnumerable<Guid> workerIDs)
        {
            if (workerIDs == null)
            {
                return NotFound("请选择删除的数据");
            }
            List<Worker> workers = new List<Worker>();
            foreach (Guid workerId in workerIDs)
            {
                workers.Add(_workerRepository.GetWorker(workerId));
            }
            _workerRepository.DeleteWorkers(workers);
            return NoContent();
        }
        [HttpPatch("{workerId}")]
        public IActionResult PartiallyUpdateWorker([FromRoute] Guid workerId, [FromBody] Worker worker)
        {
            if (!_workerRepository.WorkerExists(workerId))
            {
                return NotFound("需要修改的数据不存在");
            }
            worker.Id = workerId;
            _workerRepository.UpdateWorker(worker);
            return NoContent();
        }
    }
}
