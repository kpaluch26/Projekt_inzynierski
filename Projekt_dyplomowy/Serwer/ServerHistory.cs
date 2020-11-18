using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwer
{
    class ServerHistory
    {
        public string ServerStartConnection(string s)
        {
            return $"{DateTime.Now} Użytkownik {s} połączył się z serwerem.";
        }
        public string ServerEndConnection(string s)
        {
            return $"{DateTime.Now} Użytkownik {s} rozłączył się z serwerem.";
        }
        public string ServerConnectionError(string s)
        {
            return $"Błąd! {DateTime.Now} Użytkownik {s} nagle rozłączył się z serwerem.";
        }
        public string ServerBeginReceive(string s, string n)
        {
            return $"{DateTime.Now} Użytkownik {s} rozpoczął presyłanie pliku o nazwie: {n}";
        }
        public string ServerEndReceive(string s, string n)
        {
            return $"{DateTime.Now} Użytkownik {s} zakończył presyłanie pliku o nazwie: {n}";
        }
        public string ServerTransferError(string s, string n)
        {
            return $"Błąd! {DateTime.Now} Użytkownik {s} zerwał połączenia podczas transmisji pliku o nazwie: {n}";
        }
        public string ServerStartSend(string s, string n)
        {
            return $"{DateTime.Now} Użytkownik {s} rozpoczął odbieranie pliku o nazwie: {n}";
        }
        public string ServerEndSend(string s, string n)
        {
            return $"{DateTime.Now} Użytkownik {s} zakończył odbieranie pliku o nazwie: {n}";
        }
        public string ServerStatusChange(string s)
        {
            return $"{DateTime.Now} Serwer zmienił status pracy na: {s}";
        }
    }
}
