﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teklican.Application.Wrapper
{
    public class ResponseException<T>
    {
        public ResponseException()
        {
        }
        public ResponseException(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public ResponseException(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }
    }
}
