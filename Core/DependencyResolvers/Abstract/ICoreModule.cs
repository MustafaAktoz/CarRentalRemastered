using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers.Abstract
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
