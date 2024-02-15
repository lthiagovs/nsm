namespace NSM.COMMON
{

    public enum MessageType
    {
        Message_WrongFormat,
        Message_CloseServer,
        Message_CreateUser,
        Message_GetUser,
        Message_SearchUser,     
        Message_Confirmation,
        Message_Negation,
        Message_CreateFriendChat,

    }

    public class MessagePackage
    {

        //What is the message for?
        public MessageType MessageType { get; set; }

        //String list with informations
        public List<string> Informations { get; set; }

        //The client thats has sent this
        public int ClientId { get; set; }

    }
  
}
