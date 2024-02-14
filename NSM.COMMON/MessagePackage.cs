namespace NSM.COMMON
{

    public enum MessageType
    {
        Message_CloseServer,
        Message_CreateUser,
        Message_GetUser,
        Message_Confirmation,

    }

    public class MessagePackage
    {

        public MessageType MessageType { get; set; }
        public List<Object> Informations { get; set; }
        public int ClientId { get; set; }

    }
  
}
