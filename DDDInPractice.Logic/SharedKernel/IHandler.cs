﻿namespace DDDInPractice.Logic.SharedKernel
{
    public interface IHandler<T>
        where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }
}