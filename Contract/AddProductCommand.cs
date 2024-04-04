using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class AddProductCommand:IRequest
    {
        public string Title { get; set;}
        public string Description { get; set;}
        public int Count {  get; set;}


    }
}
