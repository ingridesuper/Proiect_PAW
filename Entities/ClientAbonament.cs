using System;

namespace _2_1058_PISLARU_INGRID.Entities
{
    public class ClientAbonament
    {
        public int ClientId { get; set; }
        public int TipAbonamentId { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime? DataEnd { get; set; } //null daca e pe perioada nedefinita
        public double? Discount {  get; set; } 
    }
}
