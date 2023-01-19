using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class Message
    {
        public Message()
        {

        }
        public Message(bool visibility)
        {
            VisibilityError = visibility;
        }
        public Message(bool visibility, string message)
        {
            VisibilityError = visibility;
            ErrorMessage = message;
        }
        private bool visibilityError = false;
        public bool VisibilityError
        {
            get { return visibilityError; }
            set { visibilityError = value; }
        }
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                visibilityError = !String.IsNullOrEmpty(value);
            }
        }

        public Message GetMessage(bool visibility, string message)
        {
            return new Message(visibility,message);
        }
        public Message GetMessage(bool visibility)
        {
            return new Message(visibility);
        }
        public bool IsError()
        {
            return visibilityError;
        }
    }
}
