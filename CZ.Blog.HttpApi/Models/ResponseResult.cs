using System;
using System.Collections.Generic;
using System.Text;

namespace CZ.Blog.HttpApi.Models
{
    public class ResponseResult
    {


        /// <summary>
        /// 响应码
        /// </summary>
        public ResponseCode Code { get; set; }
        /// <summary>
        /// 响应信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="message"></param>
        public ResponseResult(string message = "")
        {
            Message = message;
            Code = ResponseCode.Succeed;
        }
        public ResponseResult(Exception exception)
        {
            Message = exception.Message;
            Code = ResponseCode.Failed;
        }
    }
    public class ResponseResult<T> : ResponseResult
    {
        /// <summary>
        /// 响应数据
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="message"></param>
        public ResponseResult(T t, string message = "")
        {
            Message = message;
            Data = t;
            Code = ResponseCode.Succeed;
        }
    }
    /// <summary>
    /// 服务层响应码枚举
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Succeed = 0,

        /// <summary>
        /// 失败
        /// </summary>
        Failed = 500,
    }
}
