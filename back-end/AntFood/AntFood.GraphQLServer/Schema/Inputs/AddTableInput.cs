using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntFood.Contracts;
using AntFood.Domain.Models;
using HotChocolate.Types;

namespace AntFood.GraphQLServer.Schema.Inputs
{
    public class AddTableInput : InputObjectType<AddTableContract>
    {
    }
}
