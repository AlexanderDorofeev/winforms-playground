using System;

namespace MVPDemo.Model
{
    public class TodoItem
    {
        public TodoItem(int? id, string title,bool completed)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Completed = completed;
        }

        
        public int? Id { get;private set; }

        public string Title { get; private set; }
        
        public bool Completed { get; set; }
    }
}