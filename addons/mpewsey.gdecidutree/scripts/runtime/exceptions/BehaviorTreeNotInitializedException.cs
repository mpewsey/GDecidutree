using System;

namespace MPewsey.GDecidutree.Exceptions
{
    public class BehaviorTreeNotInitializedException : Exception
    {
        public BehaviorTreeNotInitializedException(string message) : base(message)
        {

        }
    }
}