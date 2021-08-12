using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Models
{
    public class Worker
    {
        /// <summary>
        /// 数据表ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 职工姓名
        /// </summary>
        public String WorkerName { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool? Gender { get; set; }
        /// <summary>
        /// 薪酬
        /// </summary>
        public decimal? Salary { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string JobNum { get; set; }
    }
}
