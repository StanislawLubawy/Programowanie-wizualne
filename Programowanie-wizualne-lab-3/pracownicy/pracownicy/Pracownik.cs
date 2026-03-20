using System;

namespace pracownicy
{
    public class Pracownik
    {
        public int Id { get; set; }
        public string Imie { get; set; } = string.Empty;
        public string Nazwisko { get; set; } = string.Empty;
        public int Wiek { get; set; }
        public string Stanowisko { get; set; } = string.Empty;
    }
}