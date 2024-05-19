using System;

namespace _2_1058_PISLARU_INGRID.Entities
{
    public class Plata //plati ce tb sa fie efectuate in viitor
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TipAbonamentId { get; set; }
        public double Suma {  get; set; } //calculeaza pe baza discountului
        public DateTime DueDate { get; set; }
        public string Statut { get; set; } //Upcoming sau restanta
    }
}
