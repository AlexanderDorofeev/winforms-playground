using System;

namespace MVPDemo
{
    public interface IView:IDisposable
    {
       bool Enabled { get; set; } 
    }
}