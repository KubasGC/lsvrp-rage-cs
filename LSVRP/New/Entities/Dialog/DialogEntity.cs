using System;
using LSVRP.New.Enums;

namespace LSVRP.New.Entities.Dialog
{
    public class DialogEntity
    {
        public virtual DialogType Type => DialogType.Info;

        public virtual void OnAccept(object data)
        {
            throw new NotImplementedException();
        }

        public virtual void OnCancel(object data)
        {
            throw new NotImplementedException();
        }
    }
}