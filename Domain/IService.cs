﻿using System;
namespace Domain
{
    public interface IService
    {
        decimal CalculateAmount(ServiceCommand serviceCommand);
    }
}
