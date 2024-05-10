
using AutoMapper;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using FMS.Service;


namespace FMS.Web.Mappings
{
    public class AutoMapperConfiguration
    {



        public static void Configure(IContainer container)
        {

           
            Mapper.Initialize(cfg =>
            {

                cfg.ConstructServicesUsing(type => container.Resolve(type));
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
                


            });
        }
    }
}