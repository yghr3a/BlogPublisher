using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.Model
{
    public class PublishConfigTypeAndName
    {
        public string PublishConfigName { get ; set; }
        public Type PublishConfigType { get; set; }
        public override string ToString()
        {
            return PublishConfigName;
        }
    }
}
