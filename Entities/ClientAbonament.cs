using System;

namespace _2_1058_PISLARU_INGRID.Entities
{
    public class ClientAbonament
    {
        public int ClientId { get; set; }
        public int AbonamentId { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime? DataEnd { get; set; } //null daca e pe perioada nedefinita
        public int? Discount {  get; set; } 
    }
}
