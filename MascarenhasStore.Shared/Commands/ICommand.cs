using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Shared.Commands {
    public interface ICommand {
        bool Valid();
    }
}
