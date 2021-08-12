# WebApiDemo      
&emsp;&emsp;这是一个关于 `RESTful Api` 开发的演示案例，其中包括资源的新增、删除（单个删除、批量删除）、修改、查询（单个查询、关键字查询）等。做了开发这么久，领悟到最难的其实是最基础的，所以作此总结。同时对新手朋友掌握 WebApi 的开发能够起到启蒙与入门的作用。        
# Api Docs      
### 新增资源 *POST* ：`https://localhost:5001/api/ApiDemo`     
&emsp;&emsp;**请求：** Body 中的请求参数为 JSON 数据，如下所示：
```json
{
    "WorkerName":"小张",
    "JobNum":"20210812002"
}
```
&emsp;&emsp;**响应：** 创建资源成功返回创建的资源 JSON 对象，如下所示：       
```json
{
    "id": "2b9b0a2b-89f8-4d6e-af93-af068222d7a7",
    "workerName": "小张",
    "age": null,
    "gender": null,
    "salary": null,
    "department": null,
    "jobNum": "20210812002"
}
```
### 删除单个资源 *DELETE* ：`https://localhost:5001/api/ApiDemo/{workerId}`   
&emsp;&emsp;**请求：** 发送 `DELETE` 请求，URL中携带删除的资源的 ID，例如：https://localhost:5001/api/ApiDemo/024b04a6-6f7f-4342-b13a-d959096551e2     
&emsp;&emsp;**响应：** 响应 204 状态码，表示数据删除成功。       
### 批量删除资源 *DELETE* ：`https://localhost:5001/api/ApiDemo`     
&emsp;&emsp;**请求：** 发送 `DELETE` 请求，Body 中的请求参数为一个 GUID 字符串的数组，如下所示：        
```json
[
    "46b82108-6fa7-47c5-b095-f4e9c4519839",
    "f9a450dc-1ba8-447f-8297-03c4a47e9123"
]
```
&emsp;&emsp;**响应：** 响应 204 状态码，表示数据删除成功。       
### 修改资源 *PATCH* ：`https://localhost:5001/api/ApiDemo/{workerId}`    
&emsp;&emsp;**请求：** 发送 `PATCH` 请求，Body 中为一个 JSON 格式的 Worker 对象，如下所示：    
```json
{
    "workerName": "小军",
    "age": 54,
    "department": "fdsjafhdskajfsdafdsa",
    "gender": true
}
```
&emsp;&emsp;**响应：** 响应 204 状态码，表示数据更新成功。      
### 查询所有资源 *GET* ：`https://localhost:5001/api/ApiDemo`    
&emsp;&emsp;发送 `GET` 请求，返回所有数据：     
```json
[
    {
        "id": "6487d36d-33fb-4059-9a1f-4c1c5884c682",
        "workerName": "张三",
        "age": 18,
        "gender": true,
        "salary": 5000,
        "department": "IT部门",
        "jobNum": "20210723001"
    },
    {
        "id": "356305cf-110f-43d6-9a1b-b82f8200404b",
        "workerName": "李四",
        "age": 20,
        "gender": true,
        "salary": 6000,
        "department": "市场部",
        "jobNum": "20210723002"
    }
]
``` 
### 根据 ID 查询资源 *GET* ：`https://localhost:5001/api/ApiDemo/{workerId}`    
&emsp;&emsp;发送 `GET` 请求, URL ： `https://localhost:5001/api/ApiDemo/6487d36d-33fb-4059-9a1f-4c1c5884c682`。     
&emsp;&emsp;响应结果如下所示：     
```json
{
    "id": "6487d36d-33fb-4059-9a1f-4c1c5884c682",
    "workerName": "张三",
    "age": 18,
    "gender": true,
    "salary": 5000,
    "department": "IT部门",
    "jobNum": "20210723001"
}
```
### 根据关键字查询资源 *GET* ：`https://localhost:5001/api/ApiDemo?keyWord={keyWord}`      
&emsp;&emsp;发送 `GET` 请求, URL ： `https://localhost:5001/api/ApiDemo?keyWord=张`。     
&emsp;&emsp;响应 `WorkerName` 中含有“张”的数据，结果如下所示：     
```json
[
    {
        "id": "6487d36d-33fb-4059-9a1f-4c1c5884c682",
        "workerName": "张三",
        "age": 18,
        "gender": true,
        "salary": 5000,
        "department": "IT部门",
        "jobNum": "20210723001"
    }
]
```  
# The ended
