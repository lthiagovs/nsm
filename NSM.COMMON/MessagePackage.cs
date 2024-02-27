namespace NSM.COMMON
{

    public enum MessageType
    {
        Message_WrongFormat,
        Message_CreateUser,
        Message_GetUser,
        Message_SearchUser,     
        Message_Confirmation,
        Message_Negation,
        Message_CreateFriendChat,
        Message_GetFriendChat,
        Message_GetFriendChatMessages,
        Message_SendMessage,
        Message_GetChatMessages,
        Message_DeleteUser,
        Message_ChangeProfilePhoto,
        Message_GetProfilePhoto,
        Message_ChangeUserName,
        Message_GetAllUserNames,
        Message_SendNotification,
        Message_GetNotification,

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
