namespace Helix.UI.Mobile.Modules.BaseModule.Models
{
    public class NotificationFiche
    {
        public string? FicheNumber { get; set; }

        public short? TransactionType { get; set; }

        public string TransactionTypeName
        {
            get
            {

                switch (TransactionType)
                {
                    case 1:
                        return "Satınalma İrsaliyesi";
                    case 2:
                        return "Perakende Satış İade İrsaliyesi";
                    case 3:
                        return "Toptan Satış İade İrsaliyesi";
                    case 4:
                        return "Konsinye Çıkış İade İrsaliyesi";
                    case 5:
                        return "Konsinye Giriş İade İrsaliyesi";
                    case 6:
                        return "Alım İade İrsaliyesi";
                    case 7:
                        return "Perakende Satış İrsaliyesi";
                    case 8:
                        return "Toptan Satış İrsaliyesi";
                    case 9:
                        return "Konsinye Çıkış İrsaliyesi";
                    case 10:
                        return "Konsinye Giriş İade İrsaliyesi";
                    case 13:
                        return "Üretimden Giriş Fişi";
                    case 14:
                        return "Devir Fişi";
                    case 12:
                        return "Sarf Fişi";
                    case 11:
                        return "Fire Fişi";
                    case 25:
                        return "Ambar Fişi";
                    case 26:
                        return "Mustahsil İrsaliyesi";
                    case 50:
                        return "Sayım Fazlası Fişi";
                    case 51:
                        return "Sayım Eksiği Fişi";
                    default:
                        return "Diğer";
                }
            }
        }
    }
}
