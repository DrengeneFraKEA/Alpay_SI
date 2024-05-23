using GraphQL.Types;
using SI_10a.Models;

namespace SI_10a.QueryTypes
{
    public class MessageType : ObjectGraphType<Message>
    {
        
        public MessageType() 
        {
            Field<NonNullGraphType<StringGraphType>>(nameof(Message.msg));
        }
    }
}
