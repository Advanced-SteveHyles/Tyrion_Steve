using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructures
{
public class CircularBuffer
{
    private double[] _buffer;
    private int _start;
    private int _end;

    public CircularBuffer() : this(capacity: 10)
    {
        
    }
    public CircularBuffer(int capacity)
    {        
        _buffer = new double[capacity +1];
        _start = 0;
        _end = 0;
    }

    public void Write(double value)
    {
        _buffer[_end] = value;
        _end = (_end + 1) %_buffer.Length;
        if (_end == _start)
        {
            _start = (_start + 1)%_buffer.Length;
        }
    }

    public double Read()
    {
        var result = _buffer[_start];
        _start = (_start + 1)%_buffer.Length;
        return result;
    }

    public int Capacity { get { return _buffer.Length;} }


    public bool isFull()
    {
        return (_end + 1)%_buffer.Length == _start;
    }

    public bool isEmpty()
    {
        return _start == _end;
    }

}
}
