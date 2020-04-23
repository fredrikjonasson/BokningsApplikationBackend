using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUseCase
    {
        void Execute();
    }

    public interface IUseCase<TUseCaseInput>
    {
        void Execute(TUseCaseInput input);
    }
}
