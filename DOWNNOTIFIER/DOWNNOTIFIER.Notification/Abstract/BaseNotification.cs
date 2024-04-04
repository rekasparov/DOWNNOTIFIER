using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.Notification.Abstract
{
    public class BaseNotification
    {
        public virtual async Task SendNotification(Dictionary<string, object> parameters) { }
    }
}
