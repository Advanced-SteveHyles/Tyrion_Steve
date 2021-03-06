﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructures
{
public class CircularBufferT<T>
{
    private readonly T[] _buffer;
    private int _start;
    private int _end;

    public CircularBufferT() : this(capacity: 10)
    {
        
    }
    public CircularBufferT(int capacity)
    {        
        _buffer = new T[capacity +1];
        _start = 0;
        _end = 0;
    }

    public void Write(T value)
    {
        _buffer[_end] = value;
        _end = (_end + 1) %_buffer.Length;
        if (_end == _start)
        {
            _start = (_start + 1)%_buffer.Length;
        }
    }

    public T Read()
    {
        var result = _buffer[_start];
        _start = (_start + 1)%_buffer.Length;
        return result;
    }

    public int Capacity { get { return _buffer.Length;} }


    public bool IsFull()
    {
        return (_end + 1)%_buffer.Length == _start;
    }

    public bool isEmpty()
    {
        return _start == _end;
    }

}
}
