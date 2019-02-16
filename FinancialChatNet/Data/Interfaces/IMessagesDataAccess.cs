using System;
using System.Collections.Generic;
using System.Text;
using Transversal.Models;

namespace Data.Interfaces
{
    public interface IMessagesDataAccess
    {
        List<MessageModel> getMessageByProducer(string producer);
        bool addMessage(MessageModel message);

    }
}
